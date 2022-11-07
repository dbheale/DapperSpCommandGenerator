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
    public record Update_MediaOutlets_Command(int Id, string? Name, string? Street, string? Street2, string? Website, string? City, string? State, string? PostalCode, string? CountryRegion, string? Area, string? MaterialRequirements) : IDatabaseCommand
    {
        public DynamicParameters GetParameters()
        {
            var p = new DynamicParameters();
            p.Add("Id", Id);
			p.Add("Name", Name);
			p.Add("Street", Street);
			p.Add("Street2", Street2);
			p.Add("Website", Website);
			p.Add("City", City);
			p.Add("State", State);
			p.Add("PostalCode", PostalCode);
			p.Add("CountryRegion", CountryRegion);
			p.Add("Area", Area);
			p.Add("MaterialRequirements", MaterialRequirements);
            return p;
        }

        public CommandType GetCommandType() => CommandType.StoredProcedure;

        public string GetSqlStatement() => "[dbo].[Update_MediaOutlets]";

        public bool HasOutParameters() => false;

        public void SetOutParameters(DynamicParameters parameters) 
        {
            // Nothing to set
        }

        public override string ToString()
        {
            return $"Id:{Id}, Name:{Name}, Street:{Street}, Street2:{Street2}, Website:{Website}, City:{City}, State:{State}, PostalCode:{PostalCode}, CountryRegion:{CountryRegion}, Area:{Area}, MaterialRequirements:{MaterialRequirements}";
        }
    }
}