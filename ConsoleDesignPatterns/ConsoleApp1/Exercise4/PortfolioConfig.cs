namespace ConsoleApp1.Exercise4;

public class PortfolioConfig : IPrototype<PortfolioConfig>
{
    public string Name { get; set; }
    public List<Position> Positions { get; }
    public Dictionary<string, decimal> RiskLimits { get; }
    public DateOnly ValuationDate { get; set; }

    public PortfolioConfig(string name, List<Position> positions,
                           Dictionary<string, decimal> riskLimits, DateOnly valuationDate)
    {
        Name = name;
        Positions = new List<Position>(positions);
        RiskLimits = new Dictionary<string, decimal>(riskLimits);
        ValuationDate = valuationDate;
    }

    // Copy constructor — deep copy
    public PortfolioConfig(PortfolioConfig source)
    {
        Name = source.Name;
        Positions = source.Positions.Select(p => p.DeepCopy()).ToList();
        RiskLimits = new Dictionary<string, decimal>(source.RiskLimits);
        ValuationDate = source.ValuationDate;
    }

    public PortfolioConfig DeepCopy() => new(this);

    public void ApplyStressFactor(decimal factor)
    {
        foreach (var p in Positions)
            p.ApplyStressFactor(factor);
    }

    public decimal TotalMarketValue =>
        Positions.Sum(p => p.MarketValue);

    public override string ToString()
    {
        var sb = new System.Text.StringBuilder();
        sb.AppendLine($"Portfolio '{Name}' (valuation: {ValuationDate}, total: {TotalMarketValue:F2})");
        foreach (var p in Positions)
            sb.AppendLine(p.ToString());
        return sb.ToString();
    }
}

// ── PrototypeRegistry.cs ──
public class PrototypeRegistry
{
    private readonly Dictionary<string, PortfolioConfig> _prototypes = new();

    public void Register(string key, PortfolioConfig prototype)
    {
        _prototypes[key] = prototype;
    }

    public PortfolioConfig Create(string key)
    {
        if (!_prototypes.TryGetValue(key, out var proto))
            throw new ArgumentException($"Unknown prototype: {key}");
        return proto.DeepCopy();
    }
}
