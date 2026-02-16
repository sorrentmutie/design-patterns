// ── PushNotification.cs ──
public class PushNotification : INotification
{
    public void Send(string recipient, string body)
    {
        Console.WriteLine($"    PUSH to device {recipient}: {body}");
    }
}