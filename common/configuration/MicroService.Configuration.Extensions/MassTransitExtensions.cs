using MassTransit;
using MicroService.Configuration.Builders;
using MicroService.Configuration.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MicroService.Configuration.Extensions;

public static class MassTransitExtensions
{
    public static IServiceCollection AddMassTransit(this IServiceCollection serviceCollection, Action<IMassTransitConfigurationBuilder> configBuilder)
    {
        var massTransitConfig = new MassTransitConfigurationBuilder();
        configBuilder(massTransitConfig);
        var config = massTransitConfig.Configuration;
        
        serviceCollection.AddAzureAppConfiguration();

        if (massTransitConfig.UseQuorumQueues)
        {
            serviceCollection.AddTransient<IConfigureReceiveEndpoint, ConfigureReceiveEndpoint>();
        }

        DependencyInjectionRegistrationExtensions.AddMassTransit(serviceCollection, x =>
        {
            massTransitConfig.ApplyGlobalConfig(x);

            x.UsingRabbitMq((context, cfg) =>
            {
                var rabbitMqConfig = new RabbitMqConfiguration(config, massTransitConfig.ConnectionName);
                
                cfg.Host(rabbitMqConfig.Host, host =>
                {
                    host.Username(rabbitMqConfig.Username);
                    host.Password(rabbitMqConfig.Password);
                    host.Heartbeat(rabbitMqConfig.HeartbeatInterval);
                    
                    if (rabbitMqConfig.IsCluster)
                    {
                        host.UseCluster(cluster =>
                        {
                            foreach (var node in rabbitMqConfig.Nodes)
                            {
                                cluster.Node(node);
                            }
                        });
                    }
                });

                cfg.ConfigureEndpoints(context);

                massTransitConfig.ApplyRabbitMqConfig(context, cfg);

                cfg.PublishTopology.BrokerTopologyOptions = PublishBrokerTopologyOptions.MaintainHierarchy;
                cfg.UseConfigurationRefresher(serviceCollection.BuildServiceProvider());
            });
        });

        return serviceCollection;
    }

    public static void UseConfigurationRefresher<T>(this IPipeConfigurator<T> configurator, IServiceProvider serviceProvider) where T : class, PipeContext
    {
        configurator.AddPipeSpecification(new ConfigurationRefresherSpecification<T>(serviceProvider));
    }
}
