namespace CreationalPatterns.Composite
{

    public class ComboMeal : IMenuItem
    {
        private readonly string _name;
        private readonly List<IMenuItem> _items;
        private readonly decimal _discount;

        public ComboMeal(string name, decimal discount = 0)
        {
            _name = name;
            _items = new List<IMenuItem>();
            _discount = discount;
        }

        public void AddItem(IMenuItem item)
        {
            _items.Add(item);
        }

        public void RemoveItem(IMenuItem item)
        {
            _items.Remove(item);
        }


        public List<IMenuItem> GetItems()
        {
            return new List<IMenuItem>(_items);
        }

        public string GetName()
        {
            return _name;
        }

        public decimal GetPrice()
        {
            decimal totalPrice = _items.Sum(item => item.GetPrice());
            decimal discountAmount = totalPrice * _discount;
            return totalPrice - discountAmount;
        }

        public string GetDescription()
        {
            var itemNames = _items.Select(item => item.GetName());
            string description = string.Join(", ", itemNames);

            if (_discount > 0)
            {
                description += $" (Save {_discount * 100}%!)";
            }

            return description;
        }

        public void Display(int indent = 0)
        {
            string indentation = new string(' ', indent * 2);
            Console.WriteLine($"{indentation}🎁 {_name}");

            if (_discount > 0)
            {
                Console.WriteLine($"{indentation}   💰 Special Combo - Save {_discount * 100}%!");
            }

            foreach (var item in _items)
            {
                item.Display(indent + 1);
            }

            if (_discount > 0)
            {
                decimal originalPrice = _items.Sum(item => item.GetPrice());
                Console.WriteLine($"{indentation}   Original Price: ${originalPrice:F2}");
                Console.WriteLine($"{indentation}   Discount: -${originalPrice * _discount:F2}");
            }

            Console.WriteLine($"{indentation}   Total: ${GetPrice():F2}");
        }

        public static ComboMeal CreateCombo(int choice)
        {
            return choice switch
            {
                1 => CreateQuickLunchCombo(),
                2 => CreateClassicDinnerCombo(),
                3 => CreateDeluxeCombo(),
                _ => new ComboMeal("Custom Combo", 0)
            };
        }

        private static ComboMeal CreateQuickLunchCombo()
        {
            var combo = new ComboMeal("Quick Lunch Combo", 0.10m);
            return combo;
        }

        private static ComboMeal CreateClassicDinnerCombo()
        {
            var combo = new ComboMeal("Classic Dinner Combo", 0.15m);
            return combo;
        }

        private static ComboMeal CreateDeluxeCombo()
        {
            var combo = new ComboMeal("Deluxe Combo", 0.20m);
            return combo;
        }
    }
}
