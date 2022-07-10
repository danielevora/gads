using System.Text.RegularExpressions;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var hasArgs = args.Length > 0;

if (!hasArgs) return;

// Set Args to Variables
var path = args[0];

//https://stackoverflow.com/questions/4254339/how-to-loop-through-all-the-files-in-a-directory-in-c-net
var filePaths = Directory.GetFiles(path, "*", SearchOption.AllDirectories);

foreach (var filePath in filePaths) 
{
    ProcessFile(filePath);
}

void ProcessFile(string filePath)
{
    var pattern = "(?!666|000|9\\d{2})\\d{3}-(?!00)\\d{2}-(?!0{4})\\d{4}";
    var r = new Regex(pattern);

    var lines = File.ReadAllLines(filePath);
    foreach (var line in lines)
    {
        var match = r.Match(line);
        if (match.Success)
        {
            Console.WriteLine($"Found Match {match.Value} in {path}");
            Console.WriteLine(line);
        }
    }
    Console.WriteLine($"Processed file '{path}'.");
}