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
    public record Find_InsertionOrder_Command(string? InsertionOrderNumber, string? ClientName, string? PublisherName, string? Product, DateTime? StartBookingDate, DateTime? EndBookingDate, DateTime? StartInsertionDate, DateTime? EndInsertionDate) : IDatabaseCommand
    {
        public DynamicParameters GetParameters()
        {
            var p = new DynamicParameters();
            p.Add("InsertionOrderNumber", InsertionOrderNumber);
			p.Add("ClientName", ClientName);
			p.Add("PublisherName", PublisherName);
			p.Add("Product", Product);
			p.Add("StartBookingDate", StartBookingDate);
			p.Add("EndBookingDate", EndBookingDate);
			p.Add("StartInsertionDate", StartInsertionDate);
			p.Add("EndInsertionDate", EndInsertionDate);
            return p;
        }

        public CommandType GetCommandType() => CommandType.StoredProcedure;

        public string GetSqlStatement() => "[dbo].[Find_InsertionOrder]";

        public bool HasOutParameters() => false;

        public void SetOutParameters(DynamicParameters parameters) 
        {
            // Nothing to set
        }

        public override string ToString()
        {
            return $"InsertionOrderNumber:{InsertionOrderNumber}, ClientName:{ClientName}, PublisherName:{PublisherName}, Product:{Product}, StartBookingDate:{StartBookingDate}, EndBookingDate:{EndBookingDate}, StartInsertionDate:{StartInsertionDate}, EndInsertionDate:{EndInsertionDate}";
        }
    }
}