using CreationalPatterns.Models;

namespace CreationalPatterns.Builder;

public class ChefDirector
{
    private readonly PastaBuilder _builder;
    public ChefDirector(PastaBuilder builder) => _builder = builder;

    public Pasta Cook()
    {
        _builder.SetType();
        _builder.AddSauce();
        _builder.SetCookingTime();
        return _builder.GetResult();
    }
}