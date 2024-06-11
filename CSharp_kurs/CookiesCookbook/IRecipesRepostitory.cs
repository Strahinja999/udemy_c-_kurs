// See https://aka.ms/new-console-template for more information

namespace CookiesCookbook
{
    public interface IRecipesRepostitory
    {

        List<Recipe> Read(string filePath);
        void Write(string filePath, List<Recipe> allRecipes);
    }
}
