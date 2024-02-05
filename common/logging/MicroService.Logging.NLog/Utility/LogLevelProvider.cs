using NLog;

namespace MicroService.Logging.NLog.Utility;

internal static class LogLevelProvider
{
    internal static LogLevel StringToLogLevel(string? logLevel)
    {
        return logLevel switch
        {
            // Common LogLevels
            "Debug" => LogLevel.Debug,
            "Error" => LogLevel.Error,
            "Trace" => LogLevel.Trace,
            // Microsoft.Extensions.Logging.LogLevel
            "Critical" => LogLevel.Fatal,
            "Information" => LogLevel.Info,
            "None" => LogLevel.Off,
            "Warning" => LogLevel.Warn,
            // NLog.LogLevel
            "Fatal" => LogLevel.Fatal,
            "Info" => LogLevel.Info,
            "Off" => LogLevel.Off,
            "Warn" => LogLevel.Warn,
            _ => LogLevel.Warn
        };
    }
}
