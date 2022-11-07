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
    public record Update_LineItemProcessQueue_Command(long? Id, int LineItemId, int CampaignId, int StatusId, DateTime? CreatedDate, DateTime? ProcessedDate) : IDatabaseCommand
    {
        public DynamicParameters GetParameters()
        {
            var p = new DynamicParameters();
            p.Add("Id", Id);
			p.Add("LineItemId", LineItemId);
			p.Add("CampaignId", CampaignId);
			p.Add("StatusId", StatusId);
			p.Add("CreatedDate", CreatedDate);
			p.Add("ProcessedDate", ProcessedDate);
            return p;
        }

        public CommandType GetCommandType() => CommandType.StoredProcedure;

        public string GetSqlStatement() => "[dbo].[Update_LineItemProcessQueue]";

        public bool HasOutParameters() => false;

        public void SetOutParameters(DynamicParameters parameters) 
        {
            // Nothing to set
        }

        public override string ToString()
        {
            return $"Id:{Id}, LineItemId:{LineItemId}, CampaignId:{CampaignId}, StatusId:{StatusId}, CreatedDate:{CreatedDate}, ProcessedDate:{ProcessedDate}";
        }
    }
}