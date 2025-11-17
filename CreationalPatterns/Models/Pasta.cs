namespace CreationalPatterns.Models;

public class Pasta
{
    public string Type { get; set; } = "";
    public string Sauce { get; set; } = "";
    public int CookingTime { get; set; } 

    public void Show()
    {
        Console.WriteLine($"\n🍝 Pasta ready!");
        Console.WriteLine($"Type: {Type}");
        Console.WriteLine($"Sauce: {Sauce}");
        Console.WriteLine($"Cooking Time: {CookingTime} minutes");
    }
}