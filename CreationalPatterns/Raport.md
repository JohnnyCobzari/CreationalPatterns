# 🍝 Creational Design Patterns in “Johnny’s Pasta Palace”

## 🧩 Overview

This project demonstrates the use of **three creational design patterns** in C#:

1. **Factory Method** – to create pasta orders dynamically based on user choice
2. **Builder** – to construct different types of pasta step-by-step
3. **Singleton** – to manage a single shared restaurant menu instance

The goal is to simulate a small restaurant console application where a waiter takes the user’s order, the system creates the corresponding pasta order, and a chef prepares it using step-by-step construction.

---

## 🏗️ Project Structure

```
CreationalPatterns/
│
├── Domain/
│   ├── Pasta.cs
│   ├── PastaBuilder.cs
│   ├── ChefDirector.cs
│
├── Factory/
│   ├── AbstractOrderFactory.cs
│   ├── SpaghettiFactory.cs
│   ├── PenneFactory.cs
│   ├── FettuccineFactory.cs
│
├── Models/
│   ├── Order.cs
│   ├── RestaurantMenu.cs
│
└── Program.cs
```

---

## 🏭 1. Factory Method Pattern

### 🔹 Purpose
The **Factory Method** pattern lets the system decide **which type of order** to create at runtime.  
Each concrete factory creates a specific kind of `Order` and prepares it with the correct `PastaBuilder`.

---

### 🔹 Abstract Factory

```csharp
// Factory/AbstractOrderFactory.cs
using CreationalPatterns.Models;

namespace CreationalPatterns.Factory
{
    public abstract class AbstractOrderFactory
    {
        public abstract Order CreateOrder();
    }
}
```

---

### 🔹 Concrete Factories

Each factory defines how a specific pasta order is created.

```csharp
// Factory/SpaghettiFactory.cs
using CreationalPatterns.Domain;
using CreationalPatterns.Models;

namespace CreationalPatterns.Factory
{
    public class SpaghettiFactory : AbstractOrderFactory
    {
        private static int _nextOrderId = 1;

        public override Order CreateOrder()
        {
            var order = new Order { OrderId = _nextOrderId++, PastaType = "Spaghetti" };
            var builder = new SpaghettiBuilder();
            var chef = new ChefDirector(builder);
            order.PreparedPasta = chef.CookPasta();
            return order;
        }
    }
}
```

*(Similar classes exist for `PenneFactory` and `FettuccineFactory`.)*

---

### 🔹 Usage in Main Program

```csharp
Console.Write("\nPlease select your pasta (1-3): ");
string? choice = Console.ReadLine();

AbstractOrderFactory? factory = choice switch
{
    "1" => new SpaghettiFactory(),
    "2" => new PenneFactory(),
    "3" => new FettuccineFactory(),
    _ => null
};

Order order = factory.CreateOrder();
```

✅ **Result:**  
Factory Method decides which pasta (and corresponding builder) is created without modifying the client code.

---

## 👨‍🍳 2. Builder Pattern

### 🔹 Purpose
The **Builder** pattern separates the construction of a complex object (pasta) from its representation.  
This allows the same construction process to create different pasta types with different ingredients, sauce, and cooking time.

---

### 🔹 Product Class

```csharp
// Domain/Pasta.cs
namespace CreationalPatterns.Domain
{
    public class Pasta
    {
        public string? Type { get; set; }
        public string? Sauce { get; set; }
        public int CookTime { get; set; }

        public void Show()
        {
            Console.WriteLine($"🍝 Type: {Type}\n🕒 Cook Time: {CookTime} min\n🥫 Sauce: {Sauce}");
        }
    }
}
```

---

### 🔹 Abstract Builder

```csharp
// Domain/PastaBuilder.cs
namespace CreationalPatterns.Domain
{
    public abstract class PastaBuilder
    {
        protected Pasta pasta = new();

        public abstract void SetType();
        public abstract void SetSauce();
        public abstract void SetCookTime();

        public Pasta GetResult() => pasta;
    }
}
```

---

### 🔹 Concrete Builders

```csharp
// Domain/SpaghettiBuilder.cs
namespace CreationalPatterns.Domain
{
    public class SpaghettiBuilder : PastaBuilder
    {
        public override void SetType() => pasta.Type = "Spaghetti";
        public override void SetSauce() => pasta.Sauce = "Tomato Basil";
        public override void SetCookTime() => pasta.CookTime = 8;
    }
}
```

*(Similar classes exist for `PenneBuilder` and `FettuccineBuilder`.)*

---

### 🔹 Director Class

```csharp
// Domain/ChefDirector.cs
namespace CreationalPatterns.Domain
{
    public class ChefDirector
    {
        private readonly PastaBuilder _builder;

        public ChefDirector(PastaBuilder builder)
        {
            _builder = builder;
        }

        public Pasta CookPasta()
        {
            _builder.SetType();
            _builder.SetSauce();
            _builder.SetCookTime();
            return _builder.GetResult();
        }
    }
}
```

✅ **Result:**  
The `ChefDirector` builds pasta step-by-step, ensuring consistency and flexibility.

---

## 🧍‍♂️ 3. Singleton Pattern

### 🔹 Purpose
The **Singleton** pattern ensures there is only one instance of the restaurant’s menu throughout the application.

---

### 🔹 Implementation

```csharp
// Models/RestaurantMenu.cs
namespace CreationalPatterns.Models
{
    public sealed class RestaurantMenu
    {
        private static readonly RestaurantMenu _instance = new RestaurantMenu();
        public static RestaurantMenu Instance => _instance;

        private RestaurantMenu() { }

        public void ShowMenu()
        {
            Console.WriteLine("\n1️⃣ Spaghetti - Tomato Basil Sauce");
            Console.WriteLine("2️⃣ Penne - Alfredo Sauce");
            Console.WriteLine("3️⃣ Fettuccine - Pesto Sauce");
        }
    }
}
```

✅ **Result:**  
The menu is created only once and reused every time the user views it.

---

## 🎬 4. User Interaction (Console)

```csharp
// Program.cs
Console.WriteLine("👨‍🍳 Welcome to Johnny's Pasta Palace!");
Console.Write("Would you like to order something? (y/n): ");

if (Console.ReadLine()?.Trim().ToLower() != "y")
{
    Console.WriteLine("Come back when you’re hungry!");
    return;
}

var menu = RestaurantMenu.Instance;
menu.ShowMenu();

Console.Write("\nPlease select your pasta (1-3): ");
string? choice = Console.ReadLine();
AbstractOrderFactory? factory = choice switch
{
    "1" => new SpaghettiFactory(),
    "2" => new PenneFactory(),
    "3" => new FettuccineFactory(),
    _ => null
};

Console.WriteLine("\n✅ Preparing your order...");
Order order = factory.CreateOrder();

Console.WriteLine($"\n🍽️ Here is your meal! (Order #{order.OrderId})");
order.PreparedPasta?.Show();
```

✅ **Result:**  
User chooses a pasta → Factory creates the order → Builder constructs the meal → Singleton menu stays consistent.

---

## 🧠 5. Summary Table

| Pattern | Responsibility | Example in Project |
|----------|----------------|--------------------|
| **Factory Method** | Creates pasta orders dynamically | `SpaghettiFactory`, `PenneFactory`, `FettuccineFactory` |
| **Builder** | Assembles pasta details step-by-step | `PastaBuilder` and `ChefDirector` |
| **Singleton** | Manages shared restaurant menu | `RestaurantMenu` |

---

## 🏁 Conclusion

This project demonstrates a clean separation of responsibilities using creational design patterns:

- The **Factory Method** chooses *what to create*
- The **Builder** defines *how to build it*
- The **Singleton** ensures a *single global menu*

Together, they form a modular, extensible, and maintainable design — perfect for demonstrating object-oriented principles in a .NET environment.
