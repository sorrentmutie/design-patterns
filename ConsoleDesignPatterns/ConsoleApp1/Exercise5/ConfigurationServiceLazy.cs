namespace ConsoleApp1.Exercise5;

public class ConfigurationServiceLazy
{
    private static readonly Lazy<ConfigurationServiceLazy> _instance =
    new(() => new ConfigurationServiceLazy());

    private readonly Dictionary<string, string> _settings;

    private ConfigurationServiceLazy()
    {
        _settings = new Dictionary<string, string>
        {
            ["trade.max.size"] = "1000000",
            ["trade.default.currency"] = "EUR",
            ["risk.margin.threshold"] = "0.15",
            ["notification.channel"] = "email",
        };
        Console.WriteLine("[Lazy] ConfigurationService initialized");
    }

    public static ConfigurationServiceLazy Instance => _instance.Value;

    public string? Get(string key) =>
        _settings.TryGetValue(key, out var value) ? value : null;
}
