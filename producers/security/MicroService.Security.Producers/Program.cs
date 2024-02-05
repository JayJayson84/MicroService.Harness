using MicroService.Configuration.WebApi;
using MicroService.Logging.Logger;
using MicroService.Security.Producers;

var assemblyInfo = AssemblyInfo.GetAssembly();

WebApiConfiguration
    .CreateBuilder()
    .ConfigureServices((services, config) =>
    {
        services.AddConsoleLogger(MicroService.Logging.Enums.LoggerType.NLog);
    })
    .ConfigureMassTransit((builder, config) =>
    {
        builder.SetConnectionName("broker");
    })
    .Run(assemblyInfo!.GetName());
