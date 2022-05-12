using DapperSpGenerator;
using Microsoft.Extensions.Configuration;

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddCommandLine(args)
    .Build();

var connectionString = config.GetConnectionString("Main");
var targetPath = config["TargetPath"];
var desiredNamespace = config["Namespace"];

if (!connectionString.HasContent())
{
    Console.Write("Connection String of database:");
    connectionString = Console.ReadLine();
}

if (!targetPath.HasContent())
{
    Console.Write("Target path for output files:");
    targetPath = Console.ReadLine();
}

if (!desiredNamespace.HasContent())
{
    Console.Write("Root namespace for output files:");
    desiredNamespace = Console.ReadLine();
}

Argue.HasContent(connectionString);
Argue.HasContent(targetPath);
Argue.HasContent(desiredNamespace);

var dapperCommandGen = new DapperCommandGeneration();

await dapperCommandGen.GenerateDapperClasses(connectionString!, targetPath!, desiredNamespace!);