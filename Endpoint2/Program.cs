using System;
using System.Threading.Tasks;
using NServiceBus;
using Shared;

class Program
{
    const string endpointName = "Samples.ASBS.SendReply.Endpoint2";
    static async Task Main()
    {
        Console.Title = endpointName;
        IEndpointInstance endpointInstance = await TransportEndpointConfiguration.TransportConfiguration(endpointName).ConfigureAwait(false);

        Console.WriteLine("Press any key to exit");
        Console.ReadKey();

        await endpointInstance.Stop()
            .ConfigureAwait(false);
    }
}