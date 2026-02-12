namespace ConsoleApp1.Exercise3;

// ── Interfaces ──
public interface IReportHeader { string Render(); }
public interface IReportBody { string Render(List<TradeRecord> trades); }
public interface IReportFooter { string Render(); }

public interface IReportFactory
{
    IReportHeader CreateHeader();
    IReportBody CreateBody();
    IReportFooter CreateFooter();
}
