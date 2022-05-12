﻿/*
 *         _   _   _ _____ ___     ____ _____ _   _ _____ ____    _  _____ _____ ____  
 *        / \ | | | |_   _/ _ \   / ___| ____| \ | | ____|  _ \  / \|_   _| ____|  _ \ 
 *       / _ \| | | | | || | | | | |  _|  _| |  \| |  _| | |_) |/ _ \ | | |  _| | | | |
 *      / ___ \ |_| | | || |_| | | |_| | |___| |\  | |___|  _ </ ___ \| | | |___| |_| |
 *     /_/   \_\___/  |_| \___/   \____|_____|_| \_|_____|_| \_\/   \_\_| |_____|____/ 
 *    This file has been automatically generated. Any modification will get overwritten.
 * If you need to create a custom method, please create a partial class in the same namespace.
 */
using Dapper;
using System.Data;

namespace SampleOutput.Commands.Dbo
{

    public record struct Insert_MediaOutlets_Command(string? Name, string? Street, string? Street2, string? Street3, string? City, string? State, string? PostalCode, string? CountryRegion, int DeliveryScheduleId) : IDatabaseCommand
    {
        public DynamicParameters GetParameters()
        {
            var p = new DynamicParameters();
            p.Add("Name", Name);
			p.Add("Street", Street);
			p.Add("Street2", Street2);
			p.Add("Street3", Street3);
			p.Add("City", City);
			p.Add("State", State);
			p.Add("PostalCode", PostalCode);
			p.Add("CountryRegion", CountryRegion);
			p.Add("DeliveryScheduleId", DeliveryScheduleId);
            return p;
        }

        public CommandType GetCommandType() => CommandType.StoredProcedure;

        public string GetStoredProcedure() => "[dbo].[Insert_MediaOutlets]";

        public bool HasOutParameters() => false;

        public void SetOutParameters(DynamicParameters parameters) 
        {
            // Nothing to set
        }

        public override string ToString()
        {
            return $"Name:{Name}, Street:{Street}, Street2:{Street2}, Street3:{Street3}, City:{City}, State:{State}, PostalCode:{PostalCode}, CountryRegion:{CountryRegion}, DeliveryScheduleId:{DeliveryScheduleId}";
        }
    }
}