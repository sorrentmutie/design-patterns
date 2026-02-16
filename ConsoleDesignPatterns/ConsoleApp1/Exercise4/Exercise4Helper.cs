using System.IO;
using System.Security.AccessControl;

namespace ConsoleApp1.Exercise4;

//Exercise 4 – Prototype
//Introductory Speech

//Now we face a performance and modeling challenge.

//Imagine a portfolio simulation engine running hundreds or
//thousands of stress scenarios.
//Each scenario starts from the same base configuration but applies
//different stress factors.
//We could rebuild the portfolio from scratch each time — but that would be expensive and repetitive.
//Instead, we want to:
//Define a base configuration once
//Clone it efficiently
//Modify the clone without affecting the original

//Ensure deep copying, not shallow copying
//The objective of this exercise is to understand:
//The difference between shallow and deep copies
//How to safely clone complex object graphs
//How to protect the integrity of the original state
//The Prototype pattern allows us to create new objects by copying existing ones instead of instantiating them from scratch.
//Pay special attention to the deep copy of collections.
//If we copy references instead of objects, simulations will corrupt the original portfolio.
//In simulation-heavy systems, Prototype helps reduce duplication, improve performance, and simplify configuration management.


public static class Exercise4Helper
{
    public static void Run()
    {
        var basePortfolio = new PortfolioConfig(
            "Standard Equity",
            new List<Position>
            {
                new("AAPL", 100, 18250.00m, "USD"),
                new("MSFT",  50, 21000.00m, "USD"),
                new("SAP",  200, 43200.00m, "EUR"),
                new("BAYN", 150,  6075.00m, "EUR"),
                new("HSBA", 300, 19500.00m, "GBP"),
            },
            new Dictionary<string, decimal>
            {
                ["maxExposure"] = 500000m,
                ["maxSinglePosition"] = 100000m,
            },
            DateOnly.FromDateTime(DateTime.Today)
        );
        // 2. Register
        var registry = new PrototypeRegistry();
        registry.Register("standard-equity", basePortfolio);

        // 3. Run 100 simulations
        var random = new Random(42);
        var results = new List<decimal>();

        for (int i = 0; i < 100; i++)
        {
            var sim = registry.Create("standard-equity");
            var factor = 0.7m + (decimal)(random.NextDouble() * 0.6); // 0.7 to 1.3
            sim.ApplyStressFactor(factor);
            results.Add(sim.TotalMarketValue);
        }

        // 4. Verify original is unchanged
        Console.WriteLine("=== ORIGINAL (should be unchanged) ===");
        Console.WriteLine(basePortfolio);

        // 5. Print simulation summary
        Console.WriteLine("=== SIMULATION RESULTS (100 runs) ===");
        Console.WriteLine($"Original: {basePortfolio.TotalMarketValue:F2}");
        Console.WriteLine($"Min:      {results.Min():F2}");
        Console.WriteLine($"Max:      {results.Max():F2}");
        Console.WriteLine($"Average:  {results.Average():F2}");

        // Sample clone
        var sample = registry.Create("standard-equity");
        sample.ApplyStressFactor(0.85m);
        Console.WriteLine("\n=== SAMPLE STRESSED PORTFOLIO (factor 0.85) ===");
        Console.WriteLine(sample);

    }


}
