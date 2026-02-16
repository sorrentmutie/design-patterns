using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp1.Exercise3;

//Exercise 3 – Abstract Factory
//Introductory Speech

//In this exercise, we introduce a different dimension of variability:
//families of related objects.

//Suppose our system generates market reports.
//Depending on the regulatory context — EU or US — the report must change:
//Date formats
//Identifiers (ISIN vs CUSIP)
//Regulatory disclaimers
//Compliance wording
//These elements belong together. They form a coherent family.
//If we use simple conditionals like:

//if (market == "EU") ...
//else if (market == "US") ...


//We mix business logic with regulatory variations.
//That quickly becomes fragile and hard to extend.

//The goal here is to:

//Encapsulate families of related components
//Ensure consistency within each family
//Avoid conditionals scattered throughout the code
//Make adding a new market possible without modifying the generator

//The Abstract Factory pattern gives us an interface that produces
//related components — header, body, footer —
//while keeping the client code unaware of the specific market.

//The key insight is this:

//We are not just abstracting one object.
//We are abstracting a family of coordinated objects.


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
