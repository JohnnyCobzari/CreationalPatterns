namespace CreationalPatterns.Behavioral.Strategy;

/// <summary>
/// Context class that uses a payment strategy
/// Allows switching between different payment methods at runtime
/// </summary>
public class PaymentContext
{
    private IPaymentStrategy? _paymentStrategy;

    /// <summary>
    /// Set the payment strategy to use
    /// </summary>
    public void SetPaymentStrategy(IPaymentStrategy strategy)
    {
        _paymentStrategy = strategy;
    }

    /// <summary>
    /// Execute payment using the selected strategy
    /// </summary>
    public bool ExecutePayment(decimal amount)
    {
        if (_paymentStrategy == null)
        {
            Console.WriteLine("❌ No payment method selected.");
            return false;
        }

        Console.WriteLine($"\n{'═',50}");
        Console.WriteLine($"  PAYMENT PROCESSING - {_paymentStrategy.GetPaymentMethodName()}");
        Console.WriteLine($"{'═',50}");

        bool success = _paymentStrategy.ProcessPayment(amount);

        if (success)
        {
            Console.WriteLine($"\n{'═',50}");
            Console.WriteLine("  Thank you for your payment!");
            Console.WriteLine($"{'═',50}");
        }
        else
        {
            Console.WriteLine("\n❌ Payment failed. Please try again.");
        }

        return success;
    }

    /// <summary>
    /// Display available payment methods
    /// </summary>
    public static void DisplayPaymentOptions()
    {
        Console.WriteLine("\n╔════════════════════════════════════╗");
        Console.WriteLine("║     PAYMENT METHOD SELECTION       ║");
        Console.WriteLine("╠════════════════════════════════════╣");
        Console.WriteLine("║  1. 💵 Cash                        ║");
        Console.WriteLine("║  2. 💳 Credit Card                 ║");
        Console.WriteLine("║  3. 📱 Apple Pay                   ║");
        Console.WriteLine("║  4. 📱 Google Pay                  ║");
        Console.WriteLine("╚════════════════════════════════════╝");
    }

    /// <summary>
    /// Get payment strategy based on user choice
    /// </summary>
    public static IPaymentStrategy? GetPaymentStrategyFromChoice(string choice)
    {
        return choice switch
        {
            "1" => new CashPaymentStrategy(),
            "2" => new CreditCardPaymentStrategy(),
            "3" => new MobilePaymentStrategy("Apple Pay"),
            "4" => new MobilePaymentStrategy("Google Pay"),
            _ => null
        };
    }
}
