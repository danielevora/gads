using System.Text.RegularExpressions;
using Serilog;

namespace Gads;
public class SocialSecurityParseStrategy : IParseStrategy
{
    public void Parse(string line)
    {
        if (string.IsNullOrEmpty(line)) return;

        var pattern = "(?!666|000|9\\d{2})\\d{3}-(?!00)\\d{2}-(?!0{4})\\d{4}";
        var r = new Regex(pattern);
        var match = r.Match(line);
        if (match.Success)
        {
            Log.Information("SSN Match {0}", match.Value);
        }
    }
}