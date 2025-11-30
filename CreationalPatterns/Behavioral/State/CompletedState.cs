namespace CreationalPatterns.Behavioral.State;

/// <summary>
/// Final state - Order has been completed and paid for
/// </summary>
public class CompletedState : IOrderState
{
    public void PlaceOrder(OrderContext context)
    {
        Console.WriteLine("❌ Order is already completed.");
    }

    public void PrepareOrder(OrderContext context)
    {
        Console.WriteLine("❌ Order is already completed.");
    }

    public void CompletePreparation(OrderContext context)
    {
        Console.WriteLine("❌ Order is already completed.");
    }

    public void ServeOrder(OrderContext context)
    {
        Console.WriteLine("❌ Order is already completed.");
    }

    public void CompleteOrder(OrderContext context)
    {
        Console.WriteLine("✅ Order was already completed.");
    }

    public void CancelOrder(OrderContext context)
    {
        Console.WriteLine("❌ Cannot cancel a completed order.");
        Console.WriteLine("   Please contact manager for refund.");
    }

    public string GetStateName()
    {
        return "Completed";
    }

    public string GetStateSymbol()
    {
        return "✔️";
    }
}
