namespace CookiesCookbook.DataAccess;

public class StringTextualRepository : StringRepository
{
    private readonly string Separator = ",";
    protected override string StringsToText(List<string> strings)
    {
        return string.Join(Separator, strings);
    }

    protected override List<string> TextToStrings(string fileContents)
    {
        return fileContents.Split(Separator).ToList();
    }
}
