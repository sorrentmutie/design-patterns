// ── SmsNotification.cs ──
public class SmsNotification : INotification
{
    public void Send(string recipient, string body)
    {
        var msg = body.Length > 160 ? body[..157] + "..." : body;
        Console.WriteLine($"    SMS to {recipient}: {msg}");
    }
}
