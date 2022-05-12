# Dapper Stored Procedure Command Generator
This project reads your database and creates "Commands" for Dapper to use. It reads all of your stored procedures in all of your schemas and creates a record for each for easier stored procedure execution.

This currently is only tested for .Net 6 but should work for .Net 3.1

Required information:
  1) Connection String (SQL)
  2) Path to the directory you want the output to go to
  3) The root namespace you would like to use for the files.

Configuration; This can be configured in 3 different ways.
  1) Command line arguments. Sample: ConnectionStrings:Main="connectionStringHere" TargetPath="C:\git\sample output\" Namespace="Sample.DAL"
  2) appsettings.json
    {
      "ConnectionStrings": {
        "Main": ""
      },
      "TargetPath": "",
      "Namespace": "" 
    }
  3) Durring execution you will be prompted if any of these values are not provided or are empty.
