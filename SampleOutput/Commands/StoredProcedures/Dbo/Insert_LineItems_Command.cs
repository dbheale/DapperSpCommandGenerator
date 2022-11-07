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
    public record Insert_LineItems_Command(int ReferenceId, int TemplateSheetId, int LineItemGroupId, int SortOrder, int ReferenceTypeId, int ParentId) : IDatabaseCommand
    {
        public DynamicParameters GetParameters()
        {
            var p = new DynamicParameters();
            p.Add("ReferenceId", ReferenceId);
			p.Add("TemplateSheetId", TemplateSheetId);
			p.Add("LineItemGroupId", LineItemGroupId);
			p.Add("SortOrder", SortOrder);
			p.Add("ReferenceTypeId", ReferenceTypeId);
			p.Add("ParentId", ParentId);
            return p;
        }

        public CommandType GetCommandType() => CommandType.StoredProcedure;

        public string GetSqlStatement() => "[dbo].[Insert_LineItems]";

        public bool HasOutParameters() => false;

        public void SetOutParameters(DynamicParameters parameters) 
        {
            // Nothing to set
        }

        public override string ToString()
        {
            return $"ReferenceId:{ReferenceId}, TemplateSheetId:{TemplateSheetId}, LineItemGroupId:{LineItemGroupId}, SortOrder:{SortOrder}, ReferenceTypeId:{ReferenceTypeId}, ParentId:{ParentId}";
        }
    }
}