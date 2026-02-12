using ConsoleApp1.Exercise3;

public class EUReportHeader : IReportHeader
{
    public string Render() => $"""
        ╔══════════════════════════════════════════╗
        ║  EU MARKET REPORT — {DateOnly.FromDateTime(DateTime.Today):dd/MM/yyyy}             ║
        ║  Prepared under MiFID II regulations     ║
        ╚══════════════════════════════════════════╝
        """;
}

public class EUReportBody : IReportBody
{
    public string Render(List<TradeRecord> trades)
    {
        var sb = new System.Text.StringBuilder();
        sb.AppendLine($"{"ISIN",-14} {"Instrument",-10} {"Qty",8} {"Price",12} {"Date",12}");
        sb.AppendLine(new string('-', 60));
        foreach (var t in trades)
            sb.AppendLine($"{t.Isin,-14} {t.Instrument,-10} {t.Quantity,8} {t.Price,12:F2} {t.TradeDate:dd/MM/yyyy,12}");
        return sb.ToString();
    }
}

public class EUReportFooter : IReportFooter
{
    public string Render() => """
        ---
        This report complies with MiFID II Directive 2014/65/EU.
        Data classification: CONFIDENTIAL. Distribution restricted to authorized personnel.
        """;
}

public class EUReportFactory : IReportFactory
{
    public IReportHeader CreateHeader() => new EUReportHeader();
    public IReportBody CreateBody() => new EUReportBody();
    public IReportFooter CreateFooter() => new EUReportFooter();
}

