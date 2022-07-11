namespace Gads;

public interface IParseStrategy
{
    public bool CanParse();
    public string Parse(string filePath);
}