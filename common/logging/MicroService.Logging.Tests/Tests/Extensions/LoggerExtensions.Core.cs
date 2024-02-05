using MicroService.Logging.Extensions;
using MicroService.Logging.Tests.DSL.Builders;
using MicroService.Logging.Tests.Utility;
using Microsoft.Extensions.Logging;

namespace MicroService.Logging.Tests.Tests.Extensions;

#pragma warning disable CA2254

public partial class LoggerExtensions
{

    #region Log Action

    [Theory]
    [InlineData(LogLevel.Critical)]
    [InlineData(LogLevel.Debug)]
    [InlineData(LogLevel.Error)]
    [InlineData(LogLevel.Information)]
    [InlineData(LogLevel.Trace)]
    [InlineData(LogLevel.Warning)]
    public void LogWithContext_GivenLogActionWithMessage_BeginScopeAndLog(LogLevel logLevel)
    {
        // Arrange
        var message = ValueProvider.LogMessage;
        var sut = LoggerTestBuilder<LoggerExtensions>
            .ConfigureTests()
            .WithLogLevel(logLevel)
            .WithMessage(message)
            .Build();

        // Act
        switch (logLevel)
        {
            case LogLevel.Critical:
                sut.Logger.LogWithContext(() => sut.Logger.LogCritical(message));
                break;
            case LogLevel.Debug:
                sut.Logger.LogWithContext(() => sut.Logger.LogDebug(message));
                break;
            case LogLevel.Error:
                sut.Logger.LogWithContext(() => sut.Logger.LogError(message));
                break;
            case LogLevel.Information:
                sut.Logger.LogWithContext(() => sut.Logger.LogInformation(message));
                break;
            case LogLevel.Trace:
                sut.Logger.LogWithContext(() => sut.Logger.LogTrace(message));
                break;
            case LogLevel.Warning:
                sut.Logger.LogWithContext(() => sut.Logger.LogWarning(message));
                break;
            default:
                throw new ArgumentException(null, nameof(logLevel));
        }

        // Assert
        sut.Assert.VerifyScope();
        sut.Assert.VerifyLog();
    }

    [Theory]
    [InlineData(LogLevel.Critical)]
    [InlineData(LogLevel.Debug)]
    [InlineData(LogLevel.Error)]
    [InlineData(LogLevel.Information)]
    [InlineData(LogLevel.Trace)]
    [InlineData(LogLevel.Warning)]
    public void LogWithContext_GivenLogActionWithMessageAndContextData_BeginScopeAndLog(LogLevel logLevel)
    {
        // Arrange
        var contextId = ValueProvider.RandomGuid();
        var contextData = ValueProvider.ContextData(contextId);
        var message = ValueProvider.LogMessage;
        var sut = LoggerTestBuilder<LoggerExtensions>
            .ConfigureTests()
            .WithLogLevel(logLevel)
            .WithContextData(contextId)
            .WithMessage(message)
            .Build();

        // Act
        switch (logLevel)
        {
            case LogLevel.Critical:
                sut.Logger.LogWithContext(() => sut.Logger.LogCritical(message), contextData);
                break;
            case LogLevel.Debug:
                sut.Logger.LogWithContext(() => sut.Logger.LogDebug(message), contextData);
                break;
            case LogLevel.Error:
                sut.Logger.LogWithContext(() => sut.Logger.LogError(message), contextData);
                break;
            case LogLevel.Information:
                sut.Logger.LogWithContext(() => sut.Logger.LogInformation(message), contextData);
                break;
            case LogLevel.Trace:
                sut.Logger.LogWithContext(() => sut.Logger.LogTrace(message), contextData);
                break;
            case LogLevel.Warning:
                sut.Logger.LogWithContext(() => sut.Logger.LogWarning(message), contextData);
                break;
            default:
                throw new ArgumentException(null, nameof(logLevel));
        }

        // Assert
        sut.Assert.VerifyScope();
        sut.Assert.VerifyLog();
    }

    [Theory]
    [InlineData(LogLevel.Critical)]
    [InlineData(LogLevel.Debug)]
    [InlineData(LogLevel.Error)]
    [InlineData(LogLevel.Information)]
    [InlineData(LogLevel.Trace)]
    [InlineData(LogLevel.Warning)]
    public void LogWithContext_GivenLogActionWithMessageAndContextAttributes_BeginScopeAndLog(LogLevel logLevel)
    {
        // Arrange
        var contextAttributes = ValueProvider.ContextAttributes();
        var message = ValueProvider.LogMessage;
        var sut = LoggerTestBuilder<LoggerExtensions>
            .ConfigureTests()
            .WithLogLevel(logLevel)
            .WithContextData(contextAttributes.ContextId)
            .WithMessage(message)
            .Build();

        // Act
        switch (logLevel)
        {
            case LogLevel.Critical:
                sut.Logger.LogWithContext(() => sut.Logger.LogCritical(message), contextAttributes);
                break;
            case LogLevel.Debug:
                sut.Logger.LogWithContext(() => sut.Logger.LogDebug(message), contextAttributes);
                break;
            case LogLevel.Error:
                sut.Logger.LogWithContext(() => sut.Logger.LogError(message), contextAttributes);
                break;
            case LogLevel.Information:
                sut.Logger.LogWithContext(() => sut.Logger.LogInformation(message), contextAttributes);
                break;
            case LogLevel.Trace:
                sut.Logger.LogWithContext(() => sut.Logger.LogTrace(message), contextAttributes);
                break;
            case LogLevel.Warning:
                sut.Logger.LogWithContext(() => sut.Logger.LogWarning(message), contextAttributes);
                break;
            default:
                throw new ArgumentException(null, nameof(logLevel));
        }

        // Assert
        sut.Assert.VerifyScope();
        sut.Assert.VerifyLog();
    }

    #endregion

    #region Log Scope

    [Fact]
    public void BeginScopeWithContext_BeginScope()
    {
        // Arrange
        var sut = LoggerTestBuilder<LoggerExtensions>
            .ConfigureTests()
            .Build();

        // Act
        var result = sut.Logger.BeginScopeWithContext();

        // Assert
        Assert.IsAssignableFrom<IDisposable>(result);
        sut.Assert.VerifyScope();
    }

    [Fact]
    public void BeginScopeWithContext_GivenContextData_BeginScopeWithContextData()
    {
        // Arrange
        var contextId = ValueProvider.RandomGuid();
        var contextData = ValueProvider.ContextData(contextId);
        var sut = LoggerTestBuilder<LoggerExtensions>
            .ConfigureTests()
            .WithContextData(contextId)
            .Build();

        // Act
        var result = sut.Logger.BeginScopeWithContext(contextData);

        // Assert
        Assert.IsAssignableFrom<IDisposable>(result);
        sut.Assert.VerifyScope();
    }

    [Fact]
    public void BeginScopeWithContext_GivenContextAttributes_BeginScopeWithContextAttributes()
    {
        // Arrange
        var contextAttributes = ValueProvider.ContextAttributes();
        var sut = LoggerTestBuilder<LoggerExtensions>
            .ConfigureTests()
            .WithContextData(contextAttributes.ContextId)
            .Build();

        // Act
        var result = sut.Logger.BeginScopeWithContext(contextAttributes);

        // Assert
        Assert.IsAssignableFrom<IDisposable>(result);
        sut.Assert.VerifyScope();
    }

    #endregion

}

#pragma warning restore CA2254