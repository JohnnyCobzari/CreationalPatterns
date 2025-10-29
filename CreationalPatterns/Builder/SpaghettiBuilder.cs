namespace CreationalPatterns.Builder;

public class SpaghettiBuilder : PastaBuilder
{
    public override void SetType() => pasta.Type = "Spaghetti";
    public override void AddSauce() => pasta.Sauce = "Tomato Basil Sauce";
    public override void SetCookingTime() => pasta.CookingTime = 8;
}