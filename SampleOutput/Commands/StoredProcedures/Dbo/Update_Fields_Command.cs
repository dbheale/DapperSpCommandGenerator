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

    public record struct Update_Fields_Command(int Id, string? Name, string? Description, string? Label, int FieldTypeId, string? LabelFormula, string? Formula, bool? ReadOnly, int RoleId) : IDatabaseCommand
    {
        public DynamicParameters GetParameters()
        {
            var p = new DynamicParameters();
            p.Add("Id", Id);
			p.Add("Name", Name);
			p.Add("Description", Description);
			p.Add("Label", Label);
			p.Add("FieldTypeId", FieldTypeId);
			p.Add("LabelFormula", LabelFormula);
			p.Add("Formula", Formula);
			p.Add("ReadOnly", ReadOnly);
			p.Add("RoleId", RoleId);
            return p;
        }

        public CommandType GetCommandType() => CommandType.StoredProcedure;

        public string GetSqlStatement() => "[dbo].[Update_Fields]";

        public bool HasOutParameters() => false;

        public void SetOutParameters(DynamicParameters parameters) 
        {
            // Nothing to set
        }

        public override string ToString()
        {
            return $"Id:{Id}, Name:{Name}, Description:{Description}, Label:{Label}, FieldTypeId:{FieldTypeId}, LabelFormula:{LabelFormula}, Formula:{Formula}, ReadOnly:{ReadOnly}, RoleId:{RoleId}";
        }
    }
}