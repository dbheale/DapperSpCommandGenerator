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
    public record usp_AdaptiveIndexDefrag_Exceptions_Command(string? exceptionMask_DB, string? exceptionMask_days, string? exceptionMask_tables, string? exceptionMask_indexes) : IDatabaseCommand
    {
        public DynamicParameters GetParameters()
        {
            var p = new DynamicParameters();
            p.Add("exceptionMask_DB", exceptionMask_DB);
			p.Add("exceptionMask_days", exceptionMask_days);
			p.Add("exceptionMask_tables", exceptionMask_tables);
			p.Add("exceptionMask_indexes", exceptionMask_indexes);
            return p;
        }

        public CommandType GetCommandType() => CommandType.StoredProcedure;

        public string GetSqlStatement() => "[dbo].[usp_AdaptiveIndexDefrag_Exceptions]";

        public bool HasOutParameters() => false;

        public void SetOutParameters(DynamicParameters parameters) 
        {
            // Nothing to set
        }

        public override string ToString()
        {
            return $"exceptionMask_DB:{exceptionMask_DB}, exceptionMask_days:{exceptionMask_days}, exceptionMask_tables:{exceptionMask_tables}, exceptionMask_indexes:{exceptionMask_indexes}";
        }
    }
}