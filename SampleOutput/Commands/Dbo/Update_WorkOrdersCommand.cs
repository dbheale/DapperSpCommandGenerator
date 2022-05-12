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

    public record struct Update_WorkOrders_Command(int Id, int WorkOrderTypeId, int WorkOrderStatusId, int ClientContactId, string? RefNumber, string? Notes, string? Lead, DateTime? CreatedDate, DateTime? ModifiedDate, DateTime? CompletedDate) : IDatabaseCommand
    {
        public DynamicParameters GetParameters()
        {
            var p = new DynamicParameters();
            p.Add("Id", Id);
			p.Add("WorkOrderTypeId", WorkOrderTypeId);
			p.Add("WorkOrderStatusId", WorkOrderStatusId);
			p.Add("ClientContactId", ClientContactId);
			p.Add("RefNumber", RefNumber);
			p.Add("Notes", Notes);
			p.Add("Lead", Lead);
			p.Add("CreatedDate", CreatedDate);
			p.Add("ModifiedDate", ModifiedDate);
			p.Add("CompletedDate", CompletedDate);
            return p;
        }

        public CommandType GetCommandType() => CommandType.StoredProcedure;

        public string GetStoredProcedure() => "[dbo].[Update_WorkOrders]";

        public bool HasOutParameters() => false;

        public void SetOutParameters(DynamicParameters parameters) 
        {
            // Nothing to set
        }

        public override string ToString()
        {
            return $"Id:{Id}, WorkOrderTypeId:{WorkOrderTypeId}, WorkOrderStatusId:{WorkOrderStatusId}, ClientContactId:{ClientContactId}, RefNumber:{RefNumber}, Notes:{Notes}, Lead:{Lead}, CreatedDate:{CreatedDate}, ModifiedDate:{ModifiedDate}, CompletedDate:{CompletedDate}";
        }
    }
}