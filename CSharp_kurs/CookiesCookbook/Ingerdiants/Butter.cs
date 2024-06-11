namespace CookiesCookbook.Ingerdiants;

public class Butter : Ingredient
{
    public override int Id => 3;

    public override string Name => "Butter";
    public override string PreparationInstruction =>
        $"Melt in water bath. {base.PreparationInstruction}";
}
