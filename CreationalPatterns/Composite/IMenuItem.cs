
namespace CreationalPatterns.Composite
{

    public interface IMenuItem
    {

        string GetName();

        decimal GetPrice();
        
        void Display(int indent = 0);

        string GetDescription();
    }
}
