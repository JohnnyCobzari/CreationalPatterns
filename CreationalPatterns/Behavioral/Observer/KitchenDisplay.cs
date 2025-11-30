using CreationalPatterns.Behavioral.State;

namespace CreationalPatterns.Behavioral.Observer;

/// <summary>
/// Concrete observer - Kitchen Display System
/// Shows order information to kitchen staff
/// </summary>
public class KitchenDisplay : IOrderObserver
{
    private readonly List<string> _orderQueue = new();

    public void Update(OrderContext orderContext, string message)
    {
        string orderId = orderContext.GetOrderId();
        string state = orderContext.GetCurrentStateName();
        string stateSymbol = orderContext.GetCurrentStateSymbol();

        Console.WriteLine($"\n🔔 [KITCHEN DISPLAY] {stateSymbol} {message}");

        switch (state)
        {
            case "Preparing":
                _orderQueue.Add(orderId);
                Console.WriteLine($"   📋 Order {orderId} added to kitchen queue");
                Console.WriteLine($"   👨‍🍳 Chef, please start preparing this order!");
                DisplayOrderDetails(orderContext);
                break;

            case "Ready":
                _orderQueue.Remove(orderId);
                Console.WriteLine($"   ✅ Order {orderId} completed and ready for pickup");
                Console.WriteLine($"   🔔 DING! Order ready at the pass!");
                break;

            case "Cancelled":
                if (_orderQueue.Contains(orderId))
                {
                    _orderQueue.Remove(orderId);
                    Console.WriteLine($"   🗑️  Order {orderId} cancelled - stop preparation");
                }
                break;
        }

        if (_orderQueue.Count > 0)
        {
            Console.WriteLine($"   📊 Active orders in kitchen: {_orderQueue.Count}");
        }
    }

    public string GetObserverName()
    {
        return "Kitchen Display System";
    }

    private void DisplayOrderDetails(OrderContext orderContext)
    {
        var order = orderContext.GetOrder();
        if (order.PreparedPasta != null)
        {
            Console.WriteLine($"   🍝 Pasta Type: {order.PreparedPasta.Type}");
            Console.WriteLine($"   🥫 Sauce: {order.PreparedPasta.Sauce}");
            Console.WriteLine($"   ⏱️  Cooking Time: {order.PreparedPasta.CookingTime} minutes");
        }
        else
        {
            Console.WriteLine($"   🍝 Pasta Type: {order.PastaType}");
        }
    }
}
