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

    public class Upsert_Field_Command : IDatabaseCommand
    {

        public Upsert_Field_Command(string? name, string? description, string? label, int fieldTypeId, string? labelFormula, string? formula, bool? readOnly, int roleId, int id)
        {
            this.Name = name;
			this.Description = description;
			this.Label = label;
			this.FieldTypeId = fieldTypeId;
			this.LabelFormula = labelFormula;
			this.Formula = formula;
			this.ReadOnly = readOnly;
			this.RoleId = roleId;
			this.Id = id;
        }

        public string? Name { get; }
		public string? Description { get; }
		public string? Label { get; }
		public int FieldTypeId { get; }
		public string? LabelFormula { get; }
		public string? Formula { get; }
		public bool? ReadOnly { get; }
		public int RoleId { get; }
		public int Id { get; internal set; }

        public DynamicParameters GetParameters()
        {
            var p = new DynamicParameters();
            p.Add("Name", Name);
			p.Add("Description", Description);
			p.Add("Label", Label);
			p.Add("FieldTypeId", FieldTypeId);
			p.Add("LabelFormula", LabelFormula);
			p.Add("Formula", Formula);
			p.Add("ReadOnly", ReadOnly);
			p.Add("RoleId", RoleId);
			p.Add("Id", Id, direction: ParameterDirection.Output, size: 4, dbType: DbType.Int32);
            return p;
        }

        public CommandType GetCommandType() => CommandType.StoredProcedure;

        public string GetSqlStatement() => "[dbo].[Upsert_Field]";

        public bool HasOutParameters() => true;

        public void SetOutParameters(DynamicParameters parameters) 
        {
            Id = parameters.Get<int>("Id");
        }

        public override string ToString()
        {
            return $"Name:{Name}, Description:{Description}, Label:{Label}, FieldTypeId:{FieldTypeId}, LabelFormula:{LabelFormula}, Formula:{Formula}, ReadOnly:{ReadOnly}, RoleId:{RoleId}, Id:{Id}";
        }
    }
}