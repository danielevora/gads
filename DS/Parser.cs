using Serilog.Context;

namespace Gads;
public class Parser
{
    private readonly IEnumerable<IParseStrategy> parseStrategies;

    public Parser(IEnumerable<IParseStrategy> parseStrategies)
    {
        this.parseStrategies = parseStrategies;
    }

    public void Parse(string filePath)
    {
        var lineNum = 1;
        using (LogContext.PushProperty("path", filePath))
        {
            foreach (var line in File.ReadAllLines(filePath))
            {
                using (LogContext.PushProperty("lineNum", lineNum))
                {
                    foreach (var strategy in parseStrategies)
                    {
                        strategy.Parse(line);
                    }
                }
                lineNum += 1;
            }
        }
    }
}