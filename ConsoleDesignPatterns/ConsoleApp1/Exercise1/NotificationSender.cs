public abstract class NotificationSender
{
    // The factory method — subclasses override this
    protected abstract INotification CreateNotification();

    // Template method using the factory
    public void Notify(string recipient, string body)
    {
        var notification = CreateNotification();
        var channel = notification.GetType().Name;
        Console.WriteLine($"[{channel}] Sending to {recipient}");
        notification.Send(recipient, body);
        Console.WriteLine($"[{channel}] Sent successfully\n");
    }
}
