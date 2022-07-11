using System.Text.RegularExpressions;
namespace Gads;

public class SocialSecurityParseStrategy : IParseStrategy
{
    public SocialSecurityParseStrategy()
    {
    }

    public bool CanParse()
    {
        return true;
    }

    public string Parse(string line)
    {
        var pattern = "(?!666|000|9\\d{2})\\d{3}-(?!00)\\d{2}-(?!0{4})\\d{4}";
        var r = new Regex(pattern);
        var match = r.Match(line);
        if (match.Success)
        {
            Console.WriteLine($"Found Match {match.Value} in {line}");
            Console.WriteLine(line);
        }

        return string.Empty;
    }
}