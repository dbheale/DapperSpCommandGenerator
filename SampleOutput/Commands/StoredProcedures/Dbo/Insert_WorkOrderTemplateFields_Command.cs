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

namespace SampleOutput.Commands.StoredProcedures.Dbo
{

    public record struct Insert_WorkOrderTemplateFields_Command(int WorkOrderTemplateId, int FieldId, int WorkOrderTemplateSheetId, int SortOrder, string? LabelOverride, bool? UserInterfaceField, bool? OutputField, bool? GroupedBy, int HeaderStyleIndex, int RowStyleIndex, int CellStyleIndex, double? ColumnWidth, bool? Totals) : IDatabaseCommand
    {
        public DynamicParameters GetParameters()
        {
            var p = new DynamicParameters();
            p.Add("WorkOrderTemplateId", WorkOrderTemplateId);
			p.Add("FieldId", FieldId);
			p.Add("WorkOrderTemplateSheetId", WorkOrderTemplateSheetId);
			p.Add("SortOrder", SortOrder);
			p.Add("LabelOverride", LabelOverride);
			p.Add("UserInterfaceField", UserInterfaceField);
			p.Add("OutputField", OutputField);
			p.Add("GroupedBy", GroupedBy);
			p.Add("HeaderStyleIndex", HeaderStyleIndex);
			p.Add("RowStyleIndex", RowStyleIndex);
			p.Add("CellStyleIndex", CellStyleIndex);
			p.Add("ColumnWidth", ColumnWidth);
			p.Add("Totals", Totals);
            return p;
        }

        public CommandType GetCommandType() => CommandType.StoredProcedure;

        public string GetSqlStatement() => "[dbo].[Insert_WorkOrderTemplateFields]";

        public bool HasOutParameters() => false;

        public void SetOutParameters(DynamicParameters parameters) 
        {
            // Nothing to set
        }

        public override string ToString()
        {
            return $"WorkOrderTemplateId:{WorkOrderTemplateId}, FieldId:{FieldId}, WorkOrderTemplateSheetId:{WorkOrderTemplateSheetId}, SortOrder:{SortOrder}, LabelOverride:{LabelOverride}, UserInterfaceField:{UserInterfaceField}, OutputField:{OutputField}, GroupedBy:{GroupedBy}, HeaderStyleIndex:{HeaderStyleIndex}, RowStyleIndex:{RowStyleIndex}, CellStyleIndex:{CellStyleIndex}, ColumnWidth:{ColumnWidth}, Totals:{Totals}";
        }
    }
}