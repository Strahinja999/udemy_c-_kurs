// See https://aka.ms/new-console-template for more information

using CookiesCookbook.DataAccess;
using CookiesCookbook.Ingerdiants;

namespace CookiesCookbook
{
    public class RecipesRepository : IRecipesRepostitory
    {
        private const string Separator = ",";
        private readonly IStringRepository _stringRepository;
        private readonly IngredientsRegister _ingredientsRegister;
        public RecipesRepository(IStringRepository stringRepository,
            IngredientsRegister ingredientsRegister)
        {
            _stringRepository = stringRepository;
            _ingredientsRegister = ingredientsRegister;
        }
        public List<Recipe> Read(string filePath)
        {
            List<string> recipesFromFile = _stringRepository.Read(filePath);
            var recipes = new List<Recipe>();
            foreach (var recipeFromFile in recipesFromFile)
            {
                var recipe = RecipeFromString(recipeFromFile);
                recipes.Add(recipe);
            }

            return recipes;
        }

        private Recipe RecipeFromString(string recipeFromFile)
        {
            var textulaIds = recipeFromFile.Split(Separator);
            var ingredients = new List<Ingredient>();
            foreach (var textualId in textulaIds)
            {
                var id = int.Parse(textualId);
                var ingredient = _ingredientsRegister.GetById(id);
                ingredients.Add(ingredient);
            }
            return new Recipe(ingredients);
        }

        public void Write(string filePath, List<Recipe> allRecipes)
        {
            var recepiesAsStrings = new List<string>();
            foreach (var recipe in allRecipes)
            {
                var allIds = new List<int>();
                foreach (var ingredient in recipe.Ingredients)
                {
                    allIds.Add(ingredient.Id);
                }
                recepiesAsStrings.Add(string.Join(Separator, allIds));
            }
            _stringRepository.Write(filePath, recepiesAsStrings);
        }
    }
}
