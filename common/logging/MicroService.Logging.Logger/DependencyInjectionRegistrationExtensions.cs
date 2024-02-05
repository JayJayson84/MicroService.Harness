using MicroService.Logging.Enums;
using MicroService.Logging.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MicroService.Logging.Logger;

/// <summary>
/// Register project dependencies with the service collection.
/// </summary>
public static class DependencyInjectionRegistrationExtensions
{

    #region IServiceCollection

    public static IServiceCollection AddConsoleLogger(this IServiceCollection serviceCollection, LoggerType loggerType, params LogRule[] logRules)
    {
        return loggerType switch
        {
            LoggerType.NLog => NLog.DependencyInjectionRegistrationExtensions.AddConsoleLogger(serviceCollection, logRules),
            _
            => throw new ArgumentException($"Invalid {nameof(LoggerType)}: {loggerType}")
        };
    }

    public static IServiceCollection AddConsoleLogger(this IServiceCollection serviceCollection, LoggerType loggerType, IConfiguration configuration, params LogRule[] logRules)
    {
        return loggerType switch
        {
            LoggerType.NLog => NLog.DependencyInjectionRegistrationExtensions.AddConsoleLogger(serviceCollection, configuration, logRules),
            _
            => throw new ArgumentException($"Invalid {nameof(LoggerType)}: {loggerType}")
        };
    }

    public static IServiceCollection AddFileLogger(this IServiceCollection serviceCollection, LoggerType loggerType, IConfiguration configuration, string logFilePath, params LogRule[] logRules)
    {
        return loggerType switch
        {
            LoggerType.NLog => NLog.DependencyInjectionRegistrationExtensions.AddFileLogger(serviceCollection, configuration, logFilePath, logRules),
            _
            => throw new ArgumentException($"Invalid {nameof(LoggerType)}: {loggerType}")
        };
    }

    public static IServiceCollection AddFileLogger(this IServiceCollection serviceCollection, LoggerType loggerType, string logFilePath, params LogRule[] logRules)
    {
        return loggerType switch
        {
            LoggerType.NLog => NLog.DependencyInjectionRegistrationExtensions.AddFileLogger(serviceCollection, logFilePath, logRules),
            _
            => throw new ArgumentException($"Invalid {nameof(LoggerType)}: {loggerType}")
        };
    }

    #endregion

    #region IHostBuilder

    public static IHostBuilder ConfigureConsoleLogging(this IHostBuilder builder, LoggerType loggerType, IConfiguration configuration, params LogRule[] logRules)
    {
        return loggerType switch
        {
            LoggerType.NLog => NLog.DependencyInjectionRegistrationExtensions.ConfigureConsoleLogging(builder, configuration, logRules),
            _
            => throw new ArgumentException($"Invalid {nameof(LoggerType)}: {loggerType}")
        };
    }

    public static IHostBuilder ConfigureConsoleLogging(this IHostBuilder builder, LoggerType loggerType, params LogRule[] logRules)
    {
        return loggerType switch
        {
            LoggerType.NLog => NLog.DependencyInjectionRegistrationExtensions.ConfigureConsoleLogging(builder, logRules),
            _
            => throw new ArgumentException($"Invalid {nameof(LoggerType)}: {loggerType}")
        };
    }

    public static IHostBuilder ConfigureFileLogging(this IHostBuilder builder, LoggerType loggerType, IConfiguration configuration, string logFilePath, params LogRule[] logRules)
    {
        return loggerType switch
        {
            LoggerType.NLog => NLog.DependencyInjectionRegistrationExtensions.ConfigureFileLogging(builder, configuration, logFilePath, logRules),
            _
            => throw new ArgumentException($"Invalid {nameof(LoggerType)}: {loggerType}")
        };
    }

    public static IHostBuilder ConfigureFileLogging(this IHostBuilder builder, LoggerType loggerType, string logFilePath, params LogRule[] logRules)
    {
        return loggerType switch
        {
            LoggerType.NLog => NLog.DependencyInjectionRegistrationExtensions.ConfigureFileLogging(builder, logFilePath, logRules),
            _
            => throw new ArgumentException($"Invalid {nameof(LoggerType)}: {loggerType}")
        };
    }

    #endregion

}
