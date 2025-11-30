namespace CreationalPatterns.Behavioral.Strategy;

/// <summary>
/// Concrete strategy for cash payments
/// </summary>
public class CashPaymentStrategy : IPaymentStrategy
{
    public bool ProcessPayment(decimal amount)
    {
        Console.WriteLine($"\n💵 Processing Cash Payment...");
        Console.WriteLine($"Amount due: ${amount:F2}");

        Console.Write("Enter cash tendered: $");
        if (decimal.TryParse(Console.ReadLine(), out decimal cashTendered))
        {
            if (cashTendered >= amount)
            {
                decimal change = cashTendered - amount;
                Console.WriteLine($"✅ Payment accepted!");
                Console.WriteLine($"Change due: ${change:F2}");

                if (change > 0)
                {
                    CalculateChange(change);
                }

                return true;
            }
            else
            {
                Console.WriteLine($"❌ Insufficient cash. You need ${amount - cashTendered:F2} more.");
                return false;
            }
        }
        else
        {
            Console.WriteLine("❌ Invalid amount entered.");
            return false;
        }
    }

    public string GetPaymentMethodName()
    {
        return "Cash";
    }

    private void CalculateChange(decimal change)
    {
        Console.WriteLine("\nChange breakdown:");

        int twenties = (int)(change / 20);
        change %= 20;

        int tens = (int)(change / 10);
        change %= 10;

        int fives = (int)(change / 5);
        change %= 5;

        int ones = (int)(change / 1);
        change %= 1;

        int quarters = (int)(change / 0.25m);
        change %= 0.25m;

        int dimes = (int)(change / 0.10m);
        change %= 0.10m;

        int nickels = (int)(change / 0.05m);
        change %= 0.05m;

        int pennies = (int)Math.Round(change / 0.01m);

        if (twenties > 0) Console.WriteLine($"  ${20} bills: {twenties}");
        if (tens > 0) Console.WriteLine($"  ${10} bills: {tens}");
        if (fives > 0) Console.WriteLine($"  ${5} bills: {fives}");
        if (ones > 0) Console.WriteLine($"  ${1} bills: {ones}");
        if (quarters > 0) Console.WriteLine($"  Quarters: {quarters}");
        if (dimes > 0) Console.WriteLine($"  Dimes: {dimes}");
        if (nickels > 0) Console.WriteLine($"  Nickels: {nickels}");
        if (pennies > 0) Console.WriteLine($"  Pennies: {pennies}");
    }
}
