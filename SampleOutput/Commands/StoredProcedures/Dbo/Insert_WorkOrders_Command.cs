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
    public record Insert_WorkOrders_Command(int WorkOrderTypeId, int WorkOrderStatusId, int ClientContactId, int PublicationContactId, string? RefNumber, string? Notes, string? Lead, DateTime? CreatedDate, DateTime? ModifiedDate, DateTime? CompletedDate, int CampaignId, int MediaOutletId) : IDatabaseCommand
    {
        public DynamicParameters GetParameters()
        {
            var p = new DynamicParameters();
            p.Add("WorkOrderTypeId", WorkOrderTypeId);
			p.Add("WorkOrderStatusId", WorkOrderStatusId);
			p.Add("ClientContactId", ClientContactId);
			p.Add("PublicationContactId", PublicationContactId);
			p.Add("RefNumber", RefNumber);
			p.Add("Notes", Notes);
			p.Add("Lead", Lead);
			p.Add("CreatedDate", CreatedDate);
			p.Add("ModifiedDate", ModifiedDate);
			p.Add("CompletedDate", CompletedDate);
			p.Add("CampaignId", CampaignId);
			p.Add("MediaOutletId", MediaOutletId);
            return p;
        }

        public CommandType GetCommandType() => CommandType.StoredProcedure;

        public string GetSqlStatement() => "[dbo].[Insert_WorkOrders]";

        public bool HasOutParameters() => false;

        public void SetOutParameters(DynamicParameters parameters) 
        {
            // Nothing to set
        }

        public override string ToString()
        {
            return $"WorkOrderTypeId:{WorkOrderTypeId}, WorkOrderStatusId:{WorkOrderStatusId}, ClientContactId:{ClientContactId}, PublicationContactId:{PublicationContactId}, RefNumber:{RefNumber}, Notes:{Notes}, Lead:{Lead}, CreatedDate:{CreatedDate}, ModifiedDate:{ModifiedDate}, CompletedDate:{CompletedDate}, CampaignId:{CampaignId}, MediaOutletId:{MediaOutletId}";
        }
    }
}