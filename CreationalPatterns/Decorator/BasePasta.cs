using CreationalPatterns.Models;

namespace CreationalPatterns.Decorator
{

    public class BasePasta : IPastaComponent
    {
        private readonly Pasta _pasta;
        private readonly decimal _basePrice;
        
        public BasePasta(Pasta pasta, decimal basePrice)
        {
            _pasta = pasta;
            _basePrice = basePrice;
        }

        public string GetDescription()
        {
            return $"{_pasta.Type} with {_pasta.Sauce}";
        }

        public decimal GetPrice()
        {
            return _basePrice;
        }

        public void Display()
        {
            Console.WriteLine($"\n🍝 {_pasta.Type}");
            Console.WriteLine($"🍅 Sauce: {_pasta.Sauce}");
            Console.WriteLine($"⏱️  Cooking Time: {_pasta.CookingTime} minutes");
            Console.WriteLine($"💰 Price: ${GetPrice():F2}");
        }
        
        public Pasta GetPasta()
        {
            return _pasta;
        }
    }
}
