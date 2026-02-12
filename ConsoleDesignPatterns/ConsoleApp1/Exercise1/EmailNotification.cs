// ── EmailNotification.cs ──
public class EmailNotification : INotification
{
    public void Send(string recipient, string body)
    {
        Console.WriteLine($"    EMAIL to <{recipient}>: {body}");
    }
}