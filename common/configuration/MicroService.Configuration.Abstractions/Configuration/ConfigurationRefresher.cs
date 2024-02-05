using MassTransit;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;
using Microsoft.Extensions.DependencyInjection;

namespace MicroService.Configuration;

public class ConfigurationRefresher<T> : IFilter<T> where T : class, PipeContext
{
    public ConfigurationRefresher(IServiceProvider serviceProvider)
    {
        try
        {
            Refreshers = serviceProvider
                .GetRequiredService<IConfigurationRefresherProvider>()
                .Refreshers;
        }
        catch (InvalidOperationException) { }
    }

    public IEnumerable<IConfigurationRefresher> Refreshers { get; } = [];

    public void Probe(ProbeContext context)
    {
        context.CreateFilterScope("ConfigurationRefresherScope");
    }

    public async Task Send(T context, IPipe<T> next)
    {
        Refreshers
            .ToList()
            .ForEach(r => r.TryRefreshAsync());

        await next.Send(context);
    }
}
