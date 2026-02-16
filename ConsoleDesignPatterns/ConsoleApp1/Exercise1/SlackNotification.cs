public class SlackNotification : INotification
{
    public void Send(string recipient, string body)
    {
        Console.WriteLine($"    SLACK to #{recipient}: {body}");
    }
}
