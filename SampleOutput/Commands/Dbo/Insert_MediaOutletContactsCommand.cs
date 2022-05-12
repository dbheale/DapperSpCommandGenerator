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

    public record struct Insert_MediaOutletContacts_Command(int MediaOutletId, int ContactId, int MediaOutletContactTypeId) : IDatabaseCommand
    {
        public DynamicParameters GetParameters()
        {
            var p = new DynamicParameters();
            p.Add("MediaOutletId", MediaOutletId);
			p.Add("ContactId", ContactId);
			p.Add("MediaOutletContactTypeId", MediaOutletContactTypeId);
            return p;
        }

        public CommandType GetCommandType() => CommandType.StoredProcedure;

        public string GetStoredProcedure() => "[dbo].[Insert_MediaOutletContacts]";

        public bool HasOutParameters() => false;

        public void SetOutParameters(DynamicParameters parameters) 
        {
            // Nothing to set
        }

        public override string ToString()
        {
            return $"MediaOutletId:{MediaOutletId}, ContactId:{ContactId}, MediaOutletContactTypeId:{MediaOutletContactTypeId}";
        }
    }
}