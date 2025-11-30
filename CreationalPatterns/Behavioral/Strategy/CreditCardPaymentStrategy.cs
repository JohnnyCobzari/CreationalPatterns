namespace CreationalPatterns.Behavioral.Strategy;

/// <summary>
/// Concrete strategy for credit card payments
/// </summary>
public class CreditCardPaymentStrategy : IPaymentStrategy
{
    public bool ProcessPayment(decimal amount)
    {
        Console.WriteLine($"\n💳 Processing Credit Card Payment...");
        Console.WriteLine($"Amount to charge: ${amount:F2}");

        Console.Write("Enter card number (16 digits): ");
        string? cardNumber = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(cardNumber) || cardNumber.Length != 16 || !cardNumber.All(char.IsDigit))
        {
            Console.WriteLine("❌ Invalid card number. Must be 16 digits.");
            return false;
        }

        Console.Write("Enter expiry date (MM/YY): ");
        string? expiryDate = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(expiryDate) || !IsValidExpiryDate(expiryDate))
        {
            Console.WriteLine("❌ Invalid expiry date format.");
            return false;
        }

        Console.Write("Enter CVV (3 digits): ");
        string? cvv = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(cvv) || cvv.Length != 3 || !cvv.All(char.IsDigit))
        {
            Console.WriteLine("❌ Invalid CVV. Must be 3 digits.");
            return false;
        }

        // Simulate payment processing
        Console.WriteLine("\nAuthorizing transaction...");
        Thread.Sleep(1000);
        Console.WriteLine("Contacting payment gateway...");
        Thread.Sleep(1000);

        // Mask card number for security
        string maskedCard = $"****-****-****-{cardNumber.Substring(12)}";

        Console.WriteLine($"✅ Payment successful!");
        Console.WriteLine($"Card ending in: {cardNumber.Substring(12)}");
        Console.WriteLine($"Transaction ID: TXN{DateTime.Now:yyyyMMddHHmmss}");
        Console.WriteLine($"Amount charged: ${amount:F2}");

        return true;
    }

    public string GetPaymentMethodName()
    {
        return "Credit Card";
    }

    private bool IsValidExpiryDate(string expiryDate)
    {
        if (expiryDate.Length != 5 || expiryDate[2] != '/')
            return false;

        string[] parts = expiryDate.Split('/');
        if (parts.Length != 2)
            return false;

        if (!int.TryParse(parts[0], out int month) || month < 1 || month > 12)
            return false;

        if (!int.TryParse(parts[1], out int year))
            return false;

        // Check if card is not expired
        int currentYear = DateTime.Now.Year % 100;
        int currentMonth = DateTime.Now.Month;

        if (year < currentYear)
            return false;

        if (year == currentYear && month < currentMonth)
            return false;

        return true;
    }
}
