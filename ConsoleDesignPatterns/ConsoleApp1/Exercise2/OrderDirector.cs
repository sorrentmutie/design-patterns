namespace ConsoleApp1.Exercise2;

public static class OrderDirector
{
    public static TradeOrder CreateMarketOrder(
       string clientId, string instrument, Side side, int quantity) =>
       TradeOrder.CreateBuilder()
           .OrderId(GenerateId())
           .ClientId(clientId)
           .Instrument(instrument)
           .WithSide(side)
           .Quantity(quantity)
           .Build();

    public static TradeOrder CreateLimitOrder(
    string clientId, string instrument, Side side, int quantity,
    decimal price, decimal stopLoss, decimal takeProfit) =>
    TradeOrder.CreateBuilder()
        .OrderId(GenerateId())
        .ClientId(clientId)
        .Instrument(instrument)
        .WithSide(side)
        .Quantity(quantity)
        .Price(price)
        .StopLoss(stopLoss)
        .TakeProfit(takeProfit)
        .WithTimeInForce(TimeInForce.GTC)
        .Build();


    private static string GenerateId() =>
        $"ORD-{DateTime.UtcNow.Ticks}";
}
