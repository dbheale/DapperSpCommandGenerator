/*
 *         _   _   _ _____ ___     ____ _____ _   _ _____ ____    _  _____ _____ ____  
 *        / \ | | | |_   _/ _ \   / ___| ____| \ | | ____|  _ \  / \|_   _| ____|  _ \ 
 *       / _ \| | | | | || | | | | |  _|  _| |  \| |  _| | |_) |/ _ \ | | |  _| | | | |
 *      / ___ \ |_| | | || |_| | | |_| | |___| |\  | |___|  _ </ ___ \| | | |___| |_| |
 *     /_/   \_\___/  |_| \___/   \____|_____|_| \_|_____|_| \_\/   \_\_| |_____|____/ 
 *    This file has been automatically generated. Any modification will get overwritten.
 * If you need to create a custom method, please create a partial class in the same namespace.
 */
using Dapper;
using System.Data;

namespace SampleOutput.Commands.Dbo
{

    public record struct Update_LineItems_Command(int Id, int WorkOrderId, int WorkOrderTemplateSheetId, int LineItemGroupId, int SortOrder) : IDatabaseCommand
    {
        public DynamicParameters GetParameters()
        {
            var p = new DynamicParameters();
            p.Add("Id", Id);
			p.Add("WorkOrderId", WorkOrderId);
			p.Add("WorkOrderTemplateSheetId", WorkOrderTemplateSheetId);
			p.Add("LineItemGroupId", LineItemGroupId);
			p.Add("SortOrder", SortOrder);
            return p;
        }

        public CommandType GetCommandType() => CommandType.StoredProcedure;

        public string GetStoredProcedure() => "[dbo].[Update_LineItems]";

        public bool HasOutParameters() => false;

        public void SetOutParameters(DynamicParameters parameters) 
        {
            // Nothing to set
        }

        public override string ToString()
        {
            return $"Id:{Id}, WorkOrderId:{WorkOrderId}, WorkOrderTemplateSheetId:{WorkOrderTemplateSheetId}, LineItemGroupId:{LineItemGroupId}, SortOrder:{SortOrder}";
        }
    }
}