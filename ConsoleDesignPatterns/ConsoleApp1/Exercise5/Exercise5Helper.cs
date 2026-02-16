using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace ConsoleApp1.Exercise5;


//Exercise 5 – Singleton(and Why It’s Dangerous)
//Introductory Speech

//This last exercise is intentionally controversial.

//Singleton is one of the most well-known design patterns — and one of the most misused.

//At first glance, it seems perfect for configuration services:

//One configuration

//Globally accessible

//Easy to implement

//But software design is not just about making something work.
//It’s about making it testable, maintainable, and explicit.

//In this exercise, we will:

//Implement three Singleton variants

//Observe their behavior

//Identify architectural problems

//Refactor using Dependency Injection

//The real learning objective is not how to write a Singleton.

//The real objective is to understand:

//Hidden dependencies

//Global state risks

//Testability limitations

//Why modern frameworks prefer DI containers

//Notice how the refactored version makes dependencies explicit.
//That single change dramatically improves clarity and testability.

//This exercise is less about a pattern and more about architectural maturity.



public static class Exercise5Helper
{
    public static void Run() {

        Console.WriteLine("=== Part A: Singleton variants ===");
        Console.WriteLine($"Eager:      {ConfigurationServiceEager.Instance.Get("trade.max.size")}");
        Console.WriteLine($"Lazy:       {ConfigurationServiceLazy.Instance.Get("trade.max.size")}");
        Console.WriteLine($"ThreadSafe: {ConfigurationServiceThreadSafe.Instance.Get("trade.max.size")}");

        Console.WriteLine("\n=== Part B: Problems ===");
        var singletonService = new TradeServiceSingleton();
        singletonService.ExecuteTrade("ORD-001");
        Console.WriteLine("(Cannot substitute config for testing)\n");

        Console.WriteLine("=== Part C: DI Refactoring ===");

        // Production
        var prodService = new TradeService(new RealConfigProvider());
        prodService.ExecuteTrade("ORD-PROD-001");

        // Test — different config, no Singleton, no static coupling
        var testService = new TradeService(
            new TestConfigProvider(new Dictionary<string, string>
            {
                ["trade.max.size"] = "500",
                ["trade.default.currency"] = "USD",
            })
        );
        testService.ExecuteTrade("ORD-TEST-001");

        Console.WriteLine("\nDI version is testable, explicit, and decoupled.");
        Console.WriteLine("In ASP.NET Core: AddSingleton<IConfigProvider, RealConfigProvider>()");
    }
}
