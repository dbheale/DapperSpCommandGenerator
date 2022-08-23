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

    public class Upsert_TemplateField_Command : IDatabaseCommand
    {

        public Upsert_TemplateField_Command(int templateId, string? fieldName, int templateSheetId, int sortOrder, string? labelOverride, bool? userInterfaceField, bool? outputField, bool? groupedBy, int headerStyleIndex, int rowStyleIndex, int cellStyleIndex, double? columnWidth, bool? totals, bool? columnLock, int id)
        {
            this.TemplateId = templateId;
			this.FieldName = fieldName;
			this.TemplateSheetId = templateSheetId;
			this.SortOrder = sortOrder;
			this.LabelOverride = labelOverride;
			this.UserInterfaceField = userInterfaceField;
			this.OutputField = outputField;
			this.GroupedBy = groupedBy;
			this.HeaderStyleIndex = headerStyleIndex;
			this.RowStyleIndex = rowStyleIndex;
			this.CellStyleIndex = cellStyleIndex;
			this.ColumnWidth = columnWidth;
			this.Totals = totals;
			this.ColumnLock = columnLock;
			this.Id = id;
        }

        public int TemplateId { get; }
		public string? FieldName { get; }
		public int TemplateSheetId { get; }
		public int SortOrder { get; }
		public string? LabelOverride { get; }
		public bool? UserInterfaceField { get; }
		public bool? OutputField { get; }
		public bool? GroupedBy { get; }
		public int HeaderStyleIndex { get; }
		public int RowStyleIndex { get; }
		public int CellStyleIndex { get; }
		public double? ColumnWidth { get; }
		public bool? Totals { get; }
		public bool? ColumnLock { get; }
		public int Id { get; internal set; }

        public DynamicParameters GetParameters()
        {
            var p = new DynamicParameters();
            p.Add("TemplateId", TemplateId);
			p.Add("FieldName", FieldName);
			p.Add("TemplateSheetId", TemplateSheetId);
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
			p.Add("ColumnLock", ColumnLock);
			p.Add("Id", Id, direction: ParameterDirection.Output, size: 4, dbType: DbType.Int32);
            return p;
        }

        public CommandType GetCommandType() => CommandType.StoredProcedure;

        public string GetSqlStatement() => "[dbo].[Upsert_TemplateField]";

        public bool HasOutParameters() => true;

        public void SetOutParameters(DynamicParameters parameters) 
        {
            Id = parameters.Get<int>("Id");
        }

        public override string ToString()
        {
            return $"TemplateId:{TemplateId}, FieldName:{FieldName}, TemplateSheetId:{TemplateSheetId}, SortOrder:{SortOrder}, LabelOverride:{LabelOverride}, UserInterfaceField:{UserInterfaceField}, OutputField:{OutputField}, GroupedBy:{GroupedBy}, HeaderStyleIndex:{HeaderStyleIndex}, RowStyleIndex:{RowStyleIndex}, CellStyleIndex:{CellStyleIndex}, ColumnWidth:{ColumnWidth}, Totals:{Totals}, ColumnLock:{ColumnLock}, Id:{Id}";
        }
    }
}