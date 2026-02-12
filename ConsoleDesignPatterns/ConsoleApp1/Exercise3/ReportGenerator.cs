using ConsoleApp1.Exercise3;

public class ReportGenerator
{
    private readonly IReportFactory _factory;

    public ReportGenerator(IReportFactory factory)
    {
        _factory = factory;
    }

    public string GenerateReport(List<TradeRecord> trades)
    {
        var header = _factory.CreateHeader();
        var body = _factory.CreateBody();
        var footer = _factory.CreateFooter();
        return header.Render() + body.Render(trades) + footer.Render();
    }
}