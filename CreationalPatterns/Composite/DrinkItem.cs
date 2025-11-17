namespace CreationalPatterns.Composite
{

    public class DrinkItem : IMenuItem
    {
        private readonly string _name;
        private readonly decimal _price;
        private readonly string _description;

        public DrinkItem(string name, decimal price, string description)
        {
            _name = name;
            _price = price;
            _description = description;
        }

        public string GetName()
        {
            return _name;
        }

        public decimal GetPrice()
        {
            return _price;
        }

        public string GetDescription()
        {
            return _description;
        }

        public void Display(int indent = 0)
        {
            string indentation = new string(' ', indent * 2);
            Console.WriteLine($"{indentation}🥤 {_name}");
            Console.WriteLine($"{indentation}   {_description}");
            Console.WriteLine($"{indentation}   Price: ${_price:F2}");
        }
        
        public static DrinkItem CreateDrink(int choice)
        {
            return choice switch
            {
                1 => new DrinkItem("Sparkling Water", 2.50m, "Refreshing sparkling mineral water"),
                2 => new DrinkItem("Italian Soda", 3.50m, "Sweet Italian soda with various flavors"),
                3 => new DrinkItem("House Wine", 8.00m, "Glass of our signature house wine"),
                4 => new DrinkItem("Espresso", 3.00m, "Strong Italian espresso"),
                5 => new DrinkItem("Lemonade", 2.99m, "Fresh homemade lemonade"),
                _ => new DrinkItem("Water", 0.00m, "Complimentary water")
            };
        }
    }
}
