using System.Reflection;
using MassTransit;
using Microsoft.Extensions.Configuration;

namespace MicroService.Configuration.Interfaces;

public interface IMassTransitConfigurationBuilder
{
    IMassTransitConfigurationBuilder AddConsumer<T>() where T : class, IConsumer;
    IMassTransitConfigurationBuilder AddConsumers(params Assembly[] assemblies);
    IMassTransitConfigurationBuilder AddRequestClient<T>() where T : class;
    IMassTransitConfigurationBuilder AddRetryIgnoreRule<T>() where T : Exception;
    IMassTransitConfigurationBuilder AddRetryIgnoreRule<T>(Func<T, bool> filter) where T : Exception;
    IMassTransitConfigurationBuilder ConfigureRetry(int retryCount, TimeSpan? retryInterval = null);
    IMassTransitConfigurationBuilder DisableRetry();
    IMassTransitConfigurationBuilder SetConfiguration(IConfiguration configuration);
    IMassTransitConfigurationBuilder SetConnectionName(string connectionName);
    IMassTransitConfigurationBuilder SetPrefetchCount(int prefetchCount);
    IMassTransitConfigurationBuilder SetQuorumQueues();
}
