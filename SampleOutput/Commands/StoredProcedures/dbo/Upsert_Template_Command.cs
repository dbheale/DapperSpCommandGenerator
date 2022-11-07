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

    public class Upsert_Template_Command : IDatabaseCommand
    {

        public Upsert_Template_Command(string? name, string? description, string? filename, bool? isWorkOrderTemplate, bool? isCampaignTemplate, int id)
        {
            this.Name = name;
			this.Description = description;
			this.Filename = filename;
			this.IsWorkOrderTemplate = isWorkOrderTemplate;
			this.IsCampaignTemplate = isCampaignTemplate;
			this.Id = id;
        }

        public string? Name { get; }
		public string? Description { get; }
		public string? Filename { get; }
		public bool? IsWorkOrderTemplate { get; }
		public bool? IsCampaignTemplate { get; }
		public int Id { get; internal set; }

        public DynamicParameters GetParameters()
        {
            var p = new DynamicParameters();
            p.Add("Name", Name);
			p.Add("Description", Description);
			p.Add("Filename", Filename);
			p.Add("IsWorkOrderTemplate", IsWorkOrderTemplate);
			p.Add("IsCampaignTemplate", IsCampaignTemplate);
			p.Add("Id", Id, direction: ParameterDirection.Output, size: 4, dbType: DbType.Int32);
            return p;
        }

        public CommandType GetCommandType() => CommandType.StoredProcedure;

        public string GetSqlStatement() => "[dbo].[Upsert_Template]";

        public bool HasOutParameters() => true;

        public void SetOutParameters(DynamicParameters parameters) 
        {
            Id = parameters.Get<int>("Id");
        }

        public override string ToString()
        {
            return $"Name:{Name}, Description:{Description}, Filename:{Filename}, IsWorkOrderTemplate:{IsWorkOrderTemplate}, IsCampaignTemplate:{IsCampaignTemplate}, Id:{Id}";
        }
    }
}