namespace CreationalPatterns.Decorator
{

    public class ProteinDecorator : PastaDecorator
    {
        private const decimal ProteinPrice = 5.00m;
        private readonly string _proteinType;

        public ProteinDecorator(IPastaComponent pastaComponent, string proteinType = "Grilled Chicken")
            : base(pastaComponent)
        {
            _proteinType = proteinType;
        }

        public override string GetDescription()
        {
            return $"{base.GetDescription()}, {_proteinType}";
        }

        public override decimal GetPrice()
        {
            return base.GetPrice() + ProteinPrice;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"🍗 + {_proteinType} (+${ProteinPrice:F2})");
        }
    }
}
