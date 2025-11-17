namespace CreationalPatterns.Decorator
{

    public abstract class PastaDecorator : IPastaComponent
    {
        protected readonly IPastaComponent _pastaComponent;

        protected PastaDecorator(IPastaComponent pastaComponent)
        {
            _pastaComponent = pastaComponent;
        }

        public virtual string GetDescription()
        {
            return _pastaComponent.GetDescription();
        }
        
        public virtual decimal GetPrice()
        {
            return _pastaComponent.GetPrice();
        }

        public virtual void Display()
        {
            _pastaComponent.Display();
        }
    }
}
