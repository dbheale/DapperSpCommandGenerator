using Dapper;
using System.Data;

namespace SampleOutput
{
    public interface IDatabaseCommand
    {
        DynamicParameters GetParameters();
        CommandType GetCommandType();
        string GetStoredProcedure();
        bool HasOutParameters();
        void SetOutParameters(DynamicParameters parameters);
    }
}