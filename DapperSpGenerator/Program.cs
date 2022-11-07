using System.Diagnostics;
using DapperSpGenerator;
using Microsoft.Extensions.Configuration;

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddJsonFile("appsettings.local.json", true)
    .AddCommandLine(args)
    .Build();

var connectionString = config.GetConnectionString("Main");
var targetPath = config["TargetPath"];
var desiredNamespace = config["Namespace"];

if (!connectionString.HasContent())
{
    Console.Write(StaticStrings.ConnectionStringMessage);
    connectionString = Console.ReadLine();
}

if (!targetPath.HasContent())
{
    Console.Write(StaticStrings.TargetPathMessage);
    targetPath = Console.ReadLine();
}

if (!desiredNamespace.HasContent())
{
    Console.Write(StaticStrings.NamespaceMessage);
    desiredNamespace = Console.ReadLine();
}

Argue.HasContent(connectionString);
Argue.HasContent(targetPath);
Argue.HasContent(desiredNamespace);

var sw = new Stopwatch();
sw.Start();
await DapperCommandGeneration.GenerateDapperClasses(connectionString!, targetPath!, desiredNamespace!);
sw.Stop();

Console.WriteLine(StaticStrings.FinishMessage, sw.ElapsedMilliseconds);
