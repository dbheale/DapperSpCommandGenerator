using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using DapperSpGenerator.Properties;

namespace DapperSpGenerator
{
    public class DapperCommandGeneration
    {
        public static async Task GenerateDapperClasses(string connectionString, string rootPath, string desiredNamespace)
        {
            using IDbConnection connection = new SqlConnection(connectionString);

            await ReWriteDapperExtensions(rootPath, desiredNamespace);

            await ReWriteCommandInterface(rootPath, desiredNamespace);

            var spDir = Path.Combine(rootPath, StaticStrings.StoredProcedureRelativeFolderPath);

            if (Directory.Exists(spDir))
            {
                Directory.Delete(spDir, true);
            }

            var storedProcedureDefinitions = await connection.QueryAsync<StoredProcedureDefinition>(StaticStrings.Query);

            // Group by schema, ignore the `temp` schema.
            var schemaRecordsGroup = storedProcedureDefinitions
                                     .GroupBy(g => g.Schema)
                                     .Where(w => !"temp".Equals(w.Key, StringComparison.OrdinalIgnoreCase));

            foreach (var schemaRecords in schemaRecordsGroup)
            {
                BuildFiles(schemaRecords!, rootPath, desiredNamespace);
            }
        }

        private static async Task ReWriteCommandInterface(string rootPath, string desiredNamespace)
        {
            var contract = Path.Combine(rootPath, "IDatabaseCommand.cs");
            if (File.Exists(contract))
            {
                File.Delete(contract);
            }

            await File.WriteAllTextAsync(contract, Resources.IDatabaseCommand.Replace("|^NAMESPACE^|", desiredNamespace));
        }

        private static async Task ReWriteDapperExtensions(string rootPath, string desiredNamespace)
        {
            var extensions = Path.Combine(rootPath, "DapperCommandExtensions.cs");
            if (File.Exists(extensions))
            {
                File.Delete(extensions);
            }

            await File.WriteAllTextAsync(
                extensions, Resources.DapperCommandExtensions.Replace("|^NAMESPACE^|", desiredNamespace)
            );
        }

        private static void BuildFiles(IGrouping<string, StoredProcedureDefinition> schemaRecords, string rootPath, string desiredNamespace)
        {
            var schema = schemaRecords.Key;

            var schemaProper = schema.ToUpperFirstCharacter();

            var schemaDirectory = Path.Combine(rootPath, StaticStrings.StoredProcedureRelativeFolderPath, $"{schemaProper}");

            Directory.CreateDirectory(schemaDirectory);

            var storedProcedureGroups = schemaRecords
                .GroupBy(k => k.Procedure, e => e);

            foreach (var storedProcedureGroup in storedProcedureGroups)
            {
                var storedProcedure = storedProcedureGroup.FirstOrDefault()?.Procedure?.Trim();

                if (storedProcedure == null)
                {
                    continue;
                }

                var spProper = storedProcedure.ToUpperFirstCharacter();

                var parameters = GetDbParameters(storedProcedureGroup);

                var commandClass = string.Empty;
                
                if(parameters.Any(a => a.IsOutput))
                {
                    commandClass = CreateCommandClass(desiredNamespace, schemaProper, spProper, parameters, schema, storedProcedure);
                }
                else
                {
                    commandClass = CreateCommandRecord(desiredNamespace, schemaProper, spProper, parameters, schema, storedProcedure);
                }

                var filepath = Path.Combine(schemaDirectory, $"{spProper}_Command.cs");

                if (File.Exists(filepath))
                {
                    File.Delete(filepath);
                }

                File.WriteAllText(filepath, commandClass, Encoding.UTF8);
            }
        }

        private static string CreateCommandRecord(string desiredNamespace, string schemaProper, string spProper, List<DbParameter> parameters,
                                                 string schema, string sp)
        {
            return $@"/*
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

namespace {desiredNamespace}.Commands.StoredProcedures.{schemaProper}
{{
    public record {spProper}_Command({string.Join(", ", parameters.Select(s => s.Definition))}) : IDatabaseCommand
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
            // Nothing to set
        }}

        public override string ToString()
        {{
            return $""{string.Join(", ", parameters.Select(s => s.String))}"";
        }}
    }}
}}";
        }

        private static string CreateCommandClass(string desiredNamespace, string schemaProper, string spProper, List<DbParameter> parameters,
                                                 string schema, string sp)
        {
            return $@"/*
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

namespace {desiredNamespace}.Commands.StoredProcedures.{schemaProper}
{{

    public class {spProper}_Command : IDatabaseCommand
    {{

        public {spProper}_Command({string.Join(", ", parameters.Select(s => s.ConstructorDefinition))})
        {{
            {string.Join($"{Environment.NewLine}\t\t\t", parameters.Select(s => s.ConstructorSetValues))}
        }}

        {string.Join($"{Environment.NewLine}\t\t", parameters.Select(s => s.Properties))}

        public DynamicParameters GetParameters()
        {{
            var p = new DynamicParameters();
            {string.Join($"{Environment.NewLine}\t\t\t", parameters.Select(s => s.SpParameter))}
            return p;
        }}

        public CommandType GetCommandType() => CommandType.StoredProcedure;

        public string GetSqlStatement() => ""[{schema}].[{sp}]"";

        public bool HasOutParameters() => true;

        public void SetOutParameters(DynamicParameters parameters) 
        {{
            {string.Join($"{Environment.NewLine}\t\t\t", parameters.Where(w => w.IsOutput).Select(s => s.SetPropertiesBack))}
        }}

        public override string ToString()
        {{
            return $""{string.Join(", ", parameters.Select(s => s.String))}"";
        }}
    }}
}}";
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