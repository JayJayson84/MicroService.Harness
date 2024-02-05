using System.Diagnostics.CodeAnalysis;
using MicroService.Logging.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Config;
using NLog.Extensions.Logging;
using ConfigurationProvider = MicroService.Logging.NLog.Utility.ConfigurationProvider;

namespace MicroService.Logging.NLog;

public static class DependencyInjectionRegistrationExtensions
{

    #region IServiceCollection

    public static IServiceCollection AddConsoleLogger(this IServiceCollection serviceCollection, IConfiguration configuration, params LogRule[] logRules)
    {
#if DEBUG
        return RegisterDebugLogger(serviceCollection, configuration, logRules);
#else
        return RegisterConsoleLogger(serviceCollection, configuration, logRules);
#endif
    }

    public static IServiceCollection AddConsoleLogger(this IServiceCollection serviceCollection, params LogRule[] logRules)
    {
#if DEBUG
        return RegisterDebugLogger(serviceCollection, logRules);
#else
        return RegisterConsoleLogger(serviceCollection, logRules);
#endif
    }

    public static IServiceCollection AddFileLogger(IServiceCollection serviceCollection, IConfiguration configuration, string logFilePath, params LogRule[] logRules)
    {
        var config = ConfigurationProvider.CreateFileConfiguration(configuration, logFilePath, logRules);
        var options = ConfigurationProvider.CreateProviderOptions();

        return serviceCollection.RegisterNLog(config, options);
    }

    public static IServiceCollection AddFileLogger(IServiceCollection serviceCollection, string logFilePath, params LogRule[] logRules)
    {
        var config = ConfigurationProvider.CreateFileConfiguration(logFilePath, logRules);
        var options = ConfigurationProvider.CreateProviderOptions();

        return serviceCollection.RegisterNLog(config, options);
    }

    [SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Dependency on Build Configuration.")]
    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "Dependency on Build Configuration.")]
    private static IServiceCollection RegisterConsoleLogger(this IServiceCollection serviceCollection, IConfiguration configuration, params LogRule[] logRules)
    {
        var config = ConfigurationProvider.CreateConsoleConfiguration(configuration, logRules);
        var options = ConfigurationProvider.CreateProviderOptions();

        return serviceCollection.RegisterNLog(config, options);
    }

    [SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Dependency on Build Configuration.")]
    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "Dependency on Build Configuration.")]
    private static IServiceCollection RegisterConsoleLogger(this IServiceCollection serviceCollection, params LogRule[] logRules)
    {
        var config = ConfigurationProvider.CreateConsoleConfiguration(logRules);
        var options = ConfigurationProvider.CreateProviderOptions();

        return serviceCollection.RegisterNLog(config, options);
    }

    [SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Dependency on Build Configuration.")]
    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "Dependency on Build Configuration.")]
    private static IServiceCollection RegisterDebugLogger(this IServiceCollection serviceCollection, IConfiguration configuration, params LogRule[] logRules)
    {
        var config = ConfigurationProvider.CreateDebugConfiguration(configuration, logRules);
        var options = ConfigurationProvider.CreateProviderOptions();

        return serviceCollection.RegisterNLog(config, options);
    }

    [SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Dependency on Build Configuration.")]
    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "Dependency on Build Configuration.")]
    private static IServiceCollection RegisterDebugLogger(this IServiceCollection serviceCollection, params LogRule[] logRules)
    {
        var config = ConfigurationProvider.CreateDebugConfiguration(logRules);
        var options = ConfigurationProvider.CreateProviderOptions();

        return serviceCollection.RegisterNLog(config, options);
    }

    private static IServiceCollection RegisterNLog(this IServiceCollection serviceCollection, LoggingConfiguration config, NLogProviderOptions options)
    {
        LogManager.Configuration = config;

        serviceCollection.AddLogging(builder =>
        {
            builder.ClearProviders();
            builder.AddNLog(config, options);
        });

        return serviceCollection;
    }

    #endregion

    #region IHostBuilder

    public static IHostBuilder ConfigureConsoleLogging(this IHostBuilder builder, IConfiguration configuration, params LogRule[] logRules)
    {
#if DEBUG
        return RegisterDebugLogger(builder, configuration, logRules);
#else
        return RegisterConsoleLogger(builder, configuration, logRules);
#endif
    }

    public static IHostBuilder ConfigureConsoleLogging(this IHostBuilder builder, params LogRule[] logRules)
    {
#if DEBUG
        return RegisterDebugLogger(builder, logRules);
#else
        return RegisterConsoleLogger(builder, logRules);
#endif
    }

    public static IHostBuilder ConfigureFileLogging(IHostBuilder serviceCollection, IConfiguration configuration, string logFilePath, params LogRule[] logRules)
    {
        var config = ConfigurationProvider.CreateFileConfiguration(configuration, logFilePath, logRules);
        var options = ConfigurationProvider.CreateProviderOptions();

        return serviceCollection.RegisterNLog(config, options);
    }

    public static IHostBuilder ConfigureFileLogging(IHostBuilder serviceCollection, string logFilePath, params LogRule[] logRules)
    {
        var config = ConfigurationProvider.CreateFileConfiguration(logFilePath, logRules);
        var options = ConfigurationProvider.CreateProviderOptions();

        return serviceCollection.RegisterNLog(config, options);
    }

    [SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Dependency on Build Configuration.")]
    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "Dependency on Build Configuration.")]
    private static IHostBuilder RegisterConsoleLogger(this IHostBuilder builder, IConfiguration configuration, params LogRule[] logRules)
    {
        var config = ConfigurationProvider.CreateConsoleConfiguration(configuration, logRules);
        var options = ConfigurationProvider.CreateProviderOptions();

        return builder.RegisterNLog(config, options);
    }

    [SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Dependency on Build Configuration.")]
    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "Dependency on Build Configuration.")]
    private static IHostBuilder RegisterConsoleLogger(this IHostBuilder builder, params LogRule[] logRules)
    {
        var config = ConfigurationProvider.CreateConsoleConfiguration(logRules);
        var options = ConfigurationProvider.CreateProviderOptions();

        return builder.RegisterNLog(config, options);
    }

    [SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Dependency on Build Configuration.")]
    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "Dependency on Build Configuration.")]
    private static IHostBuilder RegisterDebugLogger(this IHostBuilder builder, IConfiguration configuration, params LogRule[] logRules)
    {
        var config = ConfigurationProvider.CreateDebugConfiguration(configuration, logRules);
        var options = ConfigurationProvider.CreateProviderOptions();

        return builder.RegisterNLog(config, options);
    }

    [SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Dependency on Build Configuration.")]
    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "Dependency on Build Configuration.")]
    private static IHostBuilder RegisterDebugLogger(this IHostBuilder builder, params LogRule[] logRules)
    {
        var config = ConfigurationProvider.CreateDebugConfiguration(logRules);
        var options = ConfigurationProvider.CreateProviderOptions();

        return builder.RegisterNLog(config, options);
    }

    private static IHostBuilder RegisterNLog(this IHostBuilder builder, LoggingConfiguration config, NLogProviderOptions options)
    {
        LogManager.Configuration = config;

        builder.ConfigureLogging(builder =>
        {
            builder.ClearProviders();
            builder.AddNLog(config, options);
        });

        return builder;
    }

    #endregion

}
