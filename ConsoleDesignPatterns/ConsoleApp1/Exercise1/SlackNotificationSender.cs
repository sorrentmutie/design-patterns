// ── SlackNotificationSender.cs ──
public class SlackNotificationSender : NotificationSender
{
    protected override INotification CreateNotification() => new SlackNotification();
}
