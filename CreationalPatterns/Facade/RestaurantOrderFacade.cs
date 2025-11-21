using CreationalPatterns.Domain;
using CreationalPatterns.Factory;
using CreationalPatterns.Models;
using CreationalPatterns.Decorator;

namespace CreationalPatterns.Facade
{

    public class RestaurantOrderFacade
    {
        private readonly Dictionary<string, decimal> _basePrices = new()
        {
            { "1", 12.99m },  // Spaghetti
            { "2", 13.99m },  // Penne
            { "3", 14.99m }   // Fettuccine
        };

        public void ShowMenu()
        {
            var menu = RestaurantMenu.Instance;
            Console.WriteLine("\n🧾 Here's our delicious pasta menu:");
            Thread.Sleep(1000);
            menu.ShowMenu();
        }
        
        public Order? CreatePastaOrder(string choice)
        {
            AbstractOrderFactory? factory = choice switch
            {
                "1" => new SpaghettiFactory(),
                "2" => new PenneFactory(),
                "3" => new FettuccineFactory(),
                _ => null
            };

            if (factory == null)
            {
                return null;
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

            decimal basePrice = _basePrices.GetValueOrDefault(choice, 12.99m);
            IPastaComponent pastaComponent = new BasePasta(order.PreparedPasta!, basePrice);
            order.DecoratedPasta = pastaComponent;

            return order;
        }

        public void ApplyToppings(Order order, List<string> toppingChoices)
        {
            if (order.DecoratedPasta == null)
            {
                return;
            }

            IPastaComponent pastaComponent = order.DecoratedPasta;

            Console.WriteLine("\n✨ Adding your toppings...");
            Thread.Sleep(800);

            foreach (var topping in toppingChoices)
            {
                pastaComponent = topping switch
                {
                    "1" => new CheeseDecorator(pastaComponent, "Parmesan"),
                    "2" => new HerbDecorator(pastaComponent, "Fresh Basil"),
                    "3" => new VegetableDecorator(pastaComponent, "Grilled Vegetables"),
                    "4" => AskProteinType(pastaComponent),
                    "5" => new SpicyDecorator(pastaComponent, "Chili Flakes"),
                    _ => pastaComponent
                };
            }

            order.DecoratedPasta = pastaComponent;
        }
        
        public void ShowToppingsMenu()
        {
            Console.WriteLine("\n🎨 Would you like to customize your pasta with toppings?");
            Thread.Sleep(500);
            Console.WriteLine("\nAvailable toppings:");
            Console.WriteLine("1. 🧀 Extra Cheese (Parmesan/Mozzarella) - $2.00");
            Console.WriteLine("2. 🌿 Fresh Herbs (Basil/Oregano) - $1.00");
            Console.WriteLine("3. 🥕 Grilled Vegetables - $3.00");
            Console.WriteLine("4. 🍗 Protein (Chicken/Shrimp) - $5.00");
            Console.WriteLine("5. 🌶️  Spicy (Chili Flakes/Hot Sauce) - $0.50");
            Console.WriteLine("0. No toppings, just the pasta");
        }
        
        public List<string> ParseToppingInput(string? input)
        {
            if (string.IsNullOrWhiteSpace(input) || input.Trim() == "0")
            {
                return new List<string>();
            }

            return input.Split(',')
                .Select(t => t.Trim())
                .Where(t => !string.IsNullOrEmpty(t) && t != "0")
                .ToList();
        }

        /// <summary>
        /// Displays the drink menu.
        /// </summary>
        public void ShowDrinkMenu()
        {
            Console.WriteLine("\n🥤 SELECT YOUR DRINK:");
            Console.WriteLine("1. Sparkling Water - $2.50");
            Console.WriteLine("2. Italian Soda - $3.50");
            Console.WriteLine("3. House Wine - $8.00");
            Console.WriteLine("4. Espresso - $3.00");
            Console.WriteLine("5. Lemonade - $2.99");
        }

        /// <summary>
        /// Displays the dessert menu.
        /// </summary>
        public void ShowDessertMenu()
        {
            Console.WriteLine("\n🍰 SELECT YOUR DESSERT:");
            Console.WriteLine("1. Tiramisu - $6.99");
            Console.WriteLine("2. Gelato - $5.50");
            Console.WriteLine("3. Panna Cotta - $6.50");
            Console.WriteLine("4. Cannoli - $5.99");
            Console.WriteLine("5. Chocolate Lava Cake - $7.50");
        }

        public void DisplayOrderSummary(Order order)
        {
            Thread.Sleep(800);
            Console.WriteLine($"\n🍽️ Here is your customized meal! (Order #{order.OrderId})\n");
            Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
            order.DecoratedPasta?.Display();
            Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
            Console.WriteLine($"\n💵 TOTAL PRICE: ${order.GetTotalPrice():F2}");
        }

        private IPastaComponent AskProteinType(IPastaComponent pastaComponent)
        {
            Console.Write("   Choose protein (1=Chicken, 2=Shrimp): ");
            string? proteinChoice = Console.ReadLine();
            string proteinType = proteinChoice == "2" ? "Grilled Shrimp" : "Grilled Chicken";
            return new ProteinDecorator(pastaComponent, proteinType);
        }
    }
}
