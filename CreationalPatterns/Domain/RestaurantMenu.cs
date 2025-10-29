namespace CreationalPatterns.Domain;

public sealed class RestaurantMenu
{
    private static RestaurantMenu? _instance;
    private static readonly object _lock = new();
    public List<string> AvailablePasta { get; private set; }

    private RestaurantMenu()
    {
        AvailablePasta = new List<string>
        {
            "1. Spaghetti",
            "2. Penne",
            "3. Fettuccine"
        };
    }

    public static RestaurantMenu Instance
    {
        get
        {
            lock (_lock)
            {
                return _instance ??= new RestaurantMenu();
            }
        }
    }

    public void ShowMenu()
    {
        Console.WriteLine("\n📜 Menu:");
        foreach (var item in AvailablePasta)
            Console.WriteLine(item);
    }
}