using MicroService.Logging.Models;
using Microsoft.Extensions.Logging;

namespace MicroService.Logging.Builders;

public sealed class LogRuleBuilder
{
    readonly LogRule _logRule = new();

    public LogRuleBuilder WithMinLevel(LogLevel minLevel)
    {
        _logRule.MinLevel = minLevel.ToString();
        return this;
    }

    public LogRuleBuilder WithMinLevel(string? minLevel)
    {
        _logRule.MinLevel = minLevel;
        return this;
    }

    public LogRuleBuilder WithMaxLevel(LogLevel maxLevel)
    {
        _logRule.MaxLevel = maxLevel.ToString();
        return this;
    }

    public LogRuleBuilder WithMaxLevel(string? maxLevel)
    {
        _logRule.MaxLevel = maxLevel;
        return this;
    }

    public LogRuleBuilder WithLoggerNamePattern(string? loggerNamePattern)
    {
        _logRule.LoggerNamePattern = loggerNamePattern;
        return this;
    }

    public LogRule Build() {
        var logRule = _logRule;
        return logRule;
    }

    public static LogRuleBuilder Init() => new();
}
