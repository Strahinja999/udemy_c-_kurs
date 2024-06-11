// See https://aka.ms/new-console-template for more information


using CookiesCookbook.Ingerdiants;

namespace CookiesCookbook
{
    public interface IRecipesUserInteraction
    {
        void ShowMessage(string message);
        void Exit();
        void PrintExistingRecipes(IEnumerable<Recipe> recipes);
        void PromtToCreateRecipe();
        IEnumerable<Ingredient> ReadIngredientsFromUser();
    }
}
