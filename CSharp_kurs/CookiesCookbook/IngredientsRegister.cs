// See https://aka.ms/new-console-template for more information

using CookiesCookbook.Ingerdiants;

public class IngredientsRegister
{
    public IEnumerable<Ingredient> All { get; } = new List<Ingredient>
    {
        new WheatFlour(),
        new SpeltFlour(),
        new Butter(),
        new Chocolate(),
        new Sugar(),
        new Cardamom(),
        new Cinnamon(),
        new CocoaPowder()
    };

    public Ingredient GetById(int id)
    {
        return All.FirstOrDefault(ingredient => ingredient.Id == id);
    }
}
