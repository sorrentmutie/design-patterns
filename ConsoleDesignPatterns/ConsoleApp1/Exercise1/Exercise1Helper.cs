
using System.Numerics;
using System.Reflection.Emit;
using System.Threading.Channels;

namespace ConsoleApp1.Exercise1;


//Exercise 1 – Factory Method
//Introductory Speech

//In this exercise, we are addressing a very common real-world problem: sending notifications
//through multiple channels.

//Imagine we are building a trading or banking system.
//Sometimes we need to send an email, sometimes an SMS,
//sometimes a push notification. Very soon, we face a design question:

//Who is responsible for creating the correct notification object?

//If we hard-code new EmailNotification() everywhere,
//our system becomes tightly coupled.Every time we add a new channel,
//we must modify existing logic.That violates the Open/Closed Principle.

//The goal of this exercise is to:

//Separate creation from usage

//Delegate object creation to subclasses

//Allow new notification channels to be introduced without modifying existing code

//We’ll use the Factory Method pattern to move the responsibility of object creation
//into subclasses while keeping the high-level workflow stable in the base class.

//Pay attention to how Notify() stays unchanged while the concrete channel varies.
//That is the key idea:
//variation in creation, stability in behavior.




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