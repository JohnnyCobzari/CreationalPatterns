using CreationalPatterns.Models;

namespace CreationalPatterns.Builder;

public abstract class PastaBuilder
{
    protected Pasta pasta = new();

    public abstract void SetType();
    public abstract void AddSauce();
    public abstract void SetCookingTime();

    public Pasta GetResult() => pasta;
}