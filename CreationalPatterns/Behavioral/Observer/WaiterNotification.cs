using CreationalPatterns.Behavioral.State;

namespace CreationalPatterns.Behavioral.Observer;

/// <summary>
/// Concrete observer - Waiter Notification System
/// Alerts waiters about order status changes
/// </summary>
public class WaiterNotification : IOrderObserver
{
    private readonly string _waiterName;
    private int _notificationCount = 0;

    public WaiterNotification(string waiterName = "Server")
    {
        _waiterName = waiterName;
    }

    public void Update(OrderContext orderContext, string message)
    {
        _notificationCount++;
        string orderId = orderContext.GetOrderId();
        string state = orderContext.GetCurrentStateName();
        string stateSymbol = orderContext.GetCurrentStateSymbol();

        Console.WriteLine($"\n🔔 [WAITER - {_waiterName}] {stateSymbol} {message}");

        switch (state)
        {
            case "Pending":
                Console.WriteLine($"   📝 New order {orderId} received");
                Console.WriteLine($"   💬 Confirm order details with customer");
                break;

            case "Preparing":
                Console.WriteLine($"   👨‍🍳 Order {orderId} sent to kitchen");
                var preparedPasta = orderContext.GetOrder().PreparedPasta;
                if (preparedPasta != null)
                {
                    Console.WriteLine($"   ⏰ Estimated wait: {preparedPasta.CookingTime} minutes");
                }
                Console.WriteLine($"   💬 Inform customer about wait time");
                break;

            case "Ready":
                Console.WriteLine($"   ✅ Order {orderId} is ready for pickup!");
                Console.WriteLine($"   🏃 Please collect from kitchen pass");
                Console.WriteLine($"   🍽️  Prepare to serve to customer");
                break;

            case "Served":
                Console.WriteLine($"   🍽️  Order {orderId} served to customer");
                Console.WriteLine($"   💬 Enjoy your meal! Let us know if you need anything");
                break;

            case "Completed":
                Console.WriteLine($"   ✔️  Order {orderId} completed and paid");
                Console.WriteLine($"   🙏 Thank customer and wish them a great day!");
                break;

            case "Cancelled":
                Console.WriteLine($"   🚫 Order {orderId} has been cancelled");
                Console.WriteLine($"   💬 Apologize to customer if needed");
                break;
        }

        Console.WriteLine($"   📊 Total notifications today: {_notificationCount}");
    }

    public string GetObserverName()
    {
        return $"Waiter - {_waiterName}";
    }
}
