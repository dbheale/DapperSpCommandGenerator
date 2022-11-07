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
    public record Insert_RepositoryFiles_Command(int ReferenceId, int ReferenceTypeId, int StorageTypeId, string? FileName, string? FileExtension, int CreatorUserId, DateTime? DateCreated, long? FileSize) : IDatabaseCommand
    {
        public DynamicParameters GetParameters()
        {
            var p = new DynamicParameters();
            p.Add("ReferenceId", ReferenceId);
			p.Add("ReferenceTypeId", ReferenceTypeId);
			p.Add("StorageTypeId", StorageTypeId);
			p.Add("FileName", FileName);
			p.Add("FileExtension", FileExtension);
			p.Add("CreatorUserId", CreatorUserId);
			p.Add("DateCreated", DateCreated);
			p.Add("FileSize", FileSize);
            return p;
        }

        public CommandType GetCommandType() => CommandType.StoredProcedure;

        public string GetSqlStatement() => "[dbo].[Insert_RepositoryFiles]";

        public bool HasOutParameters() => false;

        public void SetOutParameters(DynamicParameters parameters) 
        {
            // Nothing to set
        }

        public override string ToString()
        {
            return $"ReferenceId:{ReferenceId}, ReferenceTypeId:{ReferenceTypeId}, StorageTypeId:{StorageTypeId}, FileName:{FileName}, FileExtension:{FileExtension}, CreatorUserId:{CreatorUserId}, DateCreated:{DateCreated}, FileSize:{FileSize}";
        }
    }
}