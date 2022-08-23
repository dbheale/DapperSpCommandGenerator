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

    public class Upsert_TemplateSheet_Command : IDatabaseCommand
    {

        public Upsert_TemplateSheet_Command(string? sheetName, int rowIndex, string? columnName, int sortOrder, int templateId, int id)
        {
            this.SheetName = sheetName;
			this.RowIndex = rowIndex;
			this.ColumnName = columnName;
			this.SortOrder = sortOrder;
			this.TemplateId = templateId;
			this.Id = id;
        }

        public string? SheetName { get; }
		public int RowIndex { get; }
		public string? ColumnName { get; }
		public int SortOrder { get; }
		public int TemplateId { get; }
		public int Id { get; internal set; }

        public DynamicParameters GetParameters()
        {
            var p = new DynamicParameters();
            p.Add("SheetName", SheetName);
			p.Add("RowIndex", RowIndex);
			p.Add("ColumnName", ColumnName);
			p.Add("SortOrder", SortOrder);
			p.Add("TemplateId", TemplateId);
			p.Add("Id", Id, direction: ParameterDirection.Output, size: 4, dbType: DbType.Int32);
            return p;
        }

        public CommandType GetCommandType() => CommandType.StoredProcedure;

        public string GetSqlStatement() => "[dbo].[Upsert_TemplateSheet]";

        public bool HasOutParameters() => true;

        public void SetOutParameters(DynamicParameters parameters) 
        {
            Id = parameters.Get<int>("Id");
        }

        public override string ToString()
        {
            return $"SheetName:{SheetName}, RowIndex:{RowIndex}, ColumnName:{ColumnName}, SortOrder:{SortOrder}, TemplateId:{TemplateId}, Id:{Id}";
        }
    }
}