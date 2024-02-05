using MassTransit;

namespace MicroService.Configuration;

public class ConfigureReceiveEndpoint : IConfigureReceiveEndpoint
{
    public void Configure(string name, IReceiveEndpointConfigurator configurator)
    {
        if (configurator is IRabbitMqReceiveEndpointConfigurator rabbitMqConfigurator)
        {
            rabbitMqConfigurator.SetQuorumQueue();
        }
    }
}
