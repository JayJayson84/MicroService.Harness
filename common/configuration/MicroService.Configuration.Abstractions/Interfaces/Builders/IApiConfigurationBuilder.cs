using MassTransit;

namespace MicroService.Configuration.Interfaces;

public interface IApiConfigurationBuilder
{
    IApiConfigurationBuilder AddConsumer<T>() where T : class, IConsumer;
    IApiConfigurationBuilder AddRequestClient<T>() where T : class;
    IApiConfigurationBuilder AddRetryIgnoreRule<T>() where T : Exception;
}
