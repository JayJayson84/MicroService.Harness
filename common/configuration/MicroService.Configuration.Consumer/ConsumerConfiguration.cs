using MicroService.Configuration.Extensions;
using MicroService.Configuration.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MicroService.Configuration.Consumer;

public class ConsumerConfiguration
{
    private readonly List<Action<IServiceCollection, IConfiguration>> _serviceConfigurationActions = [];
    private readonly List<Action<IMassTransitConfigurationBuilder, IConfiguration>> _massTransitConfigurationActions = [];

    public ConsumerConfiguration ConfigureServices(Action<IServiceCollection, IConfiguration> configurationAction)
    {
        _serviceConfigurationActions.Add(configurationAction);
        return this;
    }

    public ConsumerConfiguration ConfigureMassTransit(Action<IMassTransitConfigurationBuilder, IConfiguration> registerConsumersAction)
    {
        _massTransitConfigurationActions.Add(registerConsumersAction);
        return this;
    }

    public async Task RunAsync()
    {
        var args = Environment.GetCommandLineArgs();
        
        await Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((builder) =>
            {
                builder.AddDefaultAppConfiguration(args);
            })
            .ConfigureServices((hostContext, services) =>
            {
                RegisterServices(services, hostContext.Configuration);
            })
            .RunConsoleAsync();
    }

    private ServiceProvider RegisterServices(IServiceCollection serviceCollection, IConfiguration config)
    {
        serviceCollection.AddAzureAppConfiguration();
        serviceCollection.AddMassTransit(builder =>
        {
            builder.SetConfiguration(config);

            foreach (var action in _massTransitConfigurationActions)
            {
                action(builder, config);
            }
        });

        foreach (var action in _serviceConfigurationActions)
        {
            action(serviceCollection, config);
        }

        return serviceCollection.BuildServiceProvider();
    }

    public static ConsumerConfiguration CreateBuilder() => new();
}
