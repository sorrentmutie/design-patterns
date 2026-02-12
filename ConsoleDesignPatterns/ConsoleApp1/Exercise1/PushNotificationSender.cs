// ── PushNotificationSender.cs ──
public class PushNotificationSender : NotificationSender
{
    protected override INotification CreateNotification() => new PushNotification();
}