namespace CookiesCookbook.DataAccess;

public abstract class StringRepository : IStringRepository
{
    public List<string> Read(string filePath)
    {
        if (File.Exists(filePath))
        {
            var fileContents = File.ReadAllText(filePath);
            return TextToStrings(fileContents);
        }
        return new List<string>();
    }
    protected abstract List<string> TextToStrings(string fileContents);

    public void Write(string filePath, List<string> allString)
    {
        File.WriteAllText(filePath, StringsToText(allString));
    }
    protected abstract string StringsToText(List<string> strings);
}
