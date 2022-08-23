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
    public record Update_tbl_AdaptiveIndexDefrag_Analysis_log_Command(int analysis_id, string? Operation, int dbID, string? dbName, int objectID, string? objectName, int index_or_stat_ID, short? partitionNumber, DateTime? dateTimeStart, DateTime? dateTimeEnd, int durationSeconds, string? errorMessage) : IDatabaseCommand
    {
        public DynamicParameters GetParameters()
        {
            var p = new DynamicParameters();
            p.Add("analysis_id", analysis_id);
			p.Add("Operation", Operation);
			p.Add("dbID", dbID);
			p.Add("dbName", dbName);
			p.Add("objectID", objectID);
			p.Add("objectName", objectName);
			p.Add("index_or_stat_ID", index_or_stat_ID);
			p.Add("partitionNumber", partitionNumber);
			p.Add("dateTimeStart", dateTimeStart);
			p.Add("dateTimeEnd", dateTimeEnd);
			p.Add("durationSeconds", durationSeconds);
			p.Add("errorMessage", errorMessage);
            return p;
        }

        public CommandType GetCommandType() => CommandType.StoredProcedure;

        public string GetSqlStatement() => "[dbo].[Update_tbl_AdaptiveIndexDefrag_Analysis_log]";

        public bool HasOutParameters() => false;

        public void SetOutParameters(DynamicParameters parameters) 
        {
            // Nothing to set
        }

        public override string ToString()
        {
            return $"analysis_id:{analysis_id}, Operation:{Operation}, dbID:{dbID}, dbName:{dbName}, objectID:{objectID}, objectName:{objectName}, index_or_stat_ID:{index_or_stat_ID}, partitionNumber:{partitionNumber}, dateTimeStart:{dateTimeStart}, dateTimeEnd:{dateTimeEnd}, durationSeconds:{durationSeconds}, errorMessage:{errorMessage}";
        }
    }
}