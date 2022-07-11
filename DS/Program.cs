using Gads;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var hasArgs = args.Length > 0;

if (!hasArgs) return;

// Set Args to Variables
var path = args[0];

//https://stackoverflow.com/questions/4254339/how-to-loop-through-all-the-files-in-a-directory-in-c-net
var filePaths = Directory.GetFiles(path, "*", SearchOption.AllDirectories);

var parser = new Parser(new List<IParseStrategy>() { new SocialSecurityParseStrategy() });

foreach (var filePath in filePaths) 
{
    parser.Parse(filePath);
}