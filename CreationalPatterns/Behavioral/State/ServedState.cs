namespace CreationalPatterns.Behavioral.State;

/// <summary>
/// Order has been served to the customer
/// </summary>
public class ServedState : IOrderState
{
    public void PlaceOrder(OrderContext context)
    {
        Console.WriteLine("❌ Order is already placed and served.");
    }

    public void PrepareOrder(OrderContext context)
    {
        Console.WriteLine("❌ Order is already prepared and served.");
    }

    public void CompletePreparation(OrderContext context)
    {
        Console.WriteLine("❌ Order preparation was already completed.");
    }

    public void ServeOrder(OrderContext context)
    {
        Console.WriteLine("✅ Order is already served to customer.");
    }

    public void CompleteOrder(OrderContext context)
    {
        Console.WriteLine("💰 Processing payment and closing order...");
        Thread.Sleep(500);
        Console.WriteLine("   Order completed successfully!");
        context.SetState(new CompletedState());
    }

    public void CancelOrder(OrderContext context)
    {
        Console.WriteLine("❌ Cannot cancel order. Already served to customer.");
        Console.WriteLine("   Please contact manager for refund.");
    }

    public string GetStateName()
    {
        return "Served";
    }

    public string GetStateSymbol()
    {
        return "🍽️";
    }
}
