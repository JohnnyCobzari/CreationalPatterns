using CreationalPatterns.Models;

namespace CreationalPatterns.Behavioral.State;

/// <summary>
/// State interface defining order lifecycle operations
/// </summary>
public interface IOrderState
{
    /// <summary>
    /// Place the order
    /// </summary>
    void PlaceOrder(OrderContext context);

    /// <summary>
    /// Start preparing the order
    /// </summary>
    void PrepareOrder(OrderContext context);

    /// <summary>
    /// Mark order as ready
    /// </summary>
    void CompletePreparation(OrderContext context);

    /// <summary>
    /// Serve the order to the customer
    /// </summary>
    void ServeOrder(OrderContext context);

    /// <summary>
    /// Complete the order (after payment)
    /// </summary>
    void CompleteOrder(OrderContext context);

    /// <summary>
    /// Cancel the order
    /// </summary>
    void CancelOrder(OrderContext context);

    /// <summary>
    /// Get the name of this state
    /// </summary>
    string GetStateName();

    /// <summary>
    /// Get the display symbol for this state
    /// </summary>
    string GetStateSymbol();
}
