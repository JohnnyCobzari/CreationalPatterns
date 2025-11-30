namespace CreationalPatterns.Behavioral.State;

/// <summary>
/// Initial state - Order has been created but not yet placed
/// </summary>
public class PendingState : IOrderState
{
    public void PlaceOrder(OrderContext context)
    {
        Console.WriteLine("📝 Order placed successfully!");
        Console.WriteLine("   Sending to kitchen...");
        Thread.Sleep(500);
        context.SetState(new PreparingState());
    }

    public void PrepareOrder(OrderContext context)
    {
        Console.WriteLine("❌ Cannot prepare order. Order must be placed first.");
    }

    public void CompletePreparation(OrderContext context)
    {
        Console.WriteLine("❌ Cannot complete preparation. Order hasn't been started yet.");
    }

    public void ServeOrder(OrderContext context)
    {
        Console.WriteLine("❌ Cannot serve order. Order must be prepared first.");
    }

    public void CompleteOrder(OrderContext context)
    {
        Console.WriteLine("❌ Cannot complete order. Order must be placed and served first.");
    }

    public void CancelOrder(OrderContext context)
    {
        Console.WriteLine("🚫 Order cancelled before placement.");
        context.SetState(new CancelledState());
    }

    public string GetStateName()
    {
        return "Pending";
    }

    public string GetStateSymbol()
    {
        return "⏳";
    }
}
