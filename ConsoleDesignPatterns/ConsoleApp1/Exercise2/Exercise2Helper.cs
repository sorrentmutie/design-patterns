using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace ConsoleApp1.Exercise2;

//Exercise 2 – Builder
//Introductory Speech

//Now let’s move to a different type of complexity: constructing complex objects.

//In financial systems, a trade order is rarely simple.It may include:

//Required fields like instrument and quantity

//Optional fields like stop loss and take profit

//Cross-field validation rules

//Different configurations like market or limit orders

//If we try to handle all this with constructors, we quickly end up with:

//Telescoping constructors

//Confusing parameter order

//Poor readability

//Weak validation control

//The objective of this exercise is to:

//Build complex objects step by step

//Enforce validation at construction time

//Improve readability and intent

//Prevent partially constructed invalid objects

//The Builder pattern allows us to separate construction from representation. It gives us a fluent API, ensures mandatory fields are validated, and allows cross-field logic inside Build().

//Notice how we move validation into the build phase.
//This guarantees that once a TradeOrder exists, it is valid by construction.

//This pattern is especially powerful in domains where object correctness is critical.



public static class Exercise2Helper
{
    public static void Run() {
        // 1. Market order
        var market = TradeOrder.CreateBuilder()
            .OrderId("ORD-001")
            .ClientId("UC-BUCHAREST-001")
            .Instrument("AAPL")
            .WithSide(Side.Buy)
            .Quantity(100)
            .Build();
        Console.WriteLine($"Market: {market}");

        // 2. Limit order with SL/TP
        var limit = TradeOrder.CreateBuilder()
            .OrderId("ORD-002")
            .ClientId("UC-BRATISLAVA-002")
            .Instrument("MSFT")
            .WithSide(Side.Buy)
            .Quantity(50)
            .Price(420.00m)
            .StopLoss(400.00m)
            .TakeProfit(450.00m)
            .WithTimeInForce(TimeInForce.GTC)
            .Notes("Limit order with protection")
            .Build();
        Console.WriteLine($"Limit:  {limit}");


        // 3. Invalid order
        try
        {
            var invalid = TradeOrder.CreateBuilder()
                .OrderId("ORD-003")
                .ClientId("UC-MUNICH-003")
                .Instrument("TSLA")
                .WithSide(Side.Buy)
                .Quantity(200)
                .Price(250.00m)
                .StopLoss(300.00m)  // above price!
                .Build();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Caught: {ex.Message}");
        }

        // 4. Via Director
        var directed = OrderDirector.CreateMarketOrder("UC-BUCHAREST-001", "GOOG", Side.Sell, 25);
        Console.WriteLine($"Director: {directed}");

    }
}
