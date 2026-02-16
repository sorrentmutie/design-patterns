using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Exercise5;

public sealed class ConfigurationServiceThreadSafe
{
    private static ConfigurationServiceThreadSafe? _instance;
    private static readonly object _lock = new();

    private readonly Dictionary<string, string> _settings;

    private ConfigurationServiceThreadSafe()
    {
        _settings = new Dictionary<string, string>
        {
            ["trade.max.size"] = "1000000",
            ["trade.default.currency"] = "EUR",
            ["risk.margin.threshold"] = "0.15",
            ["notification.channel"] = "email",
        };
        Console.WriteLine("[ThreadSafe] ConfigurationService initialized");
    }

    public static ConfigurationServiceThreadSafe Instance
    {
        get
        {
            if (_instance is null)
            {
                lock (_lock)
                {
                    _instance ??= new ConfigurationServiceThreadSafe();
                }
            }
            return _instance;
        }
    }

    public string? Get(string key) =>
        _settings.TryGetValue(key, out var value) ? value : null;
}
