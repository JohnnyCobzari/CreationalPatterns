namespace CreationalPatterns.Composite
{

    public class ComplexOrder : IMenuItem
    {
        private readonly int _orderId;
        private readonly List<IMenuItem> _items;
        private readonly DateTime _orderTime;
        public ComplexOrder(int orderId)
        {
            _orderId = orderId;
            _items = new List<IMenuItem>();
            _orderTime = DateTime.Now;
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

        public int GetItemCount()
        {
            return _items.Count;
        }

        public string GetName()
        {
            return $"Order #{_orderId}";
        }

        public decimal GetPrice()
        {
            return _items.Sum(item => item.GetPrice());
        }

        public string GetDescription()
        {
            return $"{_items.Count} item(s) - Total: ${GetPrice():F2}";
        }

        public void Display(int indent = 0)
        {
            string indentation = new string(' ', indent * 2);
            Console.WriteLine($"\n{indentation}╔════════════════════════════════════════════╗");
            Console.WriteLine($"{indentation}║  📋 ORDER #{_orderId}");
            Console.WriteLine($"{indentation}║  🕐 Time: {_orderTime:HH:mm:ss}");
            Console.WriteLine($"{indentation}╚════════════════════════════════════════════╝\n");

            if (_items.Count == 0)
            {
                Console.WriteLine($"{indentation}  (Empty order)");
            }
            else
            {
                for (int i = 0; i < _items.Count; i++)
                {
                    Console.WriteLine($"{indentation}  Item {i + 1}:");
                    _items[i].Display(indent + 1);

                    if (i < _items.Count - 1)
                    {
                        Console.WriteLine($"{indentation}  {new string('─', 40)}");
                    }
                }
            }

            Console.WriteLine($"\n{indentation}  ╔════════════════════════════════════════╗");
            Console.WriteLine($"{indentation}  ║  💵 TOTAL: ${GetPrice():F2}");
            Console.WriteLine($"{indentation}  ╚════════════════════════════════════════╝");
        }


        public int GetOrderId()
        {
            return _orderId;
        }

        public DateTime GetOrderTime()
        {
            return _orderTime;
        }
    }
}
