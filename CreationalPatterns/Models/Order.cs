using CreationalPatterns.Decorator;

namespace CreationalPatterns.Models;

public class Order
{
    public int OrderId { get; set; }
    public string PastaType { get; set; } = "";
    public Pasta? PreparedPasta { get; set; }

    /// <summary>
    /// The decorated pasta component with all toppings applied (Decorator Pattern).
    /// </summary>
    public IPastaComponent? DecoratedPasta { get; set; }

    /// <summary>
    /// Gets the total price of the order including all decorations.
    /// </summary>
    public decimal GetTotalPrice()
    {
        return DecoratedPasta?.GetPrice() ?? 0m;
    }
    
    public string GetFullDescription()
    {
        return DecoratedPasta?.GetDescription() ?? PastaType;
    }
}