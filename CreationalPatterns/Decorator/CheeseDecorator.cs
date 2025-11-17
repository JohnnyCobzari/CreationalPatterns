namespace CreationalPatterns.Decorator
{
    public class CheeseDecorator : PastaDecorator
    {
        private const decimal CheesePrice = 2.00m;
        private readonly string _cheeseType;
        public CheeseDecorator(IPastaComponent pastaComponent, string cheeseType = "Parmesan")
            : base(pastaComponent)
        {
            _cheeseType = cheeseType;
        }

        public override string GetDescription()
        {
            return $"{base.GetDescription()}, Extra {_cheeseType} Cheese";
        }

        public override decimal GetPrice()
        {
            return base.GetPrice() + CheesePrice;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"🧀 + Extra {_cheeseType} Cheese (+${CheesePrice:F2})");
        }
    }
}
