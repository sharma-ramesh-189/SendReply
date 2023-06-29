using NServiceBus;
using System.Threading.Tasks;
using System;

namespace Shared
{
    public class TransportEndpointConfiguration
    {
        public static async Task<IEndpointInstance> TransportConfiguration(string endpointName)
        {
            var endpointConfiguration = new EndpointConfiguration(endpointName);
            endpointConfiguration.EnableInstallers();

            var connectionString = Environment.GetEnvironmentVariable("AzureServiceBus_ConnectionString");
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new Exception("Could not read the 'AzureServiceBus_ConnectionString' environment variable. Check the sample prerequisites.");

            var transport = new AzureServiceBusTransport(connectionString);
            endpointConfiguration.UseTransport(transport);

            var endpointInstance = await Endpoint.Start(endpointConfiguration)
                .ConfigureAwait(false);

            return endpointInstance;
        }
    }
}
