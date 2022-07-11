using System.Text.RegularExpressions;
using CreditCardValidator;
using Serilog;

namespace Gads;
public class CreditCardParseStrategy : IParseStrategy
{
    public void Parse(string line)
    {
        if (string.IsNullOrEmpty(line)) return;

        var pattern = "(?:4[0-9]{12}(?:[0-9]{3})?|[25][1-7][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\\d{3})\\d{11})";

        var r = new Regex(pattern);
        var match = r.Match(line);
        if (match.Success)
        {
            CreditCardDetector detector = new CreditCardDetector(match.Value); //TODO: offload 'new'
            if (detector.IsValid()) {
                Log.Information("CC Match: {0}", match.Value);
            }
        }
    }
}