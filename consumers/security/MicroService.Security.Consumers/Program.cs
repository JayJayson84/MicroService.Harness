using MassTransit;
using MicroService.Configuration.Consumer;
using MicroService.Logging.Logger;
using MicroService.Security.Consumers;
using MicroService.Security.Encryption.Middleware;

await ConsumerConfiguration
    .CreateBuilder()
    .ConfigureServices((services, config) =>
    {
        services.AddConsoleLogger(MicroService.Logging.Enums.LoggerType.NLog);
        services.AddEncryptionMiddleware();
    })
    .ConfigureMassTransit((builder, config) =>
    {
        builder
            .SetConnectionName("broker")
            .AddConsumer<EncryptionConsumer>()
            .AddRetryIgnoreRule<ArgumentException>()
            .AddRetryIgnoreRule<ArgumentNullException>()
            .AddRetryIgnoreRule<ConsumerCanceledException>()
            .AddRetryIgnoreRule<HttpRequestException>()
            .AddRetryIgnoreRule<InvalidOperationException>()
            .AddRetryIgnoreRule<NotImplementedException>()
            .AddRetryIgnoreRule<PayloadException>()
            .AddRetryIgnoreRule<RequestFaultException>()
            .AddRetryIgnoreRule<TaskCanceledException>();
    })
    .RunAsync();
