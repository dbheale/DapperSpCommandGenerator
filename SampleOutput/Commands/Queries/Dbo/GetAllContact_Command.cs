/*
 * Sample custom command for getting all contacts.
 */
using Dapper;
using System.Data;

namespace SampleOutput.Commands.Queries.Dbo
{

    public record struct GetAllContact_Command() : IDatabaseCommand
    {
        public DynamicParameters GetParameters()
        {
            return new DynamicParameters();
        }

        public CommandType GetCommandType() => CommandType.Text;

        public string GetSqlStatement() => "SELECT * FROM dbo.Contacts";

        public bool HasOutParameters() => false;

        public void SetOutParameters(DynamicParameters parameters) 
        {
            // Nothing to set
        }

        public override string ToString()
        {
            return "Query: SELECT * FROM dbo.Contacts";
        }
    }
}