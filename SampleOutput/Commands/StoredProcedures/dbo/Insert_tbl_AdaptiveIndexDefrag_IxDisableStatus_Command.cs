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
    public record Insert_tbl_AdaptiveIndexDefrag_IxDisableStatus_Command(int dbID, int objectID, int indexID, bool? is_disabled, DateTime? dateTimeChange) : IDatabaseCommand
    {
        public DynamicParameters GetParameters()
        {
            var p = new DynamicParameters();
            p.Add("dbID", dbID);
			p.Add("objectID", objectID);
			p.Add("indexID", indexID);
			p.Add("is_disabled", is_disabled);
			p.Add("dateTimeChange", dateTimeChange);
            return p;
        }

        public CommandType GetCommandType() => CommandType.StoredProcedure;

        public string GetSqlStatement() => "[dbo].[Insert_tbl_AdaptiveIndexDefrag_IxDisableStatus]";

        public bool HasOutParameters() => false;

        public void SetOutParameters(DynamicParameters parameters) 
        {
            // Nothing to set
        }

        public override string ToString()
        {
            return $"dbID:{dbID}, objectID:{objectID}, indexID:{indexID}, is_disabled:{is_disabled}, dateTimeChange:{dateTimeChange}";
        }
    }
}