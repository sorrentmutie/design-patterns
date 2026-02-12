namespace ConsoleApp1.Exercise2;

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
