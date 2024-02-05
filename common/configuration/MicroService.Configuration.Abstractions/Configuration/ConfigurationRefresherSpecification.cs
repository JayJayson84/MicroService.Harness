using MassTransit;
using MassTransit.Configuration;

namespace MicroService.Configuration;

public class ConfigurationRefresherSpecification<T>(IServiceProvider serviceProvider) : IPipeSpecification<T> where T : class, PipeContext
{
    readonly IServiceProvider _serviceProvider = serviceProvider;

    public void Apply(IPipeBuilder<T> builder)
    {
        builder.AddFilter(new ConfigurationRefresher<T>(_serviceProvider));
    }

    public IEnumerable<ValidationResult> Validate()
    {
        return [];
    }
}
