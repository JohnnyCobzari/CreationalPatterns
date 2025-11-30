namespace CreationalPatterns.Behavioral.Strategy;

/// <summary>
/// Concrete strategy for mobile wallet payments (Apple Pay, Google Pay, etc.)
/// </summary>
public class MobilePaymentStrategy : IPaymentStrategy
{
    private readonly string _walletType;

    public MobilePaymentStrategy(string walletType = "Digital Wallet")
    {
        _walletType = walletType;
    }

    public bool ProcessPayment(decimal amount)
    {
        Console.WriteLine($"\n📱 Processing {_walletType} Payment...");
        Console.WriteLine($"Amount to charge: ${amount:F2}");

        Console.Write("Enter registered phone number: ");
        string? phoneNumber = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(phoneNumber) || phoneNumber.Length < 10)
        {
            Console.WriteLine("❌ Invalid phone number.");
            return false;
        }

        Console.WriteLine($"\nSending authentication request to {FormatPhoneNumber(phoneNumber)}...");
        Thread.Sleep(800);

        Console.Write("Enter verification code sent to your phone: ");
        string? verificationCode = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(verificationCode) || verificationCode.Length != 6)
        {
            Console.WriteLine("❌ Invalid verification code. Must be 6 digits.");
            return false;
        }

        // Simulate biometric verification
        Console.WriteLine("\nVerifying biometric authentication...");
        Thread.Sleep(1000);
        Console.WriteLine("Processing payment through secure digital wallet...");
        Thread.Sleep(1000);

        Console.WriteLine($"✅ Payment successful!");
        Console.WriteLine($"Wallet: {_walletType}");
        Console.WriteLine($"Phone: {FormatPhoneNumber(phoneNumber)}");
        Console.WriteLine($"Transaction ID: MW{DateTime.Now:yyyyMMddHHmmss}");
        Console.WriteLine($"Amount charged: ${amount:F2}");
        Console.WriteLine("Receipt sent to your mobile device.");

        return true;
    }

    public string GetPaymentMethodName()
    {
        return _walletType;
    }

    private string FormatPhoneNumber(string phone)
    {
        if (phone.Length >= 10)
        {
            string lastFour = phone.Substring(phone.Length - 4);
            return $"***-***-{lastFour}";
        }
        return "***-***-****";
    }
}
