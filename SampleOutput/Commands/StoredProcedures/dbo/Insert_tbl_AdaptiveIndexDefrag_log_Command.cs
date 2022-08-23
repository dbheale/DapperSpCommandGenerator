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
    public record Insert_tbl_AdaptiveIndexDefrag_log_Command(int dbID, string? dbName, int objectID, string? objectName, int indexID, string? indexName, short? partitionNumber, double? fragmentation, long? page_count, long? range_scan_count, int fill_factor, DateTime? dateTimeStart, DateTime? dateTimeEnd, int durationSeconds, string? sqlStatement, string? errorMessage) : IDatabaseCommand
    {
        public DynamicParameters GetParameters()
        {
            var p = new DynamicParameters();
            p.Add("dbID", dbID);
			p.Add("dbName", dbName);
			p.Add("objectID", objectID);
			p.Add("objectName", objectName);
			p.Add("indexID", indexID);
			p.Add("indexName", indexName);
			p.Add("partitionNumber", partitionNumber);
			p.Add("fragmentation", fragmentation);
			p.Add("page_count", page_count);
			p.Add("range_scan_count", range_scan_count);
			p.Add("fill_factor", fill_factor);
			p.Add("dateTimeStart", dateTimeStart);
			p.Add("dateTimeEnd", dateTimeEnd);
			p.Add("durationSeconds", durationSeconds);
			p.Add("sqlStatement", sqlStatement);
			p.Add("errorMessage", errorMessage);
            return p;
        }

        public CommandType GetCommandType() => CommandType.StoredProcedure;

        public string GetSqlStatement() => "[dbo].[Insert_tbl_AdaptiveIndexDefrag_log]";

        public bool HasOutParameters() => false;

        public void SetOutParameters(DynamicParameters parameters) 
        {
            // Nothing to set
        }

        public override string ToString()
        {
            return $"dbID:{dbID}, dbName:{dbName}, objectID:{objectID}, objectName:{objectName}, indexID:{indexID}, indexName:{indexName}, partitionNumber:{partitionNumber}, fragmentation:{fragmentation}, page_count:{page_count}, range_scan_count:{range_scan_count}, fill_factor:{fill_factor}, dateTimeStart:{dateTimeStart}, dateTimeEnd:{dateTimeEnd}, durationSeconds:{durationSeconds}, sqlStatement:{sqlStatement}, errorMessage:{errorMessage}";
        }
    }
}