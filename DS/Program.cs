using Gads;

// See https://aka.ms/new-console-template for more information


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

var filePaths = Directory.GetFiles(path, "*", SearchOption.AllDirectories);

var parser = new Parser(new List<IParseStrategy>() { new SocialSecurityParseStrategy(), new CreditCardParseStrategy() });

foreach (var filePath in filePaths) 
{
    parser.Parse(filePath);
}