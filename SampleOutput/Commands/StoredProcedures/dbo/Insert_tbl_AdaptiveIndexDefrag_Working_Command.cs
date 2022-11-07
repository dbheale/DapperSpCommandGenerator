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
    public record Insert_tbl_AdaptiveIndexDefrag_Working_Command(int dbID, int objectID, int indexID, short? partitionNumber, string? dbName, string? schemaName, string? objectName, string? indexName, double? fragmentation, int page_count, bool? is_primary_key, int fill_factor, bool? is_disabled, bool? is_padded, bool? is_hypothetical, bool? has_filter, bool? allow_page_locks, string? compression_type, long? range_scan_count, long? record_count, byte? type, DateTime? scanDate, DateTime? defragDate, bool? printStatus, int exclusionMask) : IDatabaseCommand
    {
        public DynamicParameters GetParameters()
        {
            var p = new DynamicParameters();
            p.Add("dbID", dbID);
			p.Add("objectID", objectID);
			p.Add("indexID", indexID);
			p.Add("partitionNumber", partitionNumber);
			p.Add("dbName", dbName);
			p.Add("schemaName", schemaName);
			p.Add("objectName", objectName);
			p.Add("indexName", indexName);
			p.Add("fragmentation", fragmentation);
			p.Add("page_count", page_count);
			p.Add("is_primary_key", is_primary_key);
			p.Add("fill_factor", fill_factor);
			p.Add("is_disabled", is_disabled);
			p.Add("is_padded", is_padded);
			p.Add("is_hypothetical", is_hypothetical);
			p.Add("has_filter", has_filter);
			p.Add("allow_page_locks", allow_page_locks);
			p.Add("compression_type", compression_type);
			p.Add("range_scan_count", range_scan_count);
			p.Add("record_count", record_count);
			p.Add("type", type);
			p.Add("scanDate", scanDate);
			p.Add("defragDate", defragDate);
			p.Add("printStatus", printStatus);
			p.Add("exclusionMask", exclusionMask);
            return p;
        }

        public CommandType GetCommandType() => CommandType.StoredProcedure;

        public string GetSqlStatement() => "[dbo].[Insert_tbl_AdaptiveIndexDefrag_Working]";

        public bool HasOutParameters() => false;

        public void SetOutParameters(DynamicParameters parameters) 
        {
            // Nothing to set
        }

        public override string ToString()
        {
            return $"dbID:{dbID}, objectID:{objectID}, indexID:{indexID}, partitionNumber:{partitionNumber}, dbName:{dbName}, schemaName:{schemaName}, objectName:{objectName}, indexName:{indexName}, fragmentation:{fragmentation}, page_count:{page_count}, is_primary_key:{is_primary_key}, fill_factor:{fill_factor}, is_disabled:{is_disabled}, is_padded:{is_padded}, is_hypothetical:{is_hypothetical}, has_filter:{has_filter}, allow_page_locks:{allow_page_locks}, compression_type:{compression_type}, range_scan_count:{range_scan_count}, record_count:{record_count}, type:{type}, scanDate:{scanDate}, defragDate:{defragDate}, printStatus:{printStatus}, exclusionMask:{exclusionMask}";
        }
    }
}