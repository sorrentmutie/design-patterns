namespace ConsoleApp1.Exercise2;

public sealed class TradeOrder
{
    public string OrderId { get; }
    public string ClientId { get; }
    public string Instrument { get; }
    public Side Side { get; }
    public int Quantity { get; }
    public decimal? Price { get; }         // null = market order
    public decimal? StopLoss { get; }
    public decimal? TakeProfit { get; }
    public TimeInForce TimeInForce { get; }
    public string? Notes { get; }

    private TradeOrder(Builder b)
    {
        OrderId = b._orderId;
        ClientId = b._clientId;
        Instrument = b._instrument;
        Side = b._side;
        Quantity = b._quantity;
        Price = b._price;
        StopLoss = b._stopLoss;
        TakeProfit = b._takeProfit;
        TimeInForce = b._timeInForce;
        Notes = b._notes;
    }


    public static Builder CreateBuilder() => new();

    public override string ToString() =>
        $"TradeOrder{{id={OrderId}, client={ClientId}, {Side} {Quantity} {Instrument} " +
        $"@ {(Price.HasValue ? Price.Value.ToString("F2") : "MARKET")}, " +
        $"SL={StopLoss}, TP={TakeProfit}, TIF={TimeInForce}, notes={Notes}}}";

    public class Builder
    {
        internal string _orderId = null!;
        internal string _clientId = null!;
        internal string _instrument = null!;
        internal Side _side;
        internal int _quantity;
        internal decimal? _price;
        internal decimal? _stopLoss;
        internal decimal? _takeProfit;
        internal TimeInForce _timeInForce = TimeInForce.DAY;
        internal string? _notes;

        public Builder OrderId(string v) { _orderId = v; return this; }
        public Builder ClientId(string v) { _clientId = v; return this; }
        public Builder Instrument(string v) { _instrument = v; return this; }
        public Builder WithSide(Side v) { _side = v; return this; }
        public Builder Quantity(int v) { _quantity = v; return this; }
        public Builder Price(decimal v) { _price = v; return this; }
        public Builder StopLoss(decimal v) { _stopLoss = v; return this; }
        public Builder TakeProfit(decimal v) { _takeProfit = v; return this; }
        public Builder WithTimeInForce(TimeInForce v) { _timeInForce = v; return this; }
        public Builder Notes(string v) { _notes = v; return this; }

        public TradeOrder Build()
        {
            // Required fields
            ArgumentNullException.ThrowIfNull(_orderId, nameof(_orderId));
            ArgumentNullException.ThrowIfNull(_clientId, nameof(_clientId));
            ArgumentNullException.ThrowIfNull(_instrument, nameof(_instrument));

            if (_quantity <= 0)
                throw new InvalidOperationException(
                    $"Quantity must be positive, got: {_quantity}");

            // Cross-field validation
            if (_side == Side.Buy && _price.HasValue)
            {
                if (_stopLoss.HasValue && _stopLoss.Value >= _price.Value)
                    throw new InvalidOperationException(
                        $"BUY stopLoss ({_stopLoss}) must be below price ({_price})");

                if (_takeProfit.HasValue && _takeProfit.Value <= _price.Value)
                    throw new InvalidOperationException(
                        $"BUY takeProfit ({_takeProfit}) must be above price ({_price})");
            }

            return new TradeOrder(this);
        }
    }

}
