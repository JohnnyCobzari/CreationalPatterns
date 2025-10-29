namespace CreationalPatterns.Builder;

public class FettuccineBuilder : PastaBuilder
{
    public override void SetType() => pasta.Type = "Fettuccine";
    public override void AddSauce() => pasta.Sauce = "Mushroom Garlic Sauce";
    public override void SetCookingTime() => pasta.CookingTime = 12;
}