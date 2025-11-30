namespace CreationalPatterns.Behavioral.Strategy;

/// <summary>
/// Strategy interface defining the payment processing algorithm
/// </summary>
public interface IPaymentStrategy
{
    /// <summary>
    /// Process payment for the given amount
    /// </summary>
    /// <param name="amount">The total amount to be paid</param>
    /// <returns>True if payment was successful, false otherwise</returns>
    bool ProcessPayment(decimal amount);

    /// <summary>
    /// Get the name of this payment method
    /// </summary>
    string GetPaymentMethodName();
}
