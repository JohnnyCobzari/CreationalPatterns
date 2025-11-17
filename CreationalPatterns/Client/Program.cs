using CreationalPatterns.Facade;
using CreationalPatterns.Composite;
using System.Threading;

class Program
{
    static int _orderCounter = 1;

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Create the Facade to simplify interactions
        var restaurantFacade = new RestaurantOrderFacade();

        Console.WriteLine("👨‍🍳 Welcome to Johnny's Pasta Palace!");
        Thread.Sleep(800);

        Console.Write("Would you like to order something? (y/n): ");
        string? answer = Console.ReadLine()?.Trim().ToLower();

        if (answer != "y")
        {
            Console.WriteLine("Okay! Come back when you're hungry 😄");
            return;
        }

        // Ask if user wants a combo meal or individual items
        Console.WriteLine("\n🎯 What would you like to order?");
        Console.WriteLine("1. Single pasta dish");
        Console.WriteLine("2. Combo meal (Pasta + Drink + Dessert with discount!)");
        Console.WriteLine("3. Complex order (Multiple items)");
        Console.Write("\nYour choice (1-3): ");
        string? orderType = Console.ReadLine();

        if (orderType == "1")
        {
            // Single pasta order (original flow)
            OrderSinglePasta(restaurantFacade);
        }
        else if (orderType == "2")
        {
            // Combo meal order (Composite Pattern)
            OrderComboMeal(restaurantFacade);
        }
        else if (orderType == "3")
        {
            // Complex order (Composite Pattern)
            OrderComplexOrder(restaurantFacade);
        }
        else
        {
            Console.WriteLine("❌ Invalid choice. Order canceled.");
            return;
        }

        Thread.Sleep(800);
        Console.WriteLine("\nThank you for dining with us! 🙏 Have a great day!");
    }

  
    static void OrderSinglePasta(RestaurantOrderFacade facade)
    {
        facade.ShowMenu();

        Console.Write("\nPlease select your pasta (1-3): ");
        string? choice = Console.ReadLine();

        var order = facade.CreatePastaOrder(choice ?? "");

        if (order == null)
        {
            Console.WriteLine("❌ Invalid choice. Order canceled.");
            return;
        }

        facade.ShowToppingsMenu();

        Console.Write("\nEnter topping numbers separated by commas (e.g., 1,3,4) or 0 for none: ");
        string? toppingsInput = Console.ReadLine();

        var toppingChoices = facade.ParseToppingInput(toppingsInput);
        if (toppingChoices.Count > 0)
        {
            facade.ApplyToppings(order, toppingChoices);
        }

        facade.DisplayOrderSummary(order);
    }

    static void OrderComboMeal(RestaurantOrderFacade facade)
    {
        Console.WriteLine("\n🎁 COMBO MEAL OPTIONS:");
        Console.WriteLine("1. Quick Lunch Combo (10% off) - Pasta + Drink");
        Console.WriteLine("2. Classic Dinner Combo (15% off) - Pasta + Drink + Dessert");
        Console.WriteLine("3. Deluxe Combo (20% off) - Pasta with extras + Drink + Dessert");
        Console.Write("\nSelect combo (1-3): ");
        string? comboChoice = Console.ReadLine();

        int comboType = int.TryParse(comboChoice, out int c) ? c : 0;
        var combo = ComboMeal.CreateCombo(comboType);

        // Order pasta
        facade.ShowMenu();
        Console.Write("\nSelect your pasta for the combo (1-3): ");
        string? pastaChoice = Console.ReadLine();

        var order = facade.CreatePastaOrder(pastaChoice ?? "");
        if (order == null)
        {
            Console.WriteLine("❌ Invalid choice. Order canceled.");
            return;
        }

        // Add toppings
        facade.ShowToppingsMenu();
        Console.Write("\nEnter topping numbers or 0 for none: ");
        string? toppingsInput = Console.ReadLine();
        var toppingChoices = facade.ParseToppingInput(toppingsInput);
        if (toppingChoices.Count > 0)
        {
            facade.ApplyToppings(order, toppingChoices);
        }

        // Add pasta to combo
        combo.AddItem(new PastaItem(order));

        // Order drink
        Console.WriteLine("\n🥤 SELECT YOUR DRINK:");
        Console.WriteLine("1. Sparkling Water - $2.50");
        Console.WriteLine("2. Italian Soda - $3.50");
        Console.WriteLine("3. House Wine - $8.00");
        Console.WriteLine("4. Espresso - $3.00");
        Console.WriteLine("5. Lemonade - $2.99");
        Console.Write("Select drink (1-5): ");
        string? drinkChoice = Console.ReadLine();
        int drinkNum = int.TryParse(drinkChoice, out int d) ? d : 0;
        combo.AddItem(DrinkItem.CreateDrink(drinkNum));

        // Order dessert (for dinner and deluxe combos)
        if (comboType >= 2)
        {
            Console.WriteLine("\n🍰 SELECT YOUR DESSERT:");
            Console.WriteLine("1. Tiramisu - $6.99");
            Console.WriteLine("2. Gelato - $5.50");
            Console.WriteLine("3. Panna Cotta - $6.50");
            Console.WriteLine("4. Cannoli - $5.99");
            Console.WriteLine("5. Chocolate Lava Cake - $7.50");
            Console.Write("Select dessert (1-5): ");
            string? dessertChoice = Console.ReadLine();
            int dessertNum = int.TryParse(dessertChoice, out int des) ? des : 0;
            combo.AddItem(DessertItem.CreateDessert(dessertNum));
        }

        // Display combo summary
        Thread.Sleep(800);
        Console.WriteLine("\n═══════════════════════════════════════════════");
        Console.WriteLine("           YOUR COMBO MEAL");
        Console.WriteLine("═══════════════════════════════════════════════");
        combo.Display();
        Console.WriteLine("═══════════════════════════════════════════════");
    }

    /// <summary>
    /// Handles ordering multiple items (Composite Pattern).
    /// </summary>
    static void OrderComplexOrder(RestaurantOrderFacade facade)
    {
        var complexOrder = new ComplexOrder(_orderCounter++);

        bool orderingMore = true;
        while (orderingMore)
        {
            Console.WriteLine("\n📋 ADD ITEM TO ORDER:");
            Console.WriteLine("1. Add Pasta");
            Console.WriteLine("2. Add Drink");
            Console.WriteLine("3. Add Dessert");
            Console.WriteLine("0. Finish order");
            Console.Write("Your choice: ");
            string? itemChoice = Console.ReadLine();

            switch (itemChoice)
            {
                case "1":
                    // Add pasta
                    facade.ShowMenu();
                    Console.Write("\nSelect pasta (1-3): ");
                    string? pastaChoice = Console.ReadLine();
                    var order = facade.CreatePastaOrder(pastaChoice ?? "");
                    if (order != null)
                    {
                        facade.ShowToppingsMenu();
                        Console.Write("\nEnter toppings or 0 for none: ");
                        string? toppingsInput = Console.ReadLine();
                        var toppingChoices = facade.ParseToppingInput(toppingsInput);
                        if (toppingChoices.Count > 0)
                        {
                            facade.ApplyToppings(order, toppingChoices);
                        }
                        complexOrder.AddItem(new PastaItem(order));
                        Console.WriteLine("✅ Pasta added to order!");
                    }
                    break;

                case "2":
                    // Add drink
                    Console.WriteLine("\n🥤 SELECT DRINK:");
                    Console.WriteLine("1. Sparkling Water - $2.50");
                    Console.WriteLine("2. Italian Soda - $3.50");
                    Console.WriteLine("3. House Wine - $8.00");
                    Console.WriteLine("4. Espresso - $3.00");
                    Console.WriteLine("5. Lemonade - $2.99");
                    Console.Write("Select (1-5): ");
                    string? drinkChoice = Console.ReadLine();
                    int drinkNum = int.TryParse(drinkChoice, out int d) ? d : 0;
                    complexOrder.AddItem(DrinkItem.CreateDrink(drinkNum));
                    Console.WriteLine("✅ Drink added to order!");
                    break;

                case "3":
                    // Add dessert
                    Console.WriteLine("\n🍰 SELECT DESSERT:");
                    Console.WriteLine("1. Tiramisu - $6.99");
                    Console.WriteLine("2. Gelato - $5.50");
                    Console.WriteLine("3. Panna Cotta - $6.50");
                    Console.WriteLine("4. Cannoli - $5.99");
                    Console.WriteLine("5. Chocolate Lava Cake - $7.50");
                    Console.Write("Select (1-5): ");
                    string? dessertChoice = Console.ReadLine();
                    int dessertNum = int.TryParse(dessertChoice, out int des) ? des : 0;
                    complexOrder.AddItem(DessertItem.CreateDessert(dessertNum));
                    Console.WriteLine("✅ Dessert added to order!");
                    break;

                case "0":
                    orderingMore = false;
                    break;

                default:
                    Console.WriteLine("❌ Invalid choice.");
                    break;
            }
        }

        // Display complex order summary
        if (complexOrder.GetItemCount() > 0)
        {
            Thread.Sleep(800);
            complexOrder.Display();
        }
        else
        {
            Console.WriteLine("\n❌ No items in order.");
        }
    }
}