namespace CreationalPatterns.Decorator
{

    public class HerbDecorator : PastaDecorator
    {
        private const decimal HerbPrice = 1.00m;
        private readonly string _herbType;
        
        public HerbDecorator(IPastaComponent pastaComponent, string herbType = "Fresh Basil")
            : base(pastaComponent)
        {
            _herbType = herbType;
        }

        public override string GetDescription()
        {
            return $"{base.GetDescription()}, {_herbType}";
        }

        public override decimal GetPrice()
        {
            return base.GetPrice() + HerbPrice;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"🌿 + {_herbType} (+${HerbPrice:F2})");
        }
    }
}
