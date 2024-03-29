﻿# Dapper Stored Procedure Command Generator
This project reads your database and creates "Commands" for Dapper to use. It reads all of your stored procedures in all of your schemas and creates a record for each for easier stored procedure execution.

This currently is only tested for .Net 6 and uses Records.

Required information:
  1) Connection String (SQL)
  2) Path to the directory you want the output to go to
  3) The root namespace you would like to use for the files.

Configuration; This can be configured in 3 different ways.
  1) Command line arguments. Sample: ConnectionStrings:Main="connectionStringHere" TargetPath="C:\git\sample output\" Namespace="Sample.DAL"
  2) appsettings.json
```
    {
      "ConnectionStrings": {
        "Main": ""
      },
      "TargetPath": "",
      "Namespace": "",
      "EnableForDotNetStandard2": ""
    }
```
  3) Durring execution you will be prompted if any of these values are not provided or are empty.


Post code generation sample execution:

`IEnuerable<User> users = await dbConn.QueryAsync<User>(new GetUser_Command(userId));`

If your stored procedure has OUT parameters, you can access them like so:

```
IDatabaseCommand canDownloadCommand = new Assert_UserCanDownload_Command(userId, fileId);
await dbConn.ExecuteAsync(canDownloadCommand);  
bool canDownload = canDownloadCommand.CanDownload;
```
