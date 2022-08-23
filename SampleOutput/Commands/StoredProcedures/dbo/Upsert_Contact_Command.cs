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
    public record Upsert_Contact_Command(string? FirstName, string? LastName, string? Company, string? BusinessPhone, string? E_mailAddress, string? User2) : IDatabaseCommand
    {
        public DynamicParameters GetParameters()
        {
            var p = new DynamicParameters();
            p.Add("FirstName", FirstName);
			p.Add("LastName", LastName);
			p.Add("Company", Company);
			p.Add("BusinessPhone", BusinessPhone);
			p.Add("E_mailAddress", E_mailAddress);
			p.Add("User2", User2);
            return p;
        }

        public CommandType GetCommandType() => CommandType.StoredProcedure;

        public string GetSqlStatement() => "[dbo].[Upsert_Contact]";

        public bool HasOutParameters() => false;

        public void SetOutParameters(DynamicParameters parameters) 
        {
            // Nothing to set
        }

        public override string ToString()
        {
            return $"FirstName:{FirstName}, LastName:{LastName}, Company:{Company}, BusinessPhone:{BusinessPhone}, E_mailAddress:{E_mailAddress}, User2:{User2}";
        }
    }
}