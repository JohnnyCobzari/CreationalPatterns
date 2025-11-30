using CreationalPatterns.Models;

namespace CreationalPatterns.Behavioral.State;

/// <summary>
/// Context class that manages order state transitions
/// </summary>
public class OrderContext
{
    private IOrderState _currentState;
    private readonly Order _order;
    private readonly string _orderId;
    private readonly DateTime _createdAt;

    public OrderContext(Order order)
    {
        _order = order;
        _orderId = $"ORD{DateTime.Now:yyyyMMddHHmmss}";
        _createdAt = DateTime.Now;
        _currentState = new PendingState(); // Initial state
    }

    /// <summary>
    /// Get the order associated with this context
    /// </summary>
    public Order GetOrder() => _order;

    /// <summary>
    /// Get the order ID
    /// </summary>
    public string GetOrderId() => _orderId;

    /// <summary>
    /// Get the creation timestamp
    /// </summary>
    public DateTime GetCreatedAt() => _createdAt;

    /// <summary>
    /// Set the current state (internal use by states)
    /// </summary>
    public void SetState(IOrderState newState)
    {
        _currentState = newState;
        Console.WriteLine($"   🔄 State changed to: {newState.GetStateSymbol()} {newState.GetStateName()}");
    }

    /// <summary>
    /// Get the current state name
    /// </summary>
    public string GetCurrentStateName()
    {
        return _currentState.GetStateName();
    }

    /// <summary>
    /// Get the current state symbol
    /// </summary>
    public string GetCurrentStateSymbol()
    {
        return _currentState.GetStateSymbol();
    }

    // Delegate state operations to current state
    public void PlaceOrder() => _currentState.PlaceOrder(this);
    public void PrepareOrder() => _currentState.PrepareOrder(this);
    public void CompletePreparation() => _currentState.CompletePreparation(this);
    public void ServeOrder() => _currentState.ServeOrder(this);
    public void CompleteOrder() => _currentState.CompleteOrder(this);
    public void CancelOrder() => _currentState.CancelOrder(this);

    /// <summary>
    /// Display current order status
    /// </summary>
    public void DisplayStatus()
    {
        Console.WriteLine($"\n╔═══════════════════════════════════════╗");
        Console.WriteLine($"║        ORDER STATUS TRACKING          ║");
        Console.WriteLine($"╠═══════════════════════════════════════╣");
        Console.WriteLine($"║  Order ID: {_orderId,-24} ║");
        Console.WriteLine($"║  Created:  {_createdAt:yyyy-MM-dd HH:mm:ss,-24} ║");
        Console.WriteLine($"║  Status:   {_currentState.GetStateSymbol()} {_currentState.GetStateName(),-22} ║");
        Console.WriteLine($"╚═══════════════════════════════════════╝");
    }

    /// <summary>
    /// Display state transition diagram
    /// </summary>
    public static void DisplayStateTransitionDiagram()
    {
        Console.WriteLine("\n╔════════════════════════════════════════════════╗");
        Console.WriteLine("║      ORDER LIFECYCLE STATE DIAGRAM             ║");
        Console.WriteLine("╠════════════════════════════════════════════════╣");
        Console.WriteLine("║                                                ║");
        Console.WriteLine("║  ⏳ Pending                                    ║");
        Console.WriteLine("║      ↓ (PlaceOrder)                            ║");
        Console.WriteLine("║  👨‍🍳 Preparing                                  ║");
        Console.WriteLine("║      ↓ (CompletePreparation)                   ║");
        Console.WriteLine("║  ✅ Ready                                      ║");
        Console.WriteLine("║      ↓ (ServeOrder)                            ║");
        Console.WriteLine("║  🍽️  Served                                    ║");
        Console.WriteLine("║      ↓ (CompleteOrder - after payment)         ║");
        Console.WriteLine("║  ✔️  Completed                                 ║");
        Console.WriteLine("║                                                ║");
        Console.WriteLine("║  🚫 Cancelled (can transition from any state)  ║");
        Console.WriteLine("║                                                ║");
        Console.WriteLine("╚════════════════════════════════════════════════╝");
    }
}
