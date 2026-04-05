using System;

interface INotification
{
    void Send(string message);
}

class EmailNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine("Email sent: " + message);
    }
}

class SMSNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine("SMS sent: " + message);
    }
}

class PushNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine("Push Notification sent: " + message);
    }
}

class NotificationFactory
{
    public INotification CreateNotification(string type)
    {
        if (type.ToLower() == "email")
            return new EmailNotification();

        if (type.ToLower() == "sms")
            return new SMSNotification();

        if (type.ToLower() == "push")
            return new PushNotification();

        return null;
    }
}

class Program
{
    static void Main()
    {
        NotificationFactory factory = new NotificationFactory();

        var notification = factory.CreateNotification("email");

        notification.Send("Welcome to our service!");
    }
}