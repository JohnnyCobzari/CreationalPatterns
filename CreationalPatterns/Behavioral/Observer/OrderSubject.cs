using CreationalPatterns.Behavioral.State;

namespace CreationalPatterns.Behavioral.Observer;

/// <summary>
/// Subject class that maintains a list of observers and notifies them of state changes
/// Wraps OrderContext to add observer functionality
/// </summary>
public class OrderSubject
{
    private readonly List<IOrderObserver> _observers = new();
    private readonly OrderContext _orderContext;

    public OrderSubject(OrderContext orderContext)
    {
        _orderContext = orderContext;
    }

    /// <summary>
    /// Get the underlying order context
    /// </summary>
    public OrderContext GetOrderContext() => _orderContext;

    /// <summary>
    /// Attach an observer to receive notifications
    /// </summary>
    public void Attach(IOrderObserver observer)
    {
        if (!_observers.Contains(observer))
        {
            _observers.Add(observer);
            Console.WriteLine($"✅ Subscribed: {observer.GetObserverName()}");
        }
    }

    /// <summary>
    /// Detach an observer from receiving notifications
    /// </summary>
    public void Detach(IOrderObserver observer)
    {
        if (_observers.Contains(observer))
        {
            _observers.Remove(observer);
            Console.WriteLine($"❌ Unsubscribed: {observer.GetObserverName()}");
        }
    }

    /// <summary>
    /// Notify all observers about a state change
    /// </summary>
    public void Notify(string message)
    {
        Console.WriteLine($"\n{'=',60}");
        Console.WriteLine($"  📢 BROADCASTING TO {_observers.Count} OBSERVER(S)");
        Console.WriteLine($"{'=',60}");

        foreach (var observer in _observers)
        {
            observer.Update(_orderContext, message);
        }

        Console.WriteLine($"\n{'=',60}");
    }

    /// <summary>
    /// Place order and notify observers
    /// </summary>
    public void PlaceOrder()
    {
        _orderContext.PlaceOrder();
        Notify("Order has been placed");
    }

    /// <summary>
    /// Prepare order and notify observers
    /// </summary>
    public void PrepareOrder()
    {
        _orderContext.PrepareOrder();
        Notify("Order preparation started");
    }

    /// <summary>
    /// Complete preparation and notify observers
    /// </summary>
    public void CompletePreparation()
    {
        _orderContext.CompletePreparation();
        Notify("Order preparation completed");
    }

    /// <summary>
    /// Serve order and notify observers
    /// </summary>
    public void ServeOrder()
    {
        _orderContext.ServeOrder();
        Notify("Order has been served");
    }

    /// <summary>
    /// Complete order and notify observers
    /// </summary>
    public void CompleteOrder()
    {
        _orderContext.CompleteOrder();
        Notify("Order has been completed");
    }

    /// <summary>
    /// Cancel order and notify observers
    /// </summary>
    public void CancelOrder()
    {
        _orderContext.CancelOrder();
        Notify("Order has been cancelled");
    }

    /// <summary>
    /// Display status
    /// </summary>
    public void DisplayStatus()
    {
        _orderContext.DisplayStatus();
    }

    /// <summary>
    /// Display all subscribed observers
    /// </summary>
    public void DisplayObservers()
    {
        Console.WriteLine("\n╔════════════════════════════════════════╗");
        Console.WriteLine("║      SUBSCRIBED OBSERVERS              ║");
        Console.WriteLine("╠════════════════════════════════════════╣");

        if (_observers.Count == 0)
        {
            Console.WriteLine("║  No observers subscribed               ║");
        }
        else
        {
            for (int i = 0; i < _observers.Count; i++)
            {
                Console.WriteLine($"║  {i + 1}. {_observers[i].GetObserverName(),-35} ║");
            }
        }

        Console.WriteLine("╚════════════════════════════════════════╝");
    }
}
