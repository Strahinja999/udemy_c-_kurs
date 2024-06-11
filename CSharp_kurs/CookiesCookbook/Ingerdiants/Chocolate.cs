﻿namespace CookiesCookbook.Ingerdiants;

public class Chocolate : Ingredient
{
    public override int Id => 4;

    public override string Name => "Chocolate";
    public override string PreparationInstruction => 
        $"Melt in water bath. {base.PreparationInstruction}";
}
