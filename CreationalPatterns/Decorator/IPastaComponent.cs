namespace CreationalPatterns.Decorator
{

    public interface IPastaComponent
    {

        string GetDescription();

 
        decimal GetPrice();


        void Display();
    }
}
