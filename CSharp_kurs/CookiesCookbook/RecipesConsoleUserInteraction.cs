// See https://aka.ms/new-console-template for more information

using CookiesCookbook.Ingerdiants;

namespace CookiesCookbook
{
    public class RecipesConsoleUserInteraction : IRecipesUserInteraction
    {
        private readonly IngredientsRegister _ingredientsRegister;
        public RecipesConsoleUserInteraction(IngredientsRegister ingredientsRegister)
        {
            _ingredientsRegister = ingredientsRegister;
        }
        public void Exit()
        {
            Console.WriteLine("Oress any key to close.");
            Console.ReadKey();
        }

        public void PrintExistingRecipes(IEnumerable<Recipe> recipes)
        {
            if (recipes.Count() > 0)
            {
                Console.WriteLine("Existing recipes are: \n");
                int counter = 1;
                foreach (var recipe in recipes)
                {
                    Console.WriteLine($"*****{counter++}*****");
                    Console.WriteLine(recipe);
                    Console.WriteLine();
                }
            }
        }

        public void PromtToCreateRecipe()
        {
            Console.WriteLine("Create a new cookie recipe! " +
                "Available ingredients are: ");
            foreach (var ingredent in _ingredientsRegister.All)
            {
                Console.WriteLine(ingredent);
            }
        }

        public IEnumerable<Ingredient> ReadIngredientsFromUser()
        {
            bool shallStop = false;
            var ingredients = new List<Ingredient>();

            while (!shallStop)
            {
                Console.WriteLine("Add an ingredietn by its ID, ir type" +
                    "anything else if finished");

                var userInput = Console.ReadLine();
                if (int.TryParse(userInput, out int id))
                {
                    var selectedIngredient = _ingredientsRegister.GetById(id);
                    if (selectedIngredient is not null)
                    {
                        ingredients.Add(selectedIngredient);
                    }
                }
                else
                {
                    shallStop = true;
                }

            }

            return ingredients;
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
