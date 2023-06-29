using NServiceBus;
using System;

public class Message1 :IMessage
{
    public string Property { get; set; }
    public Message1()
    {
        Property = $"Hello from Endpoint1 at {DateTime.UtcNow}";
    }
}