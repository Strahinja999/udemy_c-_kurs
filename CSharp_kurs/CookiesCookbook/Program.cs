// See https://aka.ms/new-console-template for more information

using CookiesCookbook;
using CookiesCookbook.DataAccess;
using CookiesCookbook.Ingerdiants;

var ingredientsRegister = new IngredientsRegister();

const FileFormat Format = FileFormat.Json;

IStringRepository stringsRepository = Format == FileFormat.Json ?
    new StringJsonRepository() : new StringTextualRepository();
const string FileName = "recipes";

var filePath = Format == FileFormat.Json ?
    $"{FileName}.json" : $"{FileName}.txt";

var cookiesRecipesApp = new CookiesRecipesApp(
    new RecipesRepository(
        stringsRepository,
        ingredientsRegister), 
    new RecipesConsoleUserInteraction(ingredientsRegister)) ;
cookiesRecipesApp.Run(filePath);

public enum FileFormat
{
    Json,
    Txt
}

public class CookiesRecipesApp
{
    private readonly IRecipesRepostitory _recipesRepositoroy;
    private readonly IRecipesUserInteraction _recipesUserInteraction;

    public CookiesRecipesApp(IRecipesRepostitory recipesRepositoroy, IRecipesUserInteraction recipesUserInteraction)
    {
        _recipesUserInteraction = recipesUserInteraction;
        _recipesRepositoroy = recipesRepositoroy;
    }
    public void Run(string filePath)
    {
        var allRecipes = _recipesRepositoroy.Read(filePath);
        _recipesUserInteraction.PrintExistingRecipes(allRecipes);

        _recipesUserInteraction.PromtToCreateRecipe();

        var ingredients = _recipesUserInteraction.ReadIngredientsFromUser();

        if(ingredients.Count() > 0)
        {
            var recipe = new Recipe(ingredients);
            allRecipes.Add(recipe);
            _recipesRepositoroy.Write(filePath, allRecipes);

            _recipesUserInteraction.ShowMessage("Recipe added:");
            _recipesUserInteraction.ShowMessage(recipe.ToString());
        }

    }

}

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
        foreach(var recipeFromFile in recipesFromFile)
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
        foreach(var textualId in textulaIds)
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
            recepiesAsStrings.Add(string.Join(Separator,allIds));
        }
        _stringRepository.Write(filePath, recepiesAsStrings);
    }
}
