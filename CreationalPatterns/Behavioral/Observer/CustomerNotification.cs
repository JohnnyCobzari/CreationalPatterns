using CreationalPatterns.Behavioral.State;

namespace CreationalPatterns.Behavioral.Observer;

/// <summary>
/// Concrete observer - Customer Notification System
/// Sends SMS/App notifications to customers
/// </summary>
public class CustomerNotification : IOrderObserver
{
    private readonly string _customerPhone;
    private readonly string _customerName;

    public CustomerNotification(string customerName, string customerPhone = "555-0000")
    {
        _customerName = customerName;
        _customerPhone = customerPhone;
    }

    public void Update(OrderContext orderContext, string message)
    {
        string orderId = orderContext.GetOrderId();
        string state = orderContext.GetCurrentStateName();
        string stateSymbol = orderContext.GetCurrentStateSymbol();

        Console.WriteLine($"\n🔔 [CUSTOMER APP - {_customerName}] {stateSymbol} {message}");
        Console.WriteLine($"   📱 Notification sent to: {FormatPhone(_customerPhone)}");

        string notification = state switch
        {
            "Pending" => GeneratePendingNotification(orderId),
            "Preparing" => GeneratePreparingNotification(orderId, orderContext),
            "Ready" => GenerateReadyNotification(orderId),
            "Served" => GenerateServedNotification(orderId),
            "Completed" => GenerateCompletedNotification(orderId),
            "Cancelled" => GenerateCancelledNotification(orderId),
            _ => "Order status updated"
        };

        Console.WriteLine($"\n   ┌─────────────────────────────────────┐");
        Console.WriteLine($"   │ 📱 SMS/App Notification             │");
        Console.WriteLine($"   ├─────────────────────────────────────┤");
        foreach (var line in notification.Split('\n'))
        {
            Console.WriteLine($"   │ {line,-35} │");
        }
        Console.WriteLine($"   └─────────────────────────────────────┘");
    }

    public string GetObserverName()
    {
        return $"Customer Notification - {_customerName}";
    }

    private string FormatPhone(string phone)
    {
        if (phone.Length >= 7)
        {
            return $"***-{phone.Substring(phone.Length - 4)}";
        }
        return "***-****";
    }

    private string GeneratePendingNotification(string orderId)
    {
        return $"Hi {_customerName}!\nOrder {orderId} received.\nWe're processing your order...";
    }

    private string GeneratePreparingNotification(string orderId, OrderContext context)
    {
        var preparedPasta = context.GetOrder().PreparedPasta;
        int cookingTime = preparedPasta?.CookingTime ?? 10;
        return $"Good news {_customerName}!\nYour order is being prepared 👨‍🍳\nEstimated time: ~{cookingTime} min";
    }

    private string GenerateReadyNotification(string orderId)
    {
        return $"🎉 {_customerName}, your order is ready!\nPlease come to the counter.\nEnjoy your meal!";
    }

    private string GenerateServedNotification(string orderId)
    {
        return $"Bon appétit, {_customerName}! 🍝\nYour meal has been served.\nEnjoy!";
    }

    private string GenerateCompletedNotification(string orderId)
    {
        return $"Thank you, {_customerName}! 🙏\nOrder {orderId} completed.\nHope to see you again soon!";
    }

    private string GenerateCancelledNotification(string orderId)
    {
        return $"Order {orderId} cancelled.\nSorry for any inconvenience.\nContact us: (555) 123-4567";
    }
}
