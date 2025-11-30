namespace CreationalPatterns.Behavioral.State;

/// <summary>
/// Order is being prepared in the kitchen
/// </summary>
public class PreparingState : IOrderState
{
    public void PlaceOrder(OrderContext context)
    {
        Console.WriteLine("❌ Order is already placed and being prepared.");
    }

    public void PrepareOrder(OrderContext context)
    {
        Console.WriteLine("👨‍🍳 Order is already being prepared in the kitchen...");
    }

    public void CompletePreparation(OrderContext context)
    {
        Console.WriteLine("✅ Order preparation complete!");
        Console.WriteLine("   Moving to serving station...");
        Thread.Sleep(500);
        context.SetState(new ReadyState());
    }

    public void ServeOrder(OrderContext context)
    {
        Console.WriteLine("❌ Cannot serve order. Still being prepared.");
    }

    public void CompleteOrder(OrderContext context)
    {
        Console.WriteLine("❌ Cannot complete order. Must be served first.");
    }

    public void CancelOrder(OrderContext context)
    {
        Console.WriteLine("🚫 Order cancelled during preparation.");
        Console.WriteLine("   Discarding ingredients...");
        Thread.Sleep(300);
        context.SetState(new CancelledState());
    }

    public string GetStateName()
    {
        return "Preparing";
    }

    public string GetStateSymbol()
    {
        return "👨‍🍳";
    }
}
