using System;
using System.Collections.Generic;
using System.Runtime;
using System.Text;

namespace ConsoleApp1.Exercise5;

public sealed class ConfigurationServiceEager
{
    private static readonly ConfigurationServiceEager _instance = new();
    private readonly Dictionary<string, string> _settings;

    private ConfigurationServiceEager()
    {
        _settings = new Dictionary<string, string>
        {
            ["trade.max.size"] = "1000000",
            ["trade.default.currency"] = "EUR",
            ["risk.margin.threshold"] = "0.15",
            ["notification.channel"] = "email",
        };
        Console.WriteLine("[Eager] ConfigurationService initialized");
    }

    public static ConfigurationServiceEager Instance => _instance;

    public string? Get(string key) =>
        _settings.TryGetValue(key, out var value) ? value : null;
}
