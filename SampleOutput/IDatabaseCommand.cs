using Dapper;
using System.Data;

namespace SampleOutput
{
    /// <summary>
    /// This class is automatically generated.
    /// </summary>
    public interface IDatabaseCommand
    {
        DynamicParameters GetParameters();
        CommandType GetCommandType();
        string GetSqlStatement();
        bool HasOutParameters();
        void SetOutParameters(DynamicParameters parameters);
    }
}