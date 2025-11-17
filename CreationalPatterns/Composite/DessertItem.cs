namespace CreationalPatterns.Composite
{

    public class DessertItem : IMenuItem
    {
        private readonly string _name;
        private readonly decimal _price;
        private readonly string _description;


        public DessertItem(string name, decimal price, string description)
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
            Console.WriteLine($"{indentation}🍰 {_name}");
            Console.WriteLine($"{indentation}   {_description}");
            Console.WriteLine($"{indentation}   Price: ${_price:F2}");
        }
        
        public static DessertItem CreateDessert(int choice)
        {
            return choice switch
            {
                1 => new DessertItem("Tiramisu", 6.99m, "Classic Italian coffee-flavored dessert"),
                2 => new DessertItem("Gelato", 5.50m, "Authentic Italian ice cream (2 scoops)"),
                3 => new DessertItem("Panna Cotta", 6.50m, "Creamy vanilla custard with berry sauce"),
                4 => new DessertItem("Cannoli", 5.99m, "Crispy pastry filled with sweet ricotta"),
                5 => new DessertItem("Chocolate Lava Cake", 7.50m, "Warm chocolate cake with molten center"),
                _ => new DessertItem("Biscotti", 3.99m, "Traditional Italian almond cookies")
            };
        }
    }
}
