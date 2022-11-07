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
    public record Update_tbl_AdaptiveIndexDefrag_Stats_Working_Command(int dbID, int objectID, int statsID, short? partitionNumber, string? dbName, string? schemaName, string? objectName, string? statsName, bool? no_recompute, bool? is_incremental, DateTime? scanDate, DateTime? updateDate, bool? printStatus) : IDatabaseCommand
    {
        public DynamicParameters GetParameters()
        {
            var p = new DynamicParameters();
            p.Add("dbID", dbID);
			p.Add("objectID", objectID);
			p.Add("statsID", statsID);
			p.Add("partitionNumber", partitionNumber);
			p.Add("dbName", dbName);
			p.Add("schemaName", schemaName);
			p.Add("objectName", objectName);
			p.Add("statsName", statsName);
			p.Add("no_recompute", no_recompute);
			p.Add("is_incremental", is_incremental);
			p.Add("scanDate", scanDate);
			p.Add("updateDate", updateDate);
			p.Add("printStatus", printStatus);
            return p;
        }

        public CommandType GetCommandType() => CommandType.StoredProcedure;

        public string GetSqlStatement() => "[dbo].[Update_tbl_AdaptiveIndexDefrag_Stats_Working]";

        public bool HasOutParameters() => false;

        public void SetOutParameters(DynamicParameters parameters) 
        {
            // Nothing to set
        }

        public override string ToString()
        {
            return $"dbID:{dbID}, objectID:{objectID}, statsID:{statsID}, partitionNumber:{partitionNumber}, dbName:{dbName}, schemaName:{schemaName}, objectName:{objectName}, statsName:{statsName}, no_recompute:{no_recompute}, is_incremental:{is_incremental}, scanDate:{scanDate}, updateDate:{updateDate}, printStatus:{printStatus}";
        }
    }
}