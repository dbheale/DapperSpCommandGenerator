using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using DapperSpGenerator.Properties;

namespace DapperSpGenerator
{
    public class DapperCommandGeneration
    {
        private const string Query = @"
SELECT SCHEMA_NAME(pr.schema_id) AS [Schema]
       , pr.name [Procedure]
	   , pa.name AS [ParameterName]
	   , type_name(user_type_id) AS [Type]
	   , CAST(max_length AS VARCHAR(100)) AS [Length]  
	   , CASE WHEN type_name(system_type_id) = 'uniqueidentifier' 
	   			THEN CAST(precision AS int)
	   			ELSE OdbcPrec(system_type_id, max_length, precision) 
	     END AS [Precision]
	   , OdbcScale(system_type_id, scale) AS [Scale]
	   , is_nullable AS [IsNullable]
	   , parameter_id AS [ParameterOrder]
	   , CAST(pa.is_output AS BIT) AS [IsOutput]
FROM   sys.procedures pr
	left join sys.parameters pa 
		on OBJECT_NAME(pa.object_id) = pr.name
			AND SCHEMA_NAME(pr.schema_id) = OBJECT_SCHEMA_NAME(pa.object_id)
WHERE SCHEMA_NAME(pr.schema_id) <> 'cdc'
ORDER BY [Schema], [Procedure], [ParameterOrder]";

        internal class StoredProcedureDefinition
        {
            public string? Schema { get; set; }
            public string? Procedure { get; set; }
            public string? ParameterName { get; set; }
            public string? Type { get; set; }
            public string? Length { get; set; }
            public int Precision { get; set; }
            public int Scale { get; set; }
            public bool IsNullable { get; set; }
            public int ParameterOrder { get; set; }
            public bool? IsOutput { get; set; }
        }

        public async Task GenerateDapperClasses(string connectionString, string rootPath, string desiredNamespace)
        {
            using IDbConnection connection = new SqlConnection(connectionString);

            var extensions = Path.Combine(rootPath, "DapperCommandExtensions.cs");
            if (File.Exists(extensions))
            {
                File.Delete(extensions);
            }
            await File.WriteAllTextAsync(extensions, Resources.DapperCommandExtensions.Replace("|^NAMESPACE^|", desiredNamespace));
            
            var contract = Path.Combine(rootPath, "IDatabaseCommand.cs");
            if (File.Exists(contract))
            {
                File.Delete(contract);
            }
            await File.WriteAllTextAsync(contract, Resources.IDatabaseCommand.Replace("|^NAMESPACE^|", desiredNamespace));

            var spDir = Path.Combine(rootPath, "Commands");

            if (Directory.Exists(spDir))
            {
                Directory.Delete(spDir, true);
            }

            var storedProcedureDefinitions = await connection.QueryAsync<StoredProcedureDefinition>(Query);

            var schemaRecordsGroup = storedProcedureDefinitions
                                     .GroupBy(g => g.Schema)
                                     .Where(w => !"temp".Equals(w.Key, StringComparison.OrdinalIgnoreCase));

            foreach (var schemaRecords in schemaRecordsGroup)
            {
                BuildFiles(schemaRecords!, rootPath, desiredNamespace);
            }
        }
        
        private void BuildFiles(IGrouping<string, StoredProcedureDefinition> schemaRecords, string rootPath, string desiredNamespace)
        {
            var schema = schemaRecords.Key;
            var schemaProper = char.ToUpper(schema[0]) + schema[1..];
            var className = $"{schemaProper}";
            var storedProcedureGroups = schemaRecords.GroupBy(k => k.Procedure, e => e);

            foreach (var storedProcedureGroup in storedProcedureGroups)
            {
                var hasParameters = storedProcedureGroup.All(a => a.ParameterName.HasContent());

                var sp = storedProcedureGroup.FirstOrDefault()?.Procedure?.Trim();

                if (sp == null)
                {
                    continue;
                }

                var spProper = char.ToUpper(sp[0]) + sp[1..];

                var parameters = new List<DbParameter>();

                if (hasParameters)
                {
                    parameters = storedProcedureGroup
                                 .Select(
                                     s => new
                                     {
                                         Parameter = s.ParameterName?.Trim().TrimStart('@'),
                                         ParameterType = GetCSharpType(s.Type?.Trim()),
                                         SqlType = GetSqlType(s.Type?.Trim()),
                                         DbType = GetDbType(s.Type?.Trim()),
                                         IsOutput = s.IsOutput ?? false,
                                         ParameterIndex = s.ParameterOrder - 1,
                                         Size = s.Length
                                     }
                                 )
                                 .Where(w => w.Parameter.HasContent())
                                 .Select(
                                     s => new DbParameter(
                                         s.Parameter, char.ToUpper(s.Parameter![0]) + s.Parameter[1..], s.ParameterType,
                                         s.SqlType, s.DbType, s.IsOutput, s.ParameterIndex, s.Size
                                     )
                                 ).ToList();
                }

                var commandClass = $@"/*
 *         _   _   _ _____ ___     ____ _____ _   _ _____ ____    _  _____ _____ ____  
 *        / \ | | | |_   _/ _ \   / ___| ____| \ | | ____|  _ \  / \|_   _| ____|  _ \ 
 *       / _ \| | | | | || | | | | |  _|  _| |  \| |  _| | |_) |/ _ \ | | |  _| | | | |
 *      / ___ \ |_| | | || |_| | | |_| | |___| |\  | |___|  _ </ ___ \| | | |___| |_| |
 *     /_/   \_\___/  |_| \___/   \____|_____|_| \_|_____|_| \_\/   \_\_| |_____|____/ 
 *    This file has been automatically generated. Any modification will get overwritten.
 * If you need to create a custom method, please create a partial class in the same namespace.
 */
using Dapper;
using System.Data;

namespace {desiredNamespace}.Commands.{schemaProper}
{{

    public record struct {spProper}_Command({string.Join($", ", parameters.Select(s => s.Definition))}) : IDatabaseCommand
    {{
        public DynamicParameters GetParameters()
        {{
            var p = new DynamicParameters();
            {string.Join($"{Environment.NewLine}\t\t\t", parameters.Select(s => s.SpParameter))}
            return p;
        }}

        public CommandType GetCommandType() => CommandType.StoredProcedure;

        public string GetStoredProcedure() => ""[{schema}].[{sp}]"";

        public bool HasOutParameters() => {(parameters.Any(a => a.IsOutput) ? "true" : "false")};

        public void SetOutParameters(DynamicParameters parameters) 
        {{
            {(parameters.Any(a => a.IsOutput) ? string.Join($"{Environment.NewLine}\t\t\t", parameters.Select(s => s.SetPropertiesBack)) : "// Nothing to set")}
        }}

        public override string ToString()
        {{
            return $""{string.Join(", ", parameters.Select(s => s.String))}"";
        }}
    }}
}}";

                var directory = Path.Combine("Commands", $"{className}");

                if (!Directory.Exists(Path.Combine(rootPath, directory)))
                {
                    Directory.CreateDirectory(Path.Combine(rootPath, directory));
                }

                var filepath = Path.Combine(directory, $"{spProper}Command.cs");

                if (File.Exists(Path.Combine(rootPath, filepath)))
                {
                    File.Delete(Path.Combine(rootPath, filepath));
                }

                File.WriteAllText(Path.Combine(rootPath, filepath), commandClass, Encoding.UTF8);
            }

            const string spDir = "Commands";

            if (!Directory.Exists(Path.Combine(rootPath, spDir)))
            {
                Directory.CreateDirectory(Path.Combine(rootPath, spDir));
            }
        }

        private static string GetSqlType(string? typeName)
        {
            return typeName switch
            {
                "image" => "SqlDbType.Image",
                "text" => "SqlDbType.Text",
                "uniqueidentifier" => "SqlDbType.UniqueIdentifier",
                "date" => "SqlDbType.Date",
                "time" => "SqlDbType.Time",
                "datetime2" => "SqlDbType.DateTime2",
                "datetimeoffset" => "SqlDbType.DateTimeOffset",
                "tinyint" => "SqlDbType.TinyInt",
                "smallint" => "SqlDbType.SmallInt",
                "int" => "SqlDbType.Int",
                "smalldatetime" => "SqlDbType.SmallDateTime",
                "real" => "SqlDbType.Real",
                "money" => "SqlDbType.Money",
                "datetime" => "SqlDbType.DateTime",
                "float" => "SqlDbType.Float",
                "sql_variant" => "SqlDbType.Variant",
                "ntext" => "SqlDbType.NText",
                "bit" => "SqlDbType.Bit",
                "decimal" => "SqlDbType.Decimal",
                "smallmoney" => "SqlDbType.SmallMoney",
                "bigint" => "SqlDbType.BigInt",
                "varbinary" => "SqlDbType.VarBinary",
                "varchar" => "SqlDbType.VarChar",
                "binary" => "SqlDbType.Binary",
                "char" => "SqlDbType.Char",
                "timestamp" => "SqlDbType.Timestamp",
                "nvarchar" => "SqlDbType.NVarChar",
                "nchar" => "SqlDbType.NChar",
                "xml" => "SqlDbType.Xml",
                _ => "SqlDbType.Udt",
            };
        }

        private static string GetDbType(string? typeName)
        {
            return typeName switch
            {
                "uniqueidentifier" => "DbType.Guid",
                "date" => "DbType.Date",
                "time" => "DbType.Time",
                "smalldatetime" => "DbType.DateTime",
                "datetime2" => "DbType.DateTime2",
                "datetimeoffset" => "DbType.DateTimeOffset",
                "tinyint" => "DbType.UInt16",
                "smallint" => "DbType.Int16",
                "int" => "DbType.Int32",
                "bigint" => "DbType.Int64",
                "money" or "smallmoney" => "DbType.Currency",
                "datetime" => "DbType.DateTime",
                "float" => "DbType.Double",
                "bit" => "DbType.Boolean",
                "decimal" => "DbType.Decimal",
                "varbinary" => "DbType.Binary",
                "varchar" or "ntext" or "text" or "char" or "nvarchar" or "nchar" => "DbType.String",
                "binary" => "DbType.Binary",
                "xml" => "DbType.Xml",
                _ => "DbType.Object",
            };
        }

        private static string GetCSharpType(string? typeName)
        {
            return typeName switch
            {
                "date" or "datetime" or "smalldatetime" or "datetime2" => "DateTime?",
                "time" => "TimeSpan?",
                "datetimeoffset" => "DateTimeOffset?",
                "tinyint" => "byte?",
                "smallint" => "short?",
                "int" => "int",
                "bigint" => "long?",
                "real" => "float?>",
                "float" => "double?",
                "bit" => "bool?",
                "decimal" or "numeric" or "money" or "smallmoney" => "decimal?",
                "image" or "binary" or "varbinary" or "timestamp" => "byte[]?",
                "text" or "ntext" or "char" or "nchar" or "varchar" or "nvarchar" => "string?",
                _ => "object?",
            };
        }

        public class DbParameter
        {
            public string Parameter { get; }
            public string ParameterProper { get; }
            public string ParameterType { get; }
            public string SqlType { get; }
            public string DbType { get; }
            public bool IsOutput { get; }
            public int ParameterIndex { get; }
            public string Size { get; }

            public DbParameter(string parameter, string parameterProper, string parameterType, string sqlType, string dbType, bool isOutput, int parameterIndex, string size)
            {
                Parameter = parameter;
                ParameterProper = parameterProper;
                ParameterType = parameterType;
                SqlType = sqlType;
                DbType = dbType;
                IsOutput = isOutput;
                ParameterIndex = parameterIndex;
                Size = size;
            }

            public string Definition => $"{ParameterType} {ParameterProper}";
            public string String => $"{ParameterProper}:{{{ParameterProper}}}";
            public string SetPropertiesBack => IsOutput ? $"{ParameterProper} = parameters.Get<{ParameterType}>(\"{Parameter}\");" : string.Empty;
            public string SpParameter => $@"p.Add(""{Parameter}"", {ParameterProper}{(IsOutput ? $", direction: ParameterDirection.Output, size: {Size}, dbType: {DbType}" : string.Empty)});";
        }
    }
}