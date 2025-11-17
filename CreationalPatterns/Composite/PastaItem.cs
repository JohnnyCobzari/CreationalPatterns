using CreationalPatterns.Models;
using CreationalPatterns.Decorator;

namespace CreationalPatterns.Composite
{
 
    public class PastaItem : IMenuItem
    {
        private readonly Order _order;
        
        public PastaItem(Order order)
        {
            _order = order;
        }

        public string GetName()
        {
            return _order.PastaType;
        }

        public decimal GetPrice()
        {
            return _order.GetTotalPrice();
        }

        public string GetDescription()
        {
            return _order.GetFullDescription();
        }

        public void Display(int indent = 0)
        {
            string indentation = new string(' ', indent * 2);
            Console.WriteLine($"{indentation}🍝 {GetName()}");
            Console.WriteLine($"{indentation}   {GetDescription()}");
            Console.WriteLine($"{indentation}   Price: ${GetPrice():F2}");
        }
        
        public Order GetOrder()
        {
            return _order;
        }
    }
}
