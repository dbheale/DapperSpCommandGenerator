using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using DapperSpGenerator.Properties;

namespace DapperSpGenerator
{
    public class DapperCommandGeneration
    {
        // Query to get all stored procedures in every schema.
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
	LEFT JOIN sys.parameters pa 
		ON OBJECT_NAME(pa.object_id) = pr.name
			AND SCHEMA_NAME(pr.schema_id) = OBJECT_SCHEMA_NAME(pa.object_id)
WHERE SCHEMA_NAME(pr.schema_id) <> 'cdc'
ORDER BY [Schema], [Procedure], [ParameterOrder]";


        public static async Task GenerateDapperClasses(string connectionString, string rootPath, string desiredNamespace)
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
        
        private static void BuildFiles(IGrouping<string, StoredProcedureDefinition> schemaRecords, string rootPath, string desiredNamespace)
        {
            var schema = schemaRecords.Key;
            var schemaProper = schema.ToUpperFirstCharacter();
            
            var storedProcedureGroups = schemaRecords
                .GroupBy(k => k.Procedure, e => e);

            foreach (var storedProcedureGroup in storedProcedureGroups)
            {
                
                var sp = storedProcedureGroup.FirstOrDefault()?.Procedure?.Trim();

                if (sp == null)
                {
                    continue;
                }

                var spProper = sp.ToUpperFirstCharacter();

                var parameters = GetDbParameters(storedProcedureGroup);

                var commandClass = $@"/*
 *         _   _   _ _____ ___     ____ _____ _   _ _____ ____    _  _____ _____ ____  
 *        / \ | | | |_   _/ _ \   / ___| ____| \ | | ____|  _ \  / \|_   _| ____|  _ \ 
 *       / _ \| | | | | || | | | | |  _|  _| |  \| |  _| | |_) |/ _ \ | | |  _| | | | |
 *      / ___ \ |_| | | || |_| | | |_| | |___| |\  | |___|  _ </ ___ \| | | |___| |_| |
 *     /_/   \_\___/  |_| \___/   \____|_____|_| \_|_____|_| \_\/   \_\_| |_____|____/ 
 *    This file has been automatically generated. Any modification will get overwritten.
 *       If you want to create custom commands, they must be in a different folder.
 */
using Dapper;
using System.Data;

namespace {desiredNamespace}.Commands.{schemaProper}
{{

    public record struct {spProper}_Command({string.Join(", ", parameters.Select(s => s.Definition))}) : IDatabaseCommand
    {{
        public DynamicParameters GetParameters()
        {{
            var p = new DynamicParameters();
            {string.Join($"{Environment.NewLine}\t\t\t", parameters.Select(s => s.SpParameter))}
            return p;
        }}

        public CommandType GetCommandType() => CommandType.StoredProcedure;

        public string GetSqlStatement() => ""[{schema}].[{sp}]"";

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

                var directory = Path.Combine("Commands", $"{schemaProper}");

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

        private static List<DbParameter> GetDbParameters(IGrouping<string?, StoredProcedureDefinition> storedProcedureGroup)
        {
            var hasParameters = storedProcedureGroup.All(a => a.ParameterName.HasContent());

            var parameters = new List<DbParameter>();

            if (hasParameters)
            {
                parameters = storedProcedureGroup
                    .Select(
                        s => new
                        {
                            Parameter = s.ParameterName?.Trim().TrimStart('@'),
                            ParameterType = s.Type?.Trim().GetCSharpType(),
                            SqlType = s.Type?.Trim().GetSqlType(),
                            DbType = s.Type?.Trim().GetDbType(),
                            IsOutput = s.IsOutput ?? false,
                            ParameterIndex = s.ParameterOrder - 1,
                            Size = s.Length
                        }
                    )
                    .Where(w => w.Parameter.HasContent())
                    .Select(
                        s => new DbParameter(
                            s.Parameter!, s.Parameter!.ToUpperFirstCharacter(), s.ParameterType!,
                            s.SqlType!, s.DbType!, s.IsOutput, s.ParameterIndex, s.Size!
                        )
                    ).ToList();
            }

            return parameters;
        }

    }
}