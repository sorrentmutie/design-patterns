
namespace ConsoleApp1.Exercise1;

public static class Exercise1Helper
{
    public static void Run()
    {
        // Direct usage
        NotificationSender email = new EmailNotificationSender();
        NotificationSender sms = new SmsNotificationSender();
        NotificationSender push = new PushNotificationSender();

        email.Notify("john@unicredit.eu", "Your trade has been executed.");
        sms.Notify("+40721000000", "Trade confirmation: BUY 100 AAPL");
        push.Notify("device-abc-123", "Portfolio alert: margin call");

        // Via factory
        Console.WriteLine("=== Via Factory ===");
        foreach (var channel in new[] { "email", "sms", "push", "slack" })
        {
            var sender = NotificationSenderFactory.Create(channel);
            sender.Notify("test-recipient", $"Test message via {channel}");
        }
    }
}