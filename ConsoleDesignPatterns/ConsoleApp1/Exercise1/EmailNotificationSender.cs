// ── EmailNotificationSender.cs ──
public class EmailNotificationSender : NotificationSender
{
    protected override INotification CreateNotification() => new EmailNotification();
}
