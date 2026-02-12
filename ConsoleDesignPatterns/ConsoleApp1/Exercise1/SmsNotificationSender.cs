// ── SmsNotificationSender.cs ──
public class SmsNotificationSender : NotificationSender
{
    protected override INotification CreateNotification() => new SmsNotification();
}
