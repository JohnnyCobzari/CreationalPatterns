using CreationalPatterns.Models;

namespace CreationalPatterns.Factory;

public abstract class AbstractOrderFactory
{
    public abstract Order CreateOrder();
}