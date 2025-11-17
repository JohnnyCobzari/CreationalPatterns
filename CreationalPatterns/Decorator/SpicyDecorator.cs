namespace CreationalPatterns.Decorator
{

    public class SpicyDecorator : PastaDecorator
    {
        private const decimal SpicyPrice = 0.50m;
        private readonly string _spiceType;

        public SpicyDecorator(IPastaComponent pastaComponent, string spiceType = "Chili Flakes")
            : base(pastaComponent)
        {
            _spiceType = spiceType;
        }

        public override string GetDescription()
        {
            return $"{base.GetDescription()}, {_spiceType}";
        }

        public override decimal GetPrice()
        {
            return base.GetPrice() + SpicyPrice;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"🌶️  + {_spiceType} (+${SpicyPrice:F2})");
        }
    }
}
