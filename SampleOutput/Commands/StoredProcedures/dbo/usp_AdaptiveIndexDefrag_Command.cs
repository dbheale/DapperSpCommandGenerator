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
    public record usp_AdaptiveIndexDefrag_Command(bool? Exec_Print, bool? printCmds, bool? outputResults, bool? debugMode, int timeLimit, string? dbScope, string? tblName, string? defragOrderColumn, string? defragSortOrder, bool? forceRescan, string? defragDelay, bool? ixtypeOption, double? minFragmentation, double? rebuildThreshold, double? rebuildThreshold_cs, int minPageCount, int maxPageCount, bool? fillfactor, string? scanMode, bool? onlineRebuild, bool? resumableRebuild, bool? sortInTempDB, byte? maxDopRestriction, bool? updateStats, bool? updateStatsWhere, string? statsSample, bool? persistStatsSample, double? statsThreshold, long? statsMinRows, bool? ix_statsnorecompute, bool? statsIncremental, bool? dealMaxPartition, bool? dealLOB, bool? ignoreDropObj, bool? disableNCIX, int offlinelocktimeout, int onlinelocktimeout, bool? abortAfterwait, bool? dealROWG, bool? getBlobfrag, string? dataCompression) : IDatabaseCommand
    {
        public DynamicParameters GetParameters()
        {
            var p = new DynamicParameters();
            p.Add("Exec_Print", Exec_Print);
			p.Add("printCmds", printCmds);
			p.Add("outputResults", outputResults);
			p.Add("debugMode", debugMode);
			p.Add("timeLimit", timeLimit);
			p.Add("dbScope", dbScope);
			p.Add("tblName", tblName);
			p.Add("defragOrderColumn", defragOrderColumn);
			p.Add("defragSortOrder", defragSortOrder);
			p.Add("forceRescan", forceRescan);
			p.Add("defragDelay", defragDelay);
			p.Add("ixtypeOption", ixtypeOption);
			p.Add("minFragmentation", minFragmentation);
			p.Add("rebuildThreshold", rebuildThreshold);
			p.Add("rebuildThreshold_cs", rebuildThreshold_cs);
			p.Add("minPageCount", minPageCount);
			p.Add("maxPageCount", maxPageCount);
			p.Add("fillfactor", fillfactor);
			p.Add("scanMode", scanMode);
			p.Add("onlineRebuild", onlineRebuild);
			p.Add("resumableRebuild", resumableRebuild);
			p.Add("sortInTempDB", sortInTempDB);
			p.Add("maxDopRestriction", maxDopRestriction);
			p.Add("updateStats", updateStats);
			p.Add("updateStatsWhere", updateStatsWhere);
			p.Add("statsSample", statsSample);
			p.Add("persistStatsSample", persistStatsSample);
			p.Add("statsThreshold", statsThreshold);
			p.Add("statsMinRows", statsMinRows);
			p.Add("ix_statsnorecompute", ix_statsnorecompute);
			p.Add("statsIncremental", statsIncremental);
			p.Add("dealMaxPartition", dealMaxPartition);
			p.Add("dealLOB", dealLOB);
			p.Add("ignoreDropObj", ignoreDropObj);
			p.Add("disableNCIX", disableNCIX);
			p.Add("offlinelocktimeout", offlinelocktimeout);
			p.Add("onlinelocktimeout", onlinelocktimeout);
			p.Add("abortAfterwait", abortAfterwait);
			p.Add("dealROWG", dealROWG);
			p.Add("getBlobfrag", getBlobfrag);
			p.Add("dataCompression", dataCompression);
            return p;
        }

        public CommandType GetCommandType() => CommandType.StoredProcedure;

        public string GetSqlStatement() => "[dbo].[usp_AdaptiveIndexDefrag]";

        public bool HasOutParameters() => false;

        public void SetOutParameters(DynamicParameters parameters) 
        {
            // Nothing to set
        }

        public override string ToString()
        {
            return $"Exec_Print:{Exec_Print}, printCmds:{printCmds}, outputResults:{outputResults}, debugMode:{debugMode}, timeLimit:{timeLimit}, dbScope:{dbScope}, tblName:{tblName}, defragOrderColumn:{defragOrderColumn}, defragSortOrder:{defragSortOrder}, forceRescan:{forceRescan}, defragDelay:{defragDelay}, ixtypeOption:{ixtypeOption}, minFragmentation:{minFragmentation}, rebuildThreshold:{rebuildThreshold}, rebuildThreshold_cs:{rebuildThreshold_cs}, minPageCount:{minPageCount}, maxPageCount:{maxPageCount}, fillfactor:{fillfactor}, scanMode:{scanMode}, onlineRebuild:{onlineRebuild}, resumableRebuild:{resumableRebuild}, sortInTempDB:{sortInTempDB}, maxDopRestriction:{maxDopRestriction}, updateStats:{updateStats}, updateStatsWhere:{updateStatsWhere}, statsSample:{statsSample}, persistStatsSample:{persistStatsSample}, statsThreshold:{statsThreshold}, statsMinRows:{statsMinRows}, ix_statsnorecompute:{ix_statsnorecompute}, statsIncremental:{statsIncremental}, dealMaxPartition:{dealMaxPartition}, dealLOB:{dealLOB}, ignoreDropObj:{ignoreDropObj}, disableNCIX:{disableNCIX}, offlinelocktimeout:{offlinelocktimeout}, onlinelocktimeout:{onlinelocktimeout}, abortAfterwait:{abortAfterwait}, dealROWG:{dealROWG}, getBlobfrag:{getBlobfrag}, dataCompression:{dataCompression}";
        }
    }
}