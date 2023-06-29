using NServiceBus;
using System;

public class Message2 :IMessage
{
    public string Property { get; set; }
    public Message2()
    {
        Property = $"Hello from Endpoint2 at {DateTime.UtcNow}";
    }
}