using System;
using System.Threading.Tasks;
using NServiceBus;
using Shared;

class Program
{
    const string endpointName = "Samples.ASBS.SendReply.Endpoint1";
    static async Task Main()
    {
        Console.Title = endpointName;
        IEndpointInstance endpointInstance = await TransportEndpointConfiguration.TransportConfiguration(endpointName).ConfigureAwait(false);
        Console.WriteLine("Press 'enter' to send a message or any other key to exit ");
        while (true)
        {
            var key = Console.ReadKey();
            Console.WriteLine();

            if (key.Key != ConsoleKey.Enter)
                break;
            await SendMessageFromEndpoint1(endpointInstance).ConfigureAwait(false);
        }
        await endpointInstance.Stop()
            .ConfigureAwait(false);
    }

    private static async Task SendMessageFromEndpoint1(IEndpointInstance endpointInstance)
    {
        await endpointInstance.Send("Samples.ASBS.SendReply.Endpoint2", new Message1())
                        .ConfigureAwait(false);
        Console.WriteLine("Message1 sent");
    }
}
