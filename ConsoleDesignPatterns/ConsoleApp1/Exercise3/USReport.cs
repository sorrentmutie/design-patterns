using ConsoleApp1.Exercise3;

public class USReportHeader : IReportHeader
{
    public string Render() => $"""
        ╔══════════════════════════════════════════╗
        ║  US MARKET REPORT — {DateOnly.FromDateTime(DateTime.Today):MM/dd/yyyy}             ║
        ║  SEC Regulation NMS Compliant            ║
        ╚══════════════════════════════════════════╝
        """;
}

public class USReportBody : IReportBody
{
    public string Render(List<TradeRecord> trades)
    {
        var sb = new System.Text.StringBuilder();
        sb.AppendLine($"{"CUSIP",-10} {"Instrument",-10} {"Qty",8} {"Price (USD)",12} {"Date",12}");
        sb.AppendLine(new string('-', 56));
        foreach (var t in trades)
            sb.AppendLine($"{t.Cusip,-10} {t.Instrument,-10} {t.Quantity,8} {t.Price,12:F2} {t.TradeDate:MM/dd/yyyy,12}");
        return sb.ToString();
    }
}

public class USReportFooter : IReportFooter
{
    public string Render() => """
        ---
        This report complies with SEC Regulation NMS and Dodd-Frank Act requirements.
        For authorized use only. Not for redistribution.
        """;
}

public class USReportFactory : IReportFactory
{
    public IReportHeader CreateHeader() => new USReportHeader();
    public IReportBody CreateBody() => new USReportBody();
    public IReportFooter CreateFooter() => new USReportFooter();
}


