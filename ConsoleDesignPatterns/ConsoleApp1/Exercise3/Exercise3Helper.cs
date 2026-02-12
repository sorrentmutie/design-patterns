using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Exercise3;

public static class Exercise3Helper
{
    public static void Run() {
        var trades = new List<TradeRecord>
        {
            new("DE0007100000", "037833100", "Daimler", 500, 74.20m, new DateOnly(2025, 3, 15)),
            new("US0378331005", "037833100", "Apple",   100, 182.50m, new DateOnly(2025, 3, 15)),
            new("GB0002374006", "D18190898", "Diageo",  200, 38.75m, new DateOnly(2025, 3, 14)),
        };
        // EU Report
        var euGen = new ReportGenerator(new EUReportFactory());
        Console.WriteLine(euGen.GenerateReport(trades));

        // US Report
        var usGen = new ReportGenerator(new USReportFactory());
        Console.WriteLine(usGen.GenerateReport(trades));

        // Stretch: Registry-based
        var registry = new Dictionary<string, IReportFactory>
        {
            ["EU"] = new EUReportFactory(),
            ["US"] = new USReportFactory(),
        };
        var market = "EU"; // from config
        var gen = new ReportGenerator(registry[market]);
        Console.WriteLine(gen.GenerateReport(trades));
    }
}
