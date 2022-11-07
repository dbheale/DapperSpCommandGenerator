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
    public record Update_tbl_AdaptiveIndexDefrag_Stats_log_Command(int statsUpdate_id, int dbID, string? dbName, int objectID, string? objectName, int statsID, string? statsName, short? partitionNumber, long? rows, long? rows_sampled, long? modification_counter, bool? no_recompute, DateTime? dateTimeStart, DateTime? dateTimeEnd, int durationSeconds, string? sqlStatement, string? errorMessage) : IDatabaseCommand
    {
        public DynamicParameters GetParameters()
        {
            var p = new DynamicParameters();
            p.Add("statsUpdate_id", statsUpdate_id);
			p.Add("dbID", dbID);
			p.Add("dbName", dbName);
			p.Add("objectID", objectID);
			p.Add("objectName", objectName);
			p.Add("statsID", statsID);
			p.Add("statsName", statsName);
			p.Add("partitionNumber", partitionNumber);
			p.Add("rows", rows);
			p.Add("rows_sampled", rows_sampled);
			p.Add("modification_counter", modification_counter);
			p.Add("no_recompute", no_recompute);
			p.Add("dateTimeStart", dateTimeStart);
			p.Add("dateTimeEnd", dateTimeEnd);
			p.Add("durationSeconds", durationSeconds);
			p.Add("sqlStatement", sqlStatement);
			p.Add("errorMessage", errorMessage);
            return p;
        }

        public CommandType GetCommandType() => CommandType.StoredProcedure;

        public string GetSqlStatement() => "[dbo].[Update_tbl_AdaptiveIndexDefrag_Stats_log]";

        public bool HasOutParameters() => false;

        public void SetOutParameters(DynamicParameters parameters) 
        {
            // Nothing to set
        }

        public override string ToString()
        {
            return $"statsUpdate_id:{statsUpdate_id}, dbID:{dbID}, dbName:{dbName}, objectID:{objectID}, objectName:{objectName}, statsID:{statsID}, statsName:{statsName}, partitionNumber:{partitionNumber}, rows:{rows}, rows_sampled:{rows_sampled}, modification_counter:{modification_counter}, no_recompute:{no_recompute}, dateTimeStart:{dateTimeStart}, dateTimeEnd:{dateTimeEnd}, durationSeconds:{durationSeconds}, sqlStatement:{sqlStatement}, errorMessage:{errorMessage}";
        }
    }
}