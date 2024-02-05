using System.Reflection;
using MassTransit;
using MicroService.Configuration.Interfaces;
using Microsoft.Extensions.Configuration;

namespace MicroService.Configuration.Builders;

public class MassTransitConfigurationBuilder : IMassTransitConfigurationBuilder
{

    #region Constants

    const int DEFAULT_RETRY_COUNT = 3;
    const int DEFAULT_RETRY_INTERVAL_SECONDS = 60;

    #endregion

    #region Fields

    readonly List<Action<IBusRegistrationConfigurator>> _globalConfigurationActions = [];
    readonly List<Action<IBusRegistrationContext, IRabbitMqBusFactoryConfigurator>> _rabbitMqConfigurationActions = [];
    readonly List<Action<IRetryConfigurator>> _retryConfigurationActions = [];
    private int _retryCount = DEFAULT_RETRY_COUNT;
    private TimeSpan _retryInterval = TimeSpan.FromSeconds(DEFAULT_RETRY_INTERVAL_SECONDS);

    #endregion
    
    #region Properties

    public IConfiguration Configuration { get; private set; } = null!;
    public string ConnectionName { get; private set; } = AppDomain.CurrentDomain.FriendlyName;
    public bool UseQuorumQueues { get; private set; }

    #endregion

    #region Public Methods

    public void ApplyGlobalConfig(IBusRegistrationConfigurator configurator)
    {
        foreach (var action in _globalConfigurationActions)
        {
            action(configurator);
        }
    }

    public void ApplyRabbitMqConfig(IBusRegistrationContext context, IRabbitMqBusFactoryConfigurator configurator)
    {
        if (_retryCount > 0)
        {
            _rabbitMqConfigurationActions.Add((ctx, cfg) =>
            {
                cfg.UseMessageRetry(r =>
                {
                    r.Interval(_retryCount, _retryInterval);
                    foreach (var action in _retryConfigurationActions)
                    {
                        action(r);
                    }
                });
            });
        }

        foreach (var action in _rabbitMqConfigurationActions)
        {
            action(context, configurator);
        }
    }

    #endregion

    #region Interface Members

    public IMassTransitConfigurationBuilder AddConsumer<T>() where T : class, IConsumer
    {
        _globalConfigurationActions.Add(configurator => configurator.AddConsumer<T>());
        return this;
    }

    public IMassTransitConfigurationBuilder AddConsumers(params Assembly[] assemblies)
    {
        _globalConfigurationActions.Add(configurator => configurator.AddConsumers(assemblies));
        return this;
    }

    public IMassTransitConfigurationBuilder AddRequestClient<T>() where T : class
    {
        _globalConfigurationActions.Add(configurator => configurator.AddRequestClient<T>());
        return this;
    }

    public IMassTransitConfigurationBuilder AddRetryIgnoreRule<T>() where T : Exception
    {
        _retryConfigurationActions.Add(configurator => configurator.Ignore<T>());
        return this;
    }

    public IMassTransitConfigurationBuilder AddRetryIgnoreRule<T>(Func<T, bool> filter) where T : Exception
    {
        _retryConfigurationActions.Add(configurator => configurator.Ignore(filter));
        return this;
    }

    public IMassTransitConfigurationBuilder ConfigureRetry(int retryCount, TimeSpan? retryInterval = null)
    {
        _retryCount = retryCount;
        _retryInterval = retryInterval ?? _retryInterval;
        return this;
    }

    public IMassTransitConfigurationBuilder DisableRetry()
    {
        return ConfigureRetry(0);
    }

    public IMassTransitConfigurationBuilder SetConfiguration(IConfiguration configuration)
    {
        Configuration = configuration;
        return this;
    }

    public IMassTransitConfigurationBuilder SetConnectionName(string connectionName)
    {
        ConnectionName = connectionName;
        return this;
    }

    public IMassTransitConfigurationBuilder SetPrefetchCount(int prefetchCount)
    {
        _rabbitMqConfigurationActions.Add((ctx, configurator) => configurator.PrefetchCount = prefetchCount);
        return this;
    }

    public IMassTransitConfigurationBuilder SetQuorumQueues()
    {
        UseQuorumQueues = true;
        return this;
    }

    #endregion

}
