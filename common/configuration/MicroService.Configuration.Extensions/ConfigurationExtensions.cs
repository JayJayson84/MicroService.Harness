using Azure.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;

namespace MicroService.Configuration.Extensions;

public static class ConfigurationExtensions
{
    public static IConfigurationBuilder AddDefaultAppConfiguration(this IConfigurationBuilder builder, string[] args)
    {
        var configBuilder = new ConfigurationBuilder();
        var config = configBuilder
            .AddEnvironmentVariables()
            .AddCommandLine(args)
            .Build();

        var environment = config["MICROSERVICE_ENVIRONMENT"] ?? config["ASPNETCORE_ENVIRONMENT"] ?? "Development";

        configBuilder = new ConfigurationBuilder();
        config = configBuilder
            .AddJsonFile("appsettings.json", optional: true)
            .AddJsonFile($"appsettings.{environment}.json", optional: true)
            .AddJsonFile("appsettings.Secrets.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        environment = config["MICROSERVICE_ENVIRONMENT"] ?? config["ASPNETCORE_ENVIRONMENT"] ?? "Development";

        if (config.IsAacConfigured())
        {
            builder.AddAzureAppConfiguration((opt) =>
            {
                if (!string.IsNullOrWhiteSpace(config["AZURE_APP_CONFIG_CONNECTION_STRING"]))
                {
                    opt.Connect(config["AZURE_APP_CONFIG_CONNECTION_STRING"]);
                }
                else if (!string.IsNullOrWhiteSpace(config["AZURE_APP_CONFIG_ENDPOINT"]))
                {
                    opt.Connect(new Uri(config["AZURE_APP_CONFIG_ENDPOINT"]!), new ManagedIdentityCredential());
                }
                else
                {
                    throw new InvalidOperationException("One of either AZURE_APP_CONFIG_CONNECTION_STRING (with complete connection string) or AZURE_APP_CONFIG_ENDPOINT (with only the config endpoint so that managed identity will be used) environment variable must be set.");
                }

                opt.UseFeatureFlags(flagOptions =>
                {
                    flagOptions.CacheExpirationInterval = TimeSpan.FromMinutes(1);
                    flagOptions.Label = environment;
                });

                opt.ConfigureRefresh(refresh =>
                {
                    refresh
                        .Register("microservice:common:sentinel", refreshAll: true)
                        .SetCacheExpiration(TimeSpan.FromMinutes(1));
                })
                .Select(KeyFilter.Any)
                .Select(KeyFilter.Any, environment);
            });
        }

        return builder
            .AddJsonFile("appsettings.json", optional: true)
            .AddJsonFile($"appsettings.{environment}.json", optional: true)
            .AddJsonFile($"appsettings.Secrets.json", optional: true)
            .AddEnvironmentVariables()
            .AddCommandLine(args);
    }

    public static bool GetBool(this IConfiguration config, string key, bool defaultValue = false)
    {
        return bool.TryParse(config[key], out var value)
            ? value
            : defaultValue;
    }

    public static bool IsAacConfigured(this IConfiguration config)
    {
        var azureConfigRequired = config.GetBool("AZURE_APP_CONFIG_REQUIRED", defaultValue: true);
        return azureConfigRequired
            || !string.IsNullOrWhiteSpace(config["AZURE_APP_CONFIG_CONNECTION_STRING"])
            || !string.IsNullOrWhiteSpace(config["AZURE_APP_CONFIG_ENDPOINT"]);
    }
}
