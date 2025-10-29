using CreationalPatterns.Builder;
using CreationalPatterns.Models;

namespace CreationalPatterns.Factory;

public class PenneFactory : AbstractOrderFactory
{
    private static int _orderCounter = 1;

    public override Order CreateOrder()
    {
        var order = new Order { OrderId = _orderCounter++, PastaType = "Penne" };
        var builder = new PenneBuilder();
        var chef = new ChefDirector(builder);
        order.PreparedPasta = chef.Cook();
        return order;
    }
}