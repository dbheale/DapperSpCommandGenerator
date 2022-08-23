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
    public record Update_MediaOutletCirculations_Command(int Id, int MediaOutletId, string? PublishDays, string? PublishSchedule, int CirculationForSchedule, string? CirculationLabel) : IDatabaseCommand
    {
        public DynamicParameters GetParameters()
        {
            var p = new DynamicParameters();
            p.Add("Id", Id);
			p.Add("MediaOutletId", MediaOutletId);
			p.Add("PublishDays", PublishDays);
			p.Add("PublishSchedule", PublishSchedule);
			p.Add("CirculationForSchedule", CirculationForSchedule);
			p.Add("CirculationLabel", CirculationLabel);
            return p;
        }

        public CommandType GetCommandType() => CommandType.StoredProcedure;

        public string GetSqlStatement() => "[dbo].[Update_MediaOutletCirculations]";

        public bool HasOutParameters() => false;

        public void SetOutParameters(DynamicParameters parameters) 
        {
            // Nothing to set
        }

        public override string ToString()
        {
            return $"Id:{Id}, MediaOutletId:{MediaOutletId}, PublishDays:{PublishDays}, PublishSchedule:{PublishSchedule}, CirculationForSchedule:{CirculationForSchedule}, CirculationLabel:{CirculationLabel}";
        }
    }
}