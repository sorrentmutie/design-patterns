namespace ConsoleApp1.Exercise4;

public class Position : IPrototype<Position>
{
    public string InstrumentId { get; set; }
    public int Quantity { get; set; }
    public decimal MarketValue { get; set; }
    public string Currency { get; set; }

    public Position(string instrumentId, int quantity, decimal marketValue, string currency)
    {
        InstrumentId = instrumentId;
        Quantity = quantity;
        MarketValue = marketValue;
        Currency = currency;
    }

    // Copy constructor
    public Position(Position source)
    {
        InstrumentId = source.InstrumentId;  // string is immutable
        Quantity = source.Quantity;
        MarketValue = source.MarketValue;
        Currency = source.Currency;
    }

    public Position DeepCopy() => new(this);

    public void ApplyStressFactor(decimal factor)
    {
        MarketValue = Math.Round(MarketValue * factor, 2);
    }

    public override string ToString() =>
        $"  {InstrumentId}: {Quantity} units @ {MarketValue} {Currency}";
}
