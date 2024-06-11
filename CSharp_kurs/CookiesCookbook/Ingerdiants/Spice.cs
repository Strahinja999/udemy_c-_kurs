namespace CookiesCookbook.Ingerdiants;

public abstract class Spice : Ingredient
{
    public override string PreparationInstruction =>
        $"Take half a teaspoon. {base.PreparationInstruction}";
}
