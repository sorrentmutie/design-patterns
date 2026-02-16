using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Exercise5;

// ── IConfigProvider.cs ──
public interface IConfigProvider
{
    string? Get(string key);
}

public class RealConfigProvider : IConfigProvider
{
    private readonly Dictionary<string, string> _settings;

    public RealConfigProvider()
    {
        _settings = new Dictionary<string, string>
        {
            ["trade.max.size"] = "1000000",
            ["trade.default.currency"] = "EUR",
            ["risk.margin.threshold"] = "0.15",
            ["notification.channel"] = "email",
        };
    }

    public string? Get(string key) =>
        _settings.TryGetValue(key, out var value) ? value : null;
}

public class TestConfigProvider : IConfigProvider
{
    private readonly Dictionary<string, string> _settings;

    public TestConfigProvider(Dictionary<string, string> settings)
    {
        _settings = settings;
    }

    public string? Get(string key) =>
        _settings.TryGetValue(key, out var value) ? value : null;
}

public class TradeService
{
    private readonly IConfigProvider _config; // Explicit dependency!

    public TradeService(IConfigProvider config)
    {
        _config = config;
    }

    public string? ExecuteTrade(string orderId)
    {
        var maxSize = _config.Get("trade.max.size");
        Console.WriteLine($"Executing trade {orderId} with max size {maxSize}");
        return maxSize;
    }
}

