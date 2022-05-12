using Dapper;
using System.Data;

namespace SampleOutput
{
    public static partial class DapperCommandExtensions
    {
        public static async Task<IEnumerable<T>> QueryAsync<T>(this IDbConnection dbConnection, IDatabaseCommand command, IDbTransaction? transaction = null, int? commandTimeout = null)
        {
            var parameters = command.GetParameters();

            var results = await dbConnection.QueryAsync<T>(
                command.GetStoredProcedure()
                , parameters
                , transaction
                , commandTimeout
                , command.GetCommandType());

            if (command.HasOutParameters())
            {
                command.SetOutParameters(parameters);
            }

            return results;
        }

        public static async Task<IEnumerable<dynamic>> QueryAsync(this IDbConnection dbConnection, IDatabaseCommand command, IDbTransaction? transaction = null, int? commandTimeout = null)
        {
            var parameters = command.GetParameters();

            var results = await dbConnection.QueryAsync(
                command.GetStoredProcedure()
                , parameters
                , transaction
                , commandTimeout
                , command.GetCommandType());

            if (command.HasOutParameters())
            {
                command.SetOutParameters(parameters);
            }

            return results;
        }

        public static async Task<T> QueryFirstAsync<T>(this IDbConnection dbConnection, IDatabaseCommand command, IDbTransaction? transaction = null, int? commandTimeout = null)
        {
            var parameters = command.GetParameters();

            var results = await dbConnection.QueryFirstAsync<T>(
                command.GetStoredProcedure()
                , parameters
                , transaction
                , commandTimeout
                , command.GetCommandType());

            if (command.HasOutParameters())
            {
                command.SetOutParameters(parameters);
            }

            return results;
        }

        public static async Task<T> QueryFirstOrDefaultAsync<T>(this IDbConnection dbConnection, IDatabaseCommand command, IDbTransaction? transaction = null, int? commandTimeout = null)
        {
            var parameters = command.GetParameters();

            var results = await dbConnection.QueryFirstOrDefaultAsync<T>(
                command.GetStoredProcedure()
                , parameters
                , transaction
                , commandTimeout
                , command.GetCommandType());

            if (command.HasOutParameters())
            {
                command.SetOutParameters(parameters);
            }

            return results;
        }

        public static async Task<T> QuerySingleAsync<T>(this IDbConnection dbConnection, IDatabaseCommand command, IDbTransaction? transaction = null, int? commandTimeout = null)
        {
            var parameters = command.GetParameters();

            var results = await dbConnection.QuerySingleAsync<T>(
                command.GetStoredProcedure()
                , parameters
                , transaction
                , commandTimeout
                , command.GetCommandType());

            if (command.HasOutParameters())
            {
                command.SetOutParameters(parameters);
            }

            return results;
        }

        public static async Task<T> QuerySingleOrDefaultAsync<T>(this IDbConnection dbConnection, IDatabaseCommand command, IDbTransaction? transaction = null, int? commandTimeout = null)
        {
            var parameters = command.GetParameters();

            var results = await dbConnection.QuerySingleOrDefaultAsync<T>(
                command.GetStoredProcedure()
                , parameters
                , transaction
                , commandTimeout
                , command.GetCommandType());

            if (command.HasOutParameters())
            {
                command.SetOutParameters(parameters);
            }

            return results;
        }

        public static async Task<int> ExecuteAsync(this IDbConnection dbConnection, IDatabaseCommand command, IDbTransaction? transaction = null, int? commandTimeout = null)
        {
            var parameters = command.GetParameters();

            var results = await dbConnection.ExecuteAsync(
                command.GetStoredProcedure()
                , parameters
                , transaction
                , commandTimeout
                , command.GetCommandType());

            if (command.HasOutParameters())
            {
                command.SetOutParameters(parameters);
            }

            return results;
        }

        public static async Task<T> ExecuteScalarAsync<T>(this IDbConnection dbConnection, IDatabaseCommand command, IDbTransaction? transaction = null, int? commandTimeout = null)
        {
            var parameters = command.GetParameters();

            var results = await dbConnection.ExecuteScalarAsync<T>(
                command.GetStoredProcedure()
                , parameters
                , transaction
                , commandTimeout
                , command.GetCommandType());

            if (command.HasOutParameters())
            {
                command.SetOutParameters(parameters);
            }

            return results;
        }
    }
}
