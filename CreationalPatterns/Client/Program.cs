using CreationalPatterns.Domain;
using CreationalPatterns.Factory;
using CreationalPatterns.Models;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("👨‍🍳 Welcome to Johnny's Pasta Palace!");
        Thread.Sleep(800);

        Console.Write("Would you like to order something? (y/n): ");
        string? answer = Console.ReadLine()?.Trim().ToLower();

        if (answer != "y")
        {
            Console.WriteLine("Okay! Come back when you’re hungry 😄");
            return;
        }

        var menu = RestaurantMenu.Instance;
        Console.WriteLine("\n🧾 Here’s our delicious pasta menu:");
        Thread.Sleep(1000);
        menu.ShowMenu();

        Console.Write("\nPlease select your pasta (1-3): ");
        string? choice = Console.ReadLine();
        AbstractOrderFactory? factory = choice switch
        {
            "1" => new SpaghettiFactory(),
            "2" => new PenneFactory(),
            "3" => new FettuccineFactory(),
            _ => null
        };

        if (factory == null)
        {
            Console.WriteLine("❌ Invalid choice. Order canceled.");
            return;
        }

        Console.WriteLine("\n✅ Preparing your order...");
        Thread.Sleep(1000);
        Console.Write("👨‍🍳 The chef is cooking");
        for (int i = 0; i < 5; i++)
        {
            Thread.Sleep(600);
            Console.Write(".");
        }

        Console.WriteLine("\n\n🍝 Cooking complete! Plating your pasta...");
        Thread.Sleep(1000);

        Order order = factory.CreateOrder();

        Thread.Sleep(800);
        Console.WriteLine($"\n🍽️ Here is your meal! (Order #{order.OrderId})\n");
        order.PreparedPasta?.Show();

        Thread.Sleep(800);
        Console.WriteLine("\nThank you for dining with us! 🙏 Have a great day!");
    }
}