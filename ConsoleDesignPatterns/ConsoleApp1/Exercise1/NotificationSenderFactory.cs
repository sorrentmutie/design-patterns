public static class NotificationSenderFactory
{
    private static readonly Dictionary<string, Func<NotificationSender>> Registry = new()
    {
        ["email"] = () => new EmailNotificationSender(),
        ["sms"] = () => new SmsNotificationSender(),
        ["push"] = () => new PushNotificationSender(),
        ["slack"] = () => new SlackNotificationSender(),
    };

    public static NotificationSender Create(string channelType)
    {
        if (!Registry.TryGetValue(channelType.ToLower(), out var factory))
            throw new ArgumentException($"Unknown channel: {channelType}");
        return factory();
    }
}