/*
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

namespace SampleOutput.Commands.StoredProcedures.dbo
{
    public record Insert_Campaign_Command(int ClientContactId, DateTime? StartDate, DateTime? EndDate, string? Notes, string? Lead, string? Company, string? LineOfBusiness) : IDatabaseCommand
    {
        public DynamicParameters GetParameters()
        {
            var p = new DynamicParameters();
            p.Add("ClientContactId", ClientContactId);
			p.Add("StartDate", StartDate);
			p.Add("EndDate", EndDate);
			p.Add("Notes", Notes);
			p.Add("Lead", Lead);
			p.Add("Company", Company);
			p.Add("LineOfBusiness", LineOfBusiness);
            return p;
        }

        public CommandType GetCommandType() => CommandType.StoredProcedure;

        public string GetSqlStatement() => "[dbo].[Insert_Campaign]";

        public bool HasOutParameters() => false;

        public void SetOutParameters(DynamicParameters parameters) 
        {
            // Nothing to set
        }

        public override string ToString()
        {
            return $"ClientContactId:{ClientContactId}, StartDate:{StartDate}, EndDate:{EndDate}, Notes:{Notes}, Lead:{Lead}, Company:{Company}, LineOfBusiness:{LineOfBusiness}";
        }
    }
}