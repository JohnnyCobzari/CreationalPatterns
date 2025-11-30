using CreationalPatterns.Behavioral.State;

namespace CreationalPatterns.Behavioral.Observer;

/// <summary>
/// Observer interface for receiving order status notifications
/// </summary>
public interface IOrderObserver
{
    /// <summary>
    /// Receive notification when order status changes
    /// </summary>
    /// <param name="orderContext">The order context with state information</param>
    /// <param name="message">Additional message about the state change</param>
    void Update(OrderContext orderContext, string message);

    /// <summary>
    /// Get the observer's name/type
    /// </summary>
    string GetObserverName();
}
