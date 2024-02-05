using MicroService.Logging.Models;
using MicroService.Logging.NLog.Resources;
using Microsoft.Extensions.Configuration;
using NLog;
using NLog.Config;
using NLog.Extensions.Logging;
using NLog.Targets;

namespace MicroService.Logging.NLog.Utility;

internal static partial class ConfigurationProvider
{
    internal static LoggingConfiguration CreateConsoleConfiguration(IConfiguration? configuration, params LogRule[] logRules)
    {
        var target = new ConsoleTarget("Console")
        {
            Layout = LayoutProvider.GenerateJsonLayout()
        };

        return CreateConfiguration(configuration, target, logRules);
    }

    internal static LoggingConfiguration CreateConsoleConfiguration(params LogRule[] logRules)
    {
        var target = new ConsoleTarget("Console")
        {
            Layout = LayoutProvider.GenerateJsonLayout()
        };

        return CreateConfiguration(target, logRules);
    }

    internal static LoggingConfiguration CreateDebugConfiguration(IConfiguration? configuration, params LogRule[] logRules)
    {
        var target = new DebuggerTarget()
        {
            Layout = LayoutProvider.GenerateJsonLayout()
        };

        return CreateConfiguration(configuration, target, logRules);
    }

    internal static LoggingConfiguration CreateDebugConfiguration(params LogRule[] logRules)
    {
        var target = new DebuggerTarget()
        {
            Layout = LayoutProvider.GenerateJsonLayout()
        };

        return CreateConfiguration(target, logRules);
    }

    internal static LoggingConfiguration CreateFileConfiguration(IConfiguration? configuration, string logFilePath, params LogRule[] logRules)
    {
        var target = new FileTarget("File")
        {
            FileName = logFilePath,
            Layout = LayoutProvider.GenerateJsonLayout()
        };

        return CreateConfiguration(configuration, target, logRules);
    }

    internal static LoggingConfiguration CreateFileConfiguration(string logFilePath, params LogRule[] logRules)
    {
        var target = new FileTarget("File")
        {
            FileName = logFilePath,
            Layout = LayoutProvider.GenerateJsonLayout()
        };

        return CreateConfiguration(target, logRules);
    }

    internal static NLogProviderOptions CreateProviderOptions()
    {
        return new NLogProviderOptions() { ReplaceLoggerFactory = true };
    }

    private static LoggingConfiguration CreateConfiguration(IConfiguration? configuration, Target target, params LogRule[] logRules)
    {
        var config = new LoggingConfiguration();

        foreach (var logRule in logRules)
        {
            config.AddRule(LogLevelProvider.StringToLogLevel(logRule.MinLevel), LogLevelProvider.StringToLogLevel(logRule.MaxLevel), target, logRule.LoggerNamePattern);
        }

        foreach (var logLevel in configuration?.GetSection("Logging:LogLevel")?.GetChildren() ?? Enumerable.Empty<IConfigurationSection>())
        {
            if (!Expressions.LogLevel().IsMatch(logLevel.Key)) continue;

            if (logLevel.Key == "Default")
            {
                config.AddRule(LogLevelProvider.StringToLogLevel(logLevel.Value), LogLevel.Fatal, target, "*");
                continue;
            }

            config.AddRule(LogLevelProvider.StringToLogLevel(logLevel.Value), LogLevel.Fatal, target, $"{logLevel.Key}.*");
        }

        if (!config.LoggingRules.Any())
        {
            config.AddRule(LogLevel.Info, LogLevel.Fatal, target, "*");
        }

        return config;
    }

    private static LoggingConfiguration CreateConfiguration(Target target, params LogRule[] logRules)
    {
        var config = new LoggingConfiguration();

        foreach (var logRule in logRules)
        {
            config.AddRule(LogLevelProvider.StringToLogLevel(logRule.MinLevel), LogLevelProvider.StringToLogLevel(logRule.MaxLevel), target, logRule.LoggerNamePattern);
        }

        if (!config.LoggingRules.Any())
        {
            config.AddRule(LogLevel.Info, LogLevel.Fatal, target, "*");
        }

        return config;
    }
}
