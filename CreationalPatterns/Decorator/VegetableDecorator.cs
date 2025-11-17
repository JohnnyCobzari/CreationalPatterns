namespace CreationalPatterns.Decorator
{

    public class VegetableDecorator : PastaDecorator
    {
        private const decimal VegetablePrice = 3.00m;
        private readonly string _vegetableType;

        public VegetableDecorator(IPastaComponent pastaComponent, string vegetableType = "Grilled Vegetables")
            : base(pastaComponent)
        {
            _vegetableType = vegetableType;
        }

        public override string GetDescription()
        {
            return $"{base.GetDescription()}, {_vegetableType}";
        }

        public override decimal GetPrice()
        {
            return base.GetPrice() + VegetablePrice;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"🥕 + {_vegetableType} (+${VegetablePrice:F2})");
        }
    }
}
