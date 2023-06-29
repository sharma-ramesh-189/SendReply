using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;

public class SendMessageCommandHandler :
    IHandleMessages<Message1>
{
    static ILog log = LogManager.GetLogger<SendMessageCommandHandler>();

    public Task Handle(Message1 message, IMessageHandlerContext context)
    {
        log.Info($"Received Message1: {message.Property}");
        return context.Reply(new Message2());
    }
}