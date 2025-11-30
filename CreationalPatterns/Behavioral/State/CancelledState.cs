namespace CreationalPatterns.Behavioral.State;

/// <summary>
/// Terminal state - Order has been cancelled
/// </summary>
public class CancelledState : IOrderState
{
    public void PlaceOrder(OrderContext context)
    {
        Console.WriteLine("❌ Cannot place a cancelled order.");
    }

    public void PrepareOrder(OrderContext context)
    {
        Console.WriteLine("❌ Cannot prepare a cancelled order.");
    }

    public void CompletePreparation(OrderContext context)
    {
        Console.WriteLine("❌ Cannot complete a cancelled order.");
    }

    public void ServeOrder(OrderContext context)
    {
        Console.WriteLine("❌ Cannot serve a cancelled order.");
    }

    public void CompleteOrder(OrderContext context)
    {
        Console.WriteLine("❌ Cannot complete a cancelled order.");
    }

    public void CancelOrder(OrderContext context)
    {
        Console.WriteLine("⚠️  Order is already cancelled.");
    }

    public string GetStateName()
    {
        return "Cancelled";
    }

    public string GetStateSymbol()
    {
        return "🚫";
    }
}
