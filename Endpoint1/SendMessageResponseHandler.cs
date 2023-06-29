using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;

public class SendMessageResponseHandler :
    IHandleMessages<Message2>
{
    static ILog log = LogManager.GetLogger<SendMessageResponseHandler>();

    public Task Handle(Message2 message, IMessageHandlerContext context)
    {
        log.Info($"Received Message2: {message.Property}");
        return Task.CompletedTask;
    }
}