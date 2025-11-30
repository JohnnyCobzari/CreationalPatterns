namespace CreationalPatterns.Behavioral.State;

/// <summary>
/// Order is ready to be served
/// </summary>
public class ReadyState : IOrderState
{
    public void PlaceOrder(OrderContext context)
    {
        Console.WriteLine("❌ Order is already placed and ready.");
    }

    public void PrepareOrder(OrderContext context)
    {
        Console.WriteLine("❌ Order preparation is already complete.");
    }

    public void CompletePreparation(OrderContext context)
    {
        Console.WriteLine("✅ Order is already ready for serving.");
    }

    public void ServeOrder(OrderContext context)
    {
        Console.WriteLine("🍽️  Serving order to customer...");
        Thread.Sleep(500);
        Console.WriteLine("   Bon appétit!");
        context.SetState(new ServedState());
    }

    public void CompleteOrder(OrderContext context)
    {
        Console.WriteLine("❌ Cannot complete order. Must be served first.");
    }

    public void CancelOrder(OrderContext context)
    {
        Console.WriteLine("🚫 Order cancelled after preparation.");
        Console.WriteLine("   (Food will be discarded)");
        Thread.Sleep(300);
        context.SetState(new CancelledState());
    }

    public string GetStateName()
    {
        return "Ready";
    }

    public string GetStateSymbol()
    {
        return "✅";
    }
}
