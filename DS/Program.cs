using Gads;
using Serilog;
using Serilog.Sinks.File;

var hasArgs = args.Length > 0;
var path = string.Empty;

if (hasArgs)
{
    path = args[0];
}
else
{
    Console.WriteLine("Input drive scanner path...");
    path = Console.ReadLine();
}

var gadsOutputTemplate = "{LogLevel:u1}|{SourceContext}|{Message:l}|{Properties}{NewLine}{Exception}";

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .Enrich.FromLogContext()
    .WriteTo.File("output.txt", outputTemplate: gadsOutputTemplate)
    .CreateLogger();

try
{
    var filePaths = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
    
    // TODO: Offload 'new'
    var parser = new Parser(new List<IParseStrategy>() { new SocialSecurityParseStrategy(), new CreditCardParseStrategy() });

    foreach (var filePath in filePaths)
    {
        parser.Parse(filePath);
    }
}
catch (PathTooLongException ex)
{
    Console.WriteLine($"An error occurred at given path: {path}. Path too long.");
}
catch (DirectoryNotFoundException ex)
{
    Console.WriteLine($"An error occurred at given path: {path}. Path not found.");
}
catch (UnauthorizedAccessException ex)
{
    Console.WriteLine($"An error occurred at given path: {path}. Access denied at path.");
}
catch (IOException ex)
{
    Console.WriteLine($"An error occurred at given path: {path}. Could not read files at location.");
}