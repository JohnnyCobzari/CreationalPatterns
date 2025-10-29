namespace CreationalPatterns.Builder;

public class PenneBuilder : PastaBuilder
{
    public override void SetType() => pasta.Type = "Penne";
    public override void AddSauce() => pasta.Sauce = "Creamy Alfredo Sauce";
    public override void SetCookingTime() => pasta.CookingTime = 10;
}