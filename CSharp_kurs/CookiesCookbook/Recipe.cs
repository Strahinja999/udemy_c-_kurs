using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookiesCookbook.Ingerdiants;

namespace CookiesCookbook;
public class Recipe
{
    public IEnumerable<Ingredient> Ingredients { get; }
    public Recipe(IEnumerable<Ingredient> ingredients)
    {
        Ingredients = ingredients;
    }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        foreach (var ingredient in Ingredients)
        {
            sb.Append(ingredient.PrintInstructions());
            sb.Append("\n");
        }
        return sb.ToString();
    }
}
