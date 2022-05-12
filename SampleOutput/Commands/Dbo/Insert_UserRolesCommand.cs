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

    public record struct Insert_UserRoles_Command(int UserId, int RoleId) : IDatabaseCommand
    {
        public DynamicParameters GetParameters()
        {
            var p = new DynamicParameters();
            p.Add("UserId", UserId);
			p.Add("RoleId", RoleId);
            return p;
        }

        public CommandType GetCommandType() => CommandType.StoredProcedure;

        public string GetStoredProcedure() => "[dbo].[Insert_UserRoles]";

        public bool HasOutParameters() => false;

        public void SetOutParameters(DynamicParameters parameters) 
        {
            // Nothing to set
        }

        public override string ToString()
        {
            return $"UserId:{UserId}, RoleId:{RoleId}";
        }
    }
}