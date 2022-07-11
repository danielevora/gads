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
        foreach (var line in File.ReadAllLines(filePath))
        {
            foreach (var strategy in parseStrategies)
            {
                if (strategy.CanParse())
                {
                    strategy.Parse(line);
                }
            }
        }
        Console.WriteLine($"Processed file '{filePath}'.");
    }
}