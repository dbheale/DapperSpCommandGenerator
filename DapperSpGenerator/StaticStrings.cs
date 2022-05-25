namespace DapperSpGenerator
{
    internal static class StaticStrings
	{

        public static string ConnectionStringMessage = "Connection String of database: ";
        public static string TargetPathMessage = "Target path for output files: ";
        public static string NamespaceMessage = "Root namespace for output files: ";
        public static string FinishMessage = "Commands generated in {0}ms.";

		public static string StoredProcedureRelativeFolderPath = "Commands/StoredProcedures";

		// Query to get all stored procedures in every schema.
		public static string Query = @"
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

    }
}
