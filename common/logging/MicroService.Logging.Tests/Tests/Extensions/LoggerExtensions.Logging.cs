using MicroService.Logging.Extensions;
using MicroService.Logging.Tests.DSL.Builders;
using MicroService.Logging.Tests.Utility;
using Microsoft.Extensions.Logging;

namespace MicroService.Logging.Tests.Tests.Extensions;

public partial class LoggerExtensions
{

    #region Log

    [Theory]
    [InlineData(LogLevel.Critical)]
    [InlineData(LogLevel.Debug)]
    [InlineData(LogLevel.Error)]
    [InlineData(LogLevel.Information)]
    [InlineData(LogLevel.Trace)]
    [InlineData(LogLevel.Warning)]
    public void LogWithContext_GivenMessage_BeginScopeAndLog(LogLevel logLevel)
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
                sut.Logger.LogCriticalWithContext(message);
                break;
            case LogLevel.Debug:
                sut.Logger.LogDebugWithContext(message);
                break;
            case LogLevel.Error:
                sut.Logger.LogErrorWithContext(message);
                break;
            case LogLevel.Information:
                sut.Logger.LogInformationWithContext(message);
                break;
            case LogLevel.Trace:
                sut.Logger.LogTraceWithContext(message);
                break;
            case LogLevel.Warning:
                sut.Logger.LogWarningWithContext(message);
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
    public void LogWithContext_GivenMessageAndMessageArgsParams_BeginScopeAndLog(LogLevel logLevel)
    {
        // Arrange
        var message = ValueProvider.LogMessageWithExpressionBody;
        var messageId = ValueProvider.RandomGuid();
        var sut = LoggerTestBuilder<LoggerExtensions>
            .ConfigureTests()
            .WithLogLevel(logLevel)
            .WithMessage(message)
            .WithMessageArg(messageId)
            .Build();

        // Act
        switch (logLevel)
        {
            case LogLevel.Critical:
                sut.Logger.LogCriticalWithContext(message, messageArgs: messageId);
                break;
            case LogLevel.Debug:
                sut.Logger.LogDebugWithContext(message, messageArgs: messageId);
                break;
            case LogLevel.Error:
                sut.Logger.LogErrorWithContext(message, messageArgs: messageId);
                break;
            case LogLevel.Information:
                sut.Logger.LogInformationWithContext(message, messageArgs: messageId);
                break;
            case LogLevel.Trace:
                sut.Logger.LogTraceWithContext(message, messageArgs: messageId);
                break;
            case LogLevel.Warning:
                sut.Logger.LogWarningWithContext(message, messageArgs: messageId);
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
    public void LogWithContext_GivenMessageAndMessageArgsArray_BeginScopeAndLog(LogLevel logLevel)
    {
        // Arrange
        var message = ValueProvider.LogMessageWithExpressionBody;
        var messageId = ValueProvider.RandomGuid();
        var sut = LoggerTestBuilder<LoggerExtensions>
            .ConfigureTests()
            .WithLogLevel(logLevel)
            .WithMessage(message)
            .WithMessageArg(messageId)
            .Build();

        // Act
        switch (logLevel)
        {
            case LogLevel.Critical:
                sut.Logger.LogCriticalWithContext(message, new object[] { messageId });
                break;
            case LogLevel.Debug:
                sut.Logger.LogDebugWithContext(message, new object[] { messageId });
                break;
            case LogLevel.Error:
                sut.Logger.LogErrorWithContext(message, new object[] { messageId });
                break;
            case LogLevel.Information:
                sut.Logger.LogInformationWithContext(message, new object[] { messageId });
                break;
            case LogLevel.Trace:
                sut.Logger.LogTraceWithContext(message, new object[] { messageId });
                break;
            case LogLevel.Warning:
                sut.Logger.LogWarningWithContext(message, new object[] { messageId });
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
    public void LogWithContext_GivenEventIdAndMessage_BeginScopeAndLog(LogLevel logLevel)
    {
        // Arrange
        var eventId = ValueProvider.RandomEventId();
        var message = ValueProvider.LogMessage;
        var sut = LoggerTestBuilder<LoggerExtensions>
            .ConfigureTests()
            .WithLogLevel(logLevel)
            .WithEventId(eventId)
            .WithMessage(message)
            .Build();

        // Act
        switch (logLevel)
        {
            case LogLevel.Critical:
                sut.Logger.LogCriticalWithContext(eventId, message);
                break;
            case LogLevel.Debug:
                sut.Logger.LogDebugWithContext(eventId, message);
                break;
            case LogLevel.Error:
                sut.Logger.LogErrorWithContext(eventId, message);
                break;
            case LogLevel.Information:
                sut.Logger.LogInformationWithContext(eventId, message);
                break;
            case LogLevel.Trace:
                sut.Logger.LogTraceWithContext(eventId, message);
                break;
            case LogLevel.Warning:
                sut.Logger.LogWarningWithContext(eventId, message);
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
    public void LogWithContext_GivenEventIdAndMessageAndMessageArgsParams_BeginScopeAndLog(LogLevel logLevel)
    {
        // Arrange
        var eventId = ValueProvider.RandomEventId();
        var message = ValueProvider.LogMessageWithExpressionBody;
        var messageId = ValueProvider.RandomGuid();
        var sut = LoggerTestBuilder<LoggerExtensions>
            .ConfigureTests()
            .WithLogLevel(logLevel)
            .WithEventId(eventId)
            .WithMessage(message)
            .WithMessageArg(messageId)
            .Build();

        // Act
        switch (logLevel)
        {
            case LogLevel.Critical:
                sut.Logger.LogCriticalWithContext(eventId, message, messageArgs: messageId);
                break;
            case LogLevel.Debug:
                sut.Logger.LogDebugWithContext(eventId, message, messageArgs: messageId);
                break;
            case LogLevel.Error:
                sut.Logger.LogErrorWithContext(eventId, message, messageArgs: messageId);
                break;
            case LogLevel.Information:
                sut.Logger.LogInformationWithContext(eventId, message, messageArgs: messageId);
                break;
            case LogLevel.Trace:
                sut.Logger.LogTraceWithContext(eventId, message, messageArgs: messageId);
                break;
            case LogLevel.Warning:
                sut.Logger.LogWarningWithContext(eventId, message, messageArgs: messageId);
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
    public void LogWithContext_GivenEventIdAndMessageAndMessageArgsArray_BeginScopeAndLog(LogLevel logLevel)
    {
        // Arrange
        var eventId = ValueProvider.RandomEventId();
        var message = ValueProvider.LogMessageWithExpressionBody;
        var messageId = ValueProvider.RandomGuid();
        var messageArgArray = new object[] { messageId };
        var sut = LoggerTestBuilder<LoggerExtensions>
            .ConfigureTests()
            .WithLogLevel(logLevel)
            .WithEventId(eventId)
            .WithMessage(message)
            .WithMessageArg(messageId)
            .Build();

        // Act
        switch (logLevel)
        {
            case LogLevel.Critical:
                sut.Logger.LogCriticalWithContext(eventId, message, messageArgArray);
                break;
            case LogLevel.Debug:
                sut.Logger.LogDebugWithContext(eventId, message, messageArgArray);
                break;
            case LogLevel.Error:
                sut.Logger.LogErrorWithContext(eventId, message, messageArgArray);
                break;
            case LogLevel.Information:
                sut.Logger.LogInformationWithContext(eventId, message, messageArgArray);
                break;
            case LogLevel.Trace:
                sut.Logger.LogTraceWithContext(eventId, message, messageArgArray);
                break;
            case LogLevel.Warning:
                sut.Logger.LogWarningWithContext(eventId, message, messageArgArray);
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
    public void LogWithContext_GivenEventIdAndMessageOnException_BeginScopeAndLog(LogLevel logLevel)
    {
        // Arrange
        var eventId = ValueProvider.RandomEventId();
        var message = ValueProvider.LogError;
        var sut = LoggerTestBuilder<LoggerExtensions>
            .ConfigureTests()
            .WithLogLevel(logLevel)
            .WithMessage(message)
            .WithEventId(eventId)
            .Build();

        // Act
        var action = logLevel switch
        {
            LogLevel.Critical =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogCriticalWithContext(eventId, ex, ex.Message)),
            LogLevel.Debug =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogDebugWithContext(eventId, ex, ex.Message)),
            LogLevel.Error =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogErrorWithContext(eventId, ex, ex.Message)),
            LogLevel.Information =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogInformationWithContext(eventId, ex, ex.Message)),
            LogLevel.Trace =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogTraceWithContext(eventId, ex, ex.Message)),
            LogLevel.Warning =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogWarningWithContext(eventId, ex, ex.Message)),
            _
            => throw new ArgumentException(null, nameof(logLevel))
        };

        // Assert
        var exception = Assert.Throws<Exception>(action);
        sut.Assert.VerifyScope();
        sut.Assert.VerifyLog(exception);
    }

    [Theory]
    [InlineData(LogLevel.Critical)]
    [InlineData(LogLevel.Debug)]
    [InlineData(LogLevel.Error)]
    [InlineData(LogLevel.Information)]
    [InlineData(LogLevel.Trace)]
    [InlineData(LogLevel.Warning)]
    public void LogWithContext_GivenEventIdAndMessageAndMessageArgsParamsOnException_BeginScopeAndLog(LogLevel logLevel)
    {
        // Arrange
        var eventId = ValueProvider.RandomEventId();
        var message = ValueProvider.LogErrorWithExpressionBody;
        var messageId = ValueProvider.RandomGuid();
        var sut = LoggerTestBuilder<LoggerExtensions>
            .ConfigureTests()
            .WithLogLevel(logLevel)
            .WithMessage(message)
            .WithEventId(eventId)
            .WithMessageArg(messageId)
            .Build();

        // Act
        var action = logLevel switch
        {
            LogLevel.Critical =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogCriticalWithContext(eventId, ex, ex.Message, messageArgs: messageId)),
            LogLevel.Debug =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogDebugWithContext(eventId, ex, ex.Message, messageArgs: messageId)),
            LogLevel.Error =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogErrorWithContext(eventId, ex, ex.Message, messageArgs: messageId)),
            LogLevel.Information =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogInformationWithContext(eventId, ex, ex.Message, messageArgs: messageId)),
            LogLevel.Trace =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogTraceWithContext(eventId, ex, ex.Message, messageArgs: messageId)),
            LogLevel.Warning =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogWarningWithContext(eventId, ex, ex.Message, messageArgs: messageId)),
            _
            => throw new ArgumentException(null, nameof(logLevel))
        };

        // Assert
        var exception = Assert.Throws<Exception>(action);
        sut.Assert.VerifyScope();
        sut.Assert.VerifyLog(exception);
    }

    [Theory]
    [InlineData(LogLevel.Critical)]
    [InlineData(LogLevel.Debug)]
    [InlineData(LogLevel.Error)]
    [InlineData(LogLevel.Information)]
    [InlineData(LogLevel.Trace)]
    [InlineData(LogLevel.Warning)]
    public void LogWithContext_GivenEventIdAndMessageAndMessageArgsArrayOnException_BeginScopeAndLog(LogLevel logLevel)
    {
        // Arrange
        var eventId = ValueProvider.RandomEventId();
        var message = ValueProvider.LogErrorWithExpressionBody;
        var messageId = ValueProvider.RandomGuid();
        var messageArgArray = new object[] { messageId };
        var sut = LoggerTestBuilder<LoggerExtensions>
            .ConfigureTests()
            .WithLogLevel(logLevel)
            .WithMessage(message)
            .WithEventId(eventId)
            .WithMessageArg(messageId)
            .Build();

        // Act
        var action = logLevel switch
        {
            LogLevel.Critical =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogCriticalWithContext(eventId, ex, ex.Message, messageArgArray)),
            LogLevel.Debug =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogDebugWithContext(eventId, ex, ex.Message, messageArgArray)),
            LogLevel.Error =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogErrorWithContext(eventId, ex, ex.Message, messageArgArray)),
            LogLevel.Information =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogInformationWithContext(eventId, ex, ex.Message, messageArgArray)),
            LogLevel.Trace =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogTraceWithContext(eventId, ex, ex.Message, messageArgArray)),
            LogLevel.Warning =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogWarningWithContext(eventId, ex, ex.Message, messageArgArray)),
            _
            => throw new ArgumentException(null, nameof(logLevel))
        };

        // Assert
        var exception = Assert.Throws<Exception>(action);
        sut.Assert.VerifyScope();
        sut.Assert.VerifyLog(exception);
    }

    [Theory]
    [InlineData(LogLevel.Critical)]
    [InlineData(LogLevel.Debug)]
    [InlineData(LogLevel.Error)]
    [InlineData(LogLevel.Information)]
    [InlineData(LogLevel.Trace)]
    [InlineData(LogLevel.Warning)]
    public void LogWithContext_GivenMessageOnException_BeginScopeAndLog(LogLevel logLevel)
    {
        // Arrange
        var message = ValueProvider.LogError;
        var sut = LoggerTestBuilder<LoggerExtensions>
            .ConfigureTests()
            .WithLogLevel(logLevel)
            .WithMessage(message)
            .Build();

        // Act
        var action = logLevel switch
        {
            LogLevel.Critical =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogCriticalWithContext(ex, ex.Message)),
            LogLevel.Debug =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogDebugWithContext(ex, ex.Message)),
            LogLevel.Error =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogErrorWithContext(ex, ex.Message)),
            LogLevel.Information =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogInformationWithContext(ex, ex.Message)),
            LogLevel.Trace =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogTraceWithContext(ex, ex.Message)),
            LogLevel.Warning =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogWarningWithContext(ex, ex.Message)),
            _
            => throw new ArgumentException(null, nameof(logLevel))
        };

        // Assert
        var exception = Assert.Throws<Exception>(action);
        sut.Assert.VerifyScope();
        sut.Assert.VerifyLog(exception);
    }

    [Theory]
    [InlineData(LogLevel.Critical)]
    [InlineData(LogLevel.Debug)]
    [InlineData(LogLevel.Error)]
    [InlineData(LogLevel.Information)]
    [InlineData(LogLevel.Trace)]
    [InlineData(LogLevel.Warning)]
    public void LogWithContext_GivenMessageAndMessageArgsParamsOnException_BeginScopeAndLog(LogLevel logLevel)
    {
        // Arrange
        var message = ValueProvider.LogErrorWithExpressionBody;
        var messageId = ValueProvider.RandomGuid();
        var sut = LoggerTestBuilder<LoggerExtensions>
            .ConfigureTests()
            .WithLogLevel(logLevel)
            .WithMessage(message)
            .WithMessageArg(messageId)
            .Build();

        // Act
        var action = logLevel switch
        {
            LogLevel.Critical =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogCriticalWithContext(ex, ex.Message, messageArgs: messageId)),
            LogLevel.Debug =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogDebugWithContext(ex, ex.Message, messageArgs: messageId)),
            LogLevel.Error =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogErrorWithContext(ex, ex.Message, messageArgs: messageId)),
            LogLevel.Information =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogInformationWithContext(ex, ex.Message, messageArgs: messageId)),
            LogLevel.Trace =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogTraceWithContext(ex, ex.Message, messageArgs: messageId)),
            LogLevel.Warning =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogWarningWithContext(ex, ex.Message, messageArgs: messageId)),
            _
            => throw new ArgumentException(null, nameof(logLevel))
        };

        // Assert
        var exception = Assert.Throws<Exception>(action);
        sut.Assert.VerifyScope();
        sut.Assert.VerifyLog(exception);
    }

    [Theory]
    [InlineData(LogLevel.Critical)]
    [InlineData(LogLevel.Debug)]
    [InlineData(LogLevel.Error)]
    [InlineData(LogLevel.Information)]
    [InlineData(LogLevel.Trace)]
    [InlineData(LogLevel.Warning)]
    public void LogWithContext_GivenMessageAndMessageArgsArrayOnException_BeginScopeAndLog(LogLevel logLevel)
    {
        // Arrange
        var message = ValueProvider.LogErrorWithExpressionBody;
        var messageId = ValueProvider.RandomGuid();
        var messageArgArray = new object[] { messageId };
        var sut = LoggerTestBuilder<LoggerExtensions>
            .ConfigureTests()
            .WithLogLevel(logLevel)
            .WithMessage(message)
            .WithMessageArg(messageId)
            .Build();

        // Act
        var action = logLevel switch
        {
            LogLevel.Critical =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogCriticalWithContext(ex, ex.Message, messageArgArray)),
            LogLevel.Debug =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogDebugWithContext(ex, ex.Message, messageArgArray)),
            LogLevel.Error =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogErrorWithContext(ex, ex.Message, messageArgArray)),
            LogLevel.Information =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogInformationWithContext(ex, ex.Message, messageArgArray)),
            LogLevel.Trace =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogTraceWithContext(ex, ex.Message, messageArgArray)),
            LogLevel.Warning =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogWarningWithContext(ex, ex.Message, messageArgArray)),
            _
            => throw new ArgumentException(null, nameof(logLevel))
        };

        // Assert
        var exception = Assert.Throws<Exception>(action);
        sut.Assert.VerifyScope();
        sut.Assert.VerifyLog(exception);
    }

    #endregion

    #region Log With Context Data

    [Theory]
    [InlineData(LogLevel.Critical)]
    [InlineData(LogLevel.Debug)]
    [InlineData(LogLevel.Error)]
    [InlineData(LogLevel.Information)]
    [InlineData(LogLevel.Trace)]
    [InlineData(LogLevel.Warning)]
    public void LogWithContext_GivenContextDataAndMessage_BeginScopeAndLog(LogLevel logLevel)
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
                sut.Logger.LogCriticalWithContext(contextData, message);
                break;
            case LogLevel.Debug:
                sut.Logger.LogDebugWithContext(contextData, message);
                break;
            case LogLevel.Error:
                sut.Logger.LogErrorWithContext(contextData, message);
                break;
            case LogLevel.Information:
                sut.Logger.LogInformationWithContext(contextData, message);
                break;
            case LogLevel.Trace:
                sut.Logger.LogTraceWithContext(contextData, message);
                break;
            case LogLevel.Warning:
                sut.Logger.LogWarningWithContext(contextData, message);
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
    public void LogWithContext_GivenContextDataAndMessageAndMessageArgsParams_BeginScopeAndLog(LogLevel logLevel)
    {
        // Arrange
        var contextId = ValueProvider.RandomGuid();
        var contextData = ValueProvider.ContextData(contextId);
        var message = ValueProvider.LogMessageWithExpressionBody;
        var messageId = ValueProvider.RandomGuid();
        var sut = LoggerTestBuilder<LoggerExtensions>
            .ConfigureTests()
            .WithLogLevel(logLevel)
            .WithContextData(contextId)
            .WithMessage(message)
            .WithMessageArg(messageId)
            .Build();

        // Act
        switch (logLevel)
        {
            case LogLevel.Critical:
                sut.Logger.LogCriticalWithContext(contextData, message, messageArgs: messageId);
                break;
            case LogLevel.Debug:
                sut.Logger.LogDebugWithContext(contextData, message, messageArgs: messageId);
                break;
            case LogLevel.Error:
                sut.Logger.LogErrorWithContext(contextData, message, messageArgs: messageId);
                break;
            case LogLevel.Information:
                sut.Logger.LogInformationWithContext(contextData, message, messageArgs: messageId);
                break;
            case LogLevel.Trace:
                sut.Logger.LogTraceWithContext(contextData, message, messageArgs: messageId);
                break;
            case LogLevel.Warning:
                sut.Logger.LogWarningWithContext(contextData, message, messageArgs: messageId);
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
    public void LogWithContext_GivenContextDataAndMessageAndMessageArgsArray_BeginScopeAndLog(LogLevel logLevel)
    {
        // Arrange
        var contextId = ValueProvider.RandomGuid();
        var contextData = ValueProvider.ContextData(contextId);
        var message = ValueProvider.LogMessageWithExpressionBody;
        var messageId = ValueProvider.RandomGuid();
        var sut = LoggerTestBuilder<LoggerExtensions>
            .ConfigureTests()
            .WithLogLevel(logLevel)
            .WithContextData(contextId)
            .WithMessage(message)
            .WithMessageArg(messageId)
            .Build();

        // Act
        switch (logLevel)
        {
            case LogLevel.Critical:
                sut.Logger.LogCriticalWithContext(contextData, message, [messageId]);
                break;
            case LogLevel.Debug:
                sut.Logger.LogDebugWithContext(contextData, message, [messageId]);
                break;
            case LogLevel.Error:
                sut.Logger.LogErrorWithContext(contextData, message, [messageId]);
                break;
            case LogLevel.Information:
                sut.Logger.LogInformationWithContext(contextData, message, [messageId]);
                break;
            case LogLevel.Trace:
                sut.Logger.LogTraceWithContext(contextData, message, [messageId]);
                break;
            case LogLevel.Warning:
                sut.Logger.LogWarningWithContext(contextData, message, [messageId]);
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
    public void LogWithContext_GivenContextDataAndEventIdAndMessage_BeginScopeAndLog(LogLevel logLevel)
    {
        // Arrange
        var contextId = ValueProvider.RandomGuid();
        var contextData = ValueProvider.ContextData(contextId);
        var eventId = ValueProvider.RandomEventId();
        var message = ValueProvider.LogMessage;
        var sut = LoggerTestBuilder<LoggerExtensions>
            .ConfigureTests()
            .WithLogLevel(logLevel)
            .WithContextData(contextId)
            .WithEventId(eventId)
            .WithMessage(message)
            .Build();

        // Act
        switch (logLevel)
        {
            case LogLevel.Critical:
                sut.Logger.LogCriticalWithContext(contextData, eventId, message);
                break;
            case LogLevel.Debug:
                sut.Logger.LogDebugWithContext(contextData, eventId, message);
                break;
            case LogLevel.Error:
                sut.Logger.LogErrorWithContext(contextData, eventId, message);
                break;
            case LogLevel.Information:
                sut.Logger.LogInformationWithContext(contextData, eventId, message);
                break;
            case LogLevel.Trace:
                sut.Logger.LogTraceWithContext(contextData, eventId, message);
                break;
            case LogLevel.Warning:
                sut.Logger.LogWarningWithContext(contextData, eventId, message);
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
    public void LogWithContext_GivenContextDataAndEventIdAndMessageAndMessageArgsParams_BeginScopeAndLog(LogLevel logLevel)
    {
        // Arrange
        var contextId = ValueProvider.RandomGuid();
        var contextData = ValueProvider.ContextData(contextId);
        var eventId = ValueProvider.RandomEventId();
        var message = ValueProvider.LogMessageWithExpressionBody;
        var messageId = ValueProvider.RandomGuid();
        var sut = LoggerTestBuilder<LoggerExtensions>
            .ConfigureTests()
            .WithLogLevel(logLevel)
            .WithContextData(contextId)
            .WithEventId(eventId)
            .WithMessage(message)
            .WithMessageArg(messageId)
            .Build();

        // Act
        switch (logLevel)
        {
            case LogLevel.Critical:
                sut.Logger.LogCriticalWithContext(contextData, eventId, message, messageArgs: messageId);
                break;
            case LogLevel.Debug:
                sut.Logger.LogDebugWithContext(contextData, eventId, message, messageArgs: messageId);
                break;
            case LogLevel.Error:
                sut.Logger.LogErrorWithContext(contextData, eventId, message, messageArgs: messageId);
                break;
            case LogLevel.Information:
                sut.Logger.LogInformationWithContext(contextData, eventId, message, messageArgs: messageId);
                break;
            case LogLevel.Trace:
                sut.Logger.LogTraceWithContext(contextData, eventId, message, messageArgs: messageId);
                break;
            case LogLevel.Warning:
                sut.Logger.LogWarningWithContext(contextData, eventId, message, messageArgs: messageId);
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
    public void LogWithContext_GivenContextDataAndEventIdAndMessageAndMessageArgsArray_BeginScopeAndLog(LogLevel logLevel)
    {
        // Arrange
        var contextId = ValueProvider.RandomGuid();
        var contextData = ValueProvider.ContextData(contextId);
        var eventId = ValueProvider.RandomEventId();
        var message = ValueProvider.LogMessageWithExpressionBody;
        var messageId = ValueProvider.RandomGuid();
        var messageArgArray = new object[] { messageId };
        var sut = LoggerTestBuilder<LoggerExtensions>
            .ConfigureTests()
            .WithLogLevel(logLevel)
            .WithContextData(contextId)
            .WithEventId(eventId)
            .WithMessage(message)
            .WithMessageArg(messageId)
            .Build();

        // Act
        switch (logLevel)
        {
            case LogLevel.Critical:
                sut.Logger.LogCriticalWithContext(contextData, eventId, message, messageArgArray);
                break;
            case LogLevel.Debug:
                sut.Logger.LogDebugWithContext(contextData, eventId, message, messageArgArray);
                break;
            case LogLevel.Error:
                sut.Logger.LogErrorWithContext(contextData, eventId, message, messageArgArray);
                break;
            case LogLevel.Information:
                sut.Logger.LogInformationWithContext(contextData, eventId, message, messageArgArray);
                break;
            case LogLevel.Trace:
                sut.Logger.LogTraceWithContext(contextData, eventId, message, messageArgArray);
                break;
            case LogLevel.Warning:
                sut.Logger.LogWarningWithContext(contextData, eventId, message, messageArgArray);
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
    public void LogWithContext_GivenContextDataAndEventIdAndMessageOnException_BeginScopeAndLog(LogLevel logLevel)
    {
        // Arrange
        var contextId = ValueProvider.RandomGuid();
        var contextData = ValueProvider.ContextData(contextId);
        var eventId = ValueProvider.RandomEventId();
        var message = ValueProvider.LogError;
        var sut = LoggerTestBuilder<LoggerExtensions>
            .ConfigureTests()
            .WithLogLevel(logLevel)
            .WithContextData(contextId)
            .WithMessage(message)
            .WithEventId(eventId)
            .Build();

        // Act
        var action = logLevel switch
        {
            LogLevel.Critical =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogCriticalWithContext(contextData, eventId, ex, ex.Message)),
            LogLevel.Debug =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogDebugWithContext(contextData, eventId, ex, ex.Message)),
            LogLevel.Error =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogErrorWithContext(contextData, eventId, ex, ex.Message)),
            LogLevel.Information =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogInformationWithContext(contextData, eventId, ex, ex.Message)),
            LogLevel.Trace =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogTraceWithContext(contextData, eventId, ex, ex.Message)),
            LogLevel.Warning =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogWarningWithContext(contextData, eventId, ex, ex.Message)),
            _
            => throw new ArgumentException(null, nameof(logLevel))
        };

        // Assert
        var exception = Assert.Throws<Exception>(action);
        sut.Assert.VerifyScope();
        sut.Assert.VerifyLog(exception);
    }

    [Theory]
    [InlineData(LogLevel.Critical)]
    [InlineData(LogLevel.Debug)]
    [InlineData(LogLevel.Error)]
    [InlineData(LogLevel.Information)]
    [InlineData(LogLevel.Trace)]
    [InlineData(LogLevel.Warning)]
    public void LogWithContext_GivenContextDataAndEventIdAndMessageAndMessageArgsParamsOnException_BeginScopeAndLog(LogLevel logLevel)
    {
        // Arrange
        var contextId = ValueProvider.RandomGuid();
        var contextData = ValueProvider.ContextData(contextId);
        var eventId = ValueProvider.RandomEventId();
        var message = ValueProvider.LogErrorWithExpressionBody;
        var messageId = ValueProvider.RandomGuid();
        var sut = LoggerTestBuilder<LoggerExtensions>
            .ConfigureTests()
            .WithLogLevel(logLevel)
            .WithContextData(contextId)
            .WithMessage(message)
            .WithEventId(eventId)
            .WithMessageArg(messageId)
            .Build();

        // Act
        var action = logLevel switch
        {
            LogLevel.Critical =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogCriticalWithContext(contextData, eventId, ex, ex.Message, messageArgs: messageId)),
            LogLevel.Debug =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogDebugWithContext(contextData, eventId, ex, ex.Message, messageArgs: messageId)),
            LogLevel.Error =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogErrorWithContext(contextData, eventId, ex, ex.Message, messageArgs: messageId)),
            LogLevel.Information =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogInformationWithContext(contextData, eventId, ex, ex.Message, messageArgs: messageId)),
            LogLevel.Trace =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogTraceWithContext(contextData, eventId, ex, ex.Message, messageArgs: messageId)),
            LogLevel.Warning =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogWarningWithContext(contextData, eventId, ex, ex.Message, messageArgs: messageId)),
            _
            => throw new ArgumentException(null, nameof(logLevel))
        };

        // Assert
        var exception = Assert.Throws<Exception>(action);
        sut.Assert.VerifyScope();
        sut.Assert.VerifyLog(exception);
    }

    [Theory]
    [InlineData(LogLevel.Critical)]
    [InlineData(LogLevel.Debug)]
    [InlineData(LogLevel.Error)]
    [InlineData(LogLevel.Information)]
    [InlineData(LogLevel.Trace)]
    [InlineData(LogLevel.Warning)]
    public void LogWithContext_GivenContextDataAndEventIdAndMessageAndMessageArgsArrayOnException_BeginScopeAndLog(LogLevel logLevel)
    {
        // Arrange
        var contextId = ValueProvider.RandomGuid();
        var contextData = ValueProvider.ContextData(contextId);
        var eventId = ValueProvider.RandomEventId();
        var message = ValueProvider.LogErrorWithExpressionBody;
        var messageId = ValueProvider.RandomGuid();
        var messageArgArray = new object[] { messageId };
        var sut = LoggerTestBuilder<LoggerExtensions>
            .ConfigureTests()
            .WithLogLevel(logLevel)
            .WithContextData(contextId)
            .WithMessage(message)
            .WithEventId(eventId)
            .WithMessageArg(messageId)
            .Build();

        // Act
        var action = logLevel switch
        {
            LogLevel.Critical =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogCriticalWithContext(contextData, eventId, ex, ex.Message, messageArgArray)),
            LogLevel.Debug =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogDebugWithContext(contextData, eventId, ex, ex.Message, messageArgArray)),
            LogLevel.Error =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogErrorWithContext(contextData, eventId, ex, ex.Message, messageArgArray)),
            LogLevel.Information =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogInformationWithContext(contextData, eventId, ex, ex.Message, messageArgArray)),
            LogLevel.Trace =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogTraceWithContext(contextData, eventId, ex, ex.Message, messageArgArray)),
            LogLevel.Warning =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogWarningWithContext(contextData, eventId, ex, ex.Message, messageArgArray)),
            _
            => throw new ArgumentException(null, nameof(logLevel))
        };

        // Assert
        var exception = Assert.Throws<Exception>(action);
        sut.Assert.VerifyScope();
        sut.Assert.VerifyLog(exception);
    }

    [Theory]
    [InlineData(LogLevel.Critical)]
    [InlineData(LogLevel.Debug)]
    [InlineData(LogLevel.Error)]
    [InlineData(LogLevel.Information)]
    [InlineData(LogLevel.Trace)]
    [InlineData(LogLevel.Warning)]
    public void LogWithContext_GivenContextDataAndMessageOnException_BeginScopeAndLog(LogLevel logLevel)
    {
        // Arrange
        var contextId = ValueProvider.RandomGuid();
        var contextData = ValueProvider.ContextData(contextId);
        var message = ValueProvider.LogError;
        var sut = LoggerTestBuilder<LoggerExtensions>
            .ConfigureTests()
            .WithLogLevel(logLevel)
            .WithContextData(contextId)
            .WithMessage(message)
            .Build();

        // Act
        var action = logLevel switch
        {
            LogLevel.Critical =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogCriticalWithContext(contextData, ex, ex.Message)),
            LogLevel.Debug =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogDebugWithContext(contextData, ex, ex.Message)),
            LogLevel.Error =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogErrorWithContext(contextData, ex, ex.Message)),
            LogLevel.Information =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogInformationWithContext(contextData, ex, ex.Message)),
            LogLevel.Trace =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogTraceWithContext(contextData, ex, ex.Message)),
            LogLevel.Warning =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogWarningWithContext(contextData, ex, ex.Message)),
            _
            => throw new ArgumentException(null, nameof(logLevel))
        };

        // Assert
        var exception = Assert.Throws<Exception>(action);
        sut.Assert.VerifyScope();
        sut.Assert.VerifyLog(exception);
    }

    [Theory]
    [InlineData(LogLevel.Critical)]
    [InlineData(LogLevel.Debug)]
    [InlineData(LogLevel.Error)]
    [InlineData(LogLevel.Information)]
    [InlineData(LogLevel.Trace)]
    [InlineData(LogLevel.Warning)]
    public void LogWithContext_GivenContextDataAndMessageAndMessageArgsParamsOnException_BeginScopeAndLog(LogLevel logLevel)
    {
        // Arrange
        var contextId = ValueProvider.RandomGuid();
        var contextData = ValueProvider.ContextData(contextId);
        var message = ValueProvider.LogErrorWithExpressionBody;
        var messageId = ValueProvider.RandomGuid();
        var sut = LoggerTestBuilder<LoggerExtensions>
            .ConfigureTests()
            .WithLogLevel(logLevel)
            .WithContextData(contextId)
            .WithMessage(message)
            .WithMessageArg(messageId)
            .Build();

        // Act
        var action = logLevel switch
        {
            LogLevel.Critical =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogCriticalWithContext(contextData, ex, ex.Message, messageArgs: messageId)),
            LogLevel.Debug =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogDebugWithContext(contextData, ex, ex.Message, messageArgs: messageId)),
            LogLevel.Error =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogErrorWithContext(contextData, ex, ex.Message, messageArgs: messageId)),
            LogLevel.Information =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogInformationWithContext(contextData, ex, ex.Message, messageArgs: messageId)),
            LogLevel.Trace =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogTraceWithContext(contextData, ex, ex.Message, messageArgs: messageId)),
            LogLevel.Warning =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogWarningWithContext(contextData, ex, ex.Message, messageArgs: messageId)),
            _
            => throw new ArgumentException(null, nameof(logLevel))
        };

        // Assert
        var exception = Assert.Throws<Exception>(action);
        sut.Assert.VerifyScope();
        sut.Assert.VerifyLog(exception);
    }

    [Theory]
    [InlineData(LogLevel.Critical)]
    [InlineData(LogLevel.Debug)]
    [InlineData(LogLevel.Error)]
    [InlineData(LogLevel.Information)]
    [InlineData(LogLevel.Trace)]
    [InlineData(LogLevel.Warning)]
    public void LogWithContext_GivenContextDataAndMessageAndMessageArgsArrayOnException_BeginScopeAndLog(LogLevel logLevel)
    {
        // Arrange
        var contextId = ValueProvider.RandomGuid();
        var contextData = ValueProvider.ContextData(contextId);
        var message = ValueProvider.LogErrorWithExpressionBody;
        var messageId = ValueProvider.RandomGuid();
        var messageArgArray = new object[] { messageId };
        var sut = LoggerTestBuilder<LoggerExtensions>
            .ConfigureTests()
            .WithLogLevel(logLevel)
            .WithContextData(contextId)
            .WithMessage(message)
            .WithMessageArg(messageId)
            .Build();

        // Act
        var action = logLevel switch
        {
            LogLevel.Critical =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogCriticalWithContext(contextData, ex, ex.Message, messageArgArray)),
            LogLevel.Debug =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogDebugWithContext(contextData, ex, ex.Message, messageArgArray)),
            LogLevel.Error =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogErrorWithContext(contextData, ex, ex.Message, messageArgArray)),
            LogLevel.Information =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogInformationWithContext(contextData, ex, ex.Message, messageArgArray)),
            LogLevel.Trace =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogTraceWithContext(contextData, ex, ex.Message, messageArgArray)),
            LogLevel.Warning =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogWarningWithContext(contextData, ex, ex.Message, messageArgArray)),
            _
            => throw new ArgumentException(null, nameof(logLevel))
        };

        // Assert
        var exception = Assert.Throws<Exception>(action);
        sut.Assert.VerifyScope();
        sut.Assert.VerifyLog(exception);
    }

    #endregion

    #region Log With Context Attributes

    [Theory]
    [InlineData(LogLevel.Critical)]
    [InlineData(LogLevel.Debug)]
    [InlineData(LogLevel.Error)]
    [InlineData(LogLevel.Information)]
    [InlineData(LogLevel.Trace)]
    [InlineData(LogLevel.Warning)]
    public void LogWithContext_GivenContextAttributesAndMessage_BeginScopeAndLog(LogLevel logLevel)
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
                sut.Logger.LogCriticalWithContext(contextAttributes, message);
                break;
            case LogLevel.Debug:
                sut.Logger.LogDebugWithContext(contextAttributes, message);
                break;
            case LogLevel.Error:
                sut.Logger.LogErrorWithContext(contextAttributes, message);
                break;
            case LogLevel.Information:
                sut.Logger.LogInformationWithContext(contextAttributes, message);
                break;
            case LogLevel.Trace:
                sut.Logger.LogTraceWithContext(contextAttributes, message);
                break;
            case LogLevel.Warning:
                sut.Logger.LogWarningWithContext(contextAttributes, message);
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
    public void LogWithContext_GivenContextAttributesAndMessageAndMessageArgsParams_BeginScopeAndLog(LogLevel logLevel)
    {
        // Arrange
        var contextAttributes = ValueProvider.ContextAttributes();
        var message = ValueProvider.LogMessageWithExpressionBody;
        var messageId = ValueProvider.RandomGuid();
        var sut = LoggerTestBuilder<LoggerExtensions>
            .ConfigureTests()
            .WithLogLevel(logLevel)
            .WithContextData(contextAttributes.ContextId)
            .WithMessage(message)
            .WithMessageArg(messageId)
            .Build();

        // Act
        switch (logLevel)
        {
            case LogLevel.Critical:
                sut.Logger.LogCriticalWithContext(contextAttributes, message, messageArgs: messageId);
                break;
            case LogLevel.Debug:
                sut.Logger.LogDebugWithContext(contextAttributes, message, messageArgs: messageId);
                break;
            case LogLevel.Error:
                sut.Logger.LogErrorWithContext(contextAttributes, message, messageArgs: messageId);
                break;
            case LogLevel.Information:
                sut.Logger.LogInformationWithContext(contextAttributes, message, messageArgs: messageId);
                break;
            case LogLevel.Trace:
                sut.Logger.LogTraceWithContext(contextAttributes, message, messageArgs: messageId);
                break;
            case LogLevel.Warning:
                sut.Logger.LogWarningWithContext(contextAttributes, message, messageArgs: messageId);
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
    public void LogWithContext_GivenContextAttributesAndMessageAndMessageArgsArray_BeginScopeAndLog(LogLevel logLevel)
    {
        // Arrange
        var contextAttributes = ValueProvider.ContextAttributes();
        var message = ValueProvider.LogMessageWithExpressionBody;
        var messageId = ValueProvider.RandomGuid();
        var sut = LoggerTestBuilder<LoggerExtensions>
            .ConfigureTests()
            .WithLogLevel(logLevel)
            .WithContextData(contextAttributes.ContextId)
            .WithMessage(message)
            .WithMessageArg(messageId)
            .Build();

        // Act
        switch (logLevel)
        {
            case LogLevel.Critical:
                sut.Logger.LogCriticalWithContext(contextAttributes, message, [messageId]);
                break;
            case LogLevel.Debug:
                sut.Logger.LogDebugWithContext(contextAttributes, message, [messageId]);
                break;
            case LogLevel.Error:
                sut.Logger.LogErrorWithContext(contextAttributes, message, [messageId]);
                break;
            case LogLevel.Information:
                sut.Logger.LogInformationWithContext(contextAttributes, message, [messageId]);
                break;
            case LogLevel.Trace:
                sut.Logger.LogTraceWithContext(contextAttributes, message, [messageId]);
                break;
            case LogLevel.Warning:
                sut.Logger.LogWarningWithContext(contextAttributes, message, [messageId]);
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
    public void LogWithContext_GivenContextAttributesAndEventIdAndMessage_BeginScopeAndLog(LogLevel logLevel)
    {
        // Arrange
        var contextAttributes = ValueProvider.ContextAttributes();
        var eventId = ValueProvider.RandomEventId();
        var message = ValueProvider.LogMessage;
        var sut = LoggerTestBuilder<LoggerExtensions>
            .ConfigureTests()
            .WithLogLevel(logLevel)
            .WithContextData(contextAttributes.ContextId)
            .WithEventId(eventId)
            .WithMessage(message)
            .Build();

        // Act
        switch (logLevel)
        {
            case LogLevel.Critical:
                sut.Logger.LogCriticalWithContext(contextAttributes, eventId, message);
                break;
            case LogLevel.Debug:
                sut.Logger.LogDebugWithContext(contextAttributes, eventId, message);
                break;
            case LogLevel.Error:
                sut.Logger.LogErrorWithContext(contextAttributes, eventId, message);
                break;
            case LogLevel.Information:
                sut.Logger.LogInformationWithContext(contextAttributes, eventId, message);
                break;
            case LogLevel.Trace:
                sut.Logger.LogTraceWithContext(contextAttributes, eventId, message);
                break;
            case LogLevel.Warning:
                sut.Logger.LogWarningWithContext(contextAttributes, eventId, message);
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
    public void LogWithContext_GivenContextAttributesAndEventIdAndMessageAndMessageArgsParams_BeginScopeAndLog(LogLevel logLevel)
    {
        // Arrange
        var contextAttributes = ValueProvider.ContextAttributes();
        var eventId = ValueProvider.RandomEventId();
        var message = ValueProvider.LogMessageWithExpressionBody;
        var messageId = ValueProvider.RandomGuid();
        var sut = LoggerTestBuilder<LoggerExtensions>
            .ConfigureTests()
            .WithLogLevel(logLevel)
            .WithContextData(contextAttributes.ContextId)
            .WithEventId(eventId)
            .WithMessage(message)
            .WithMessageArg(messageId)
            .Build();

        // Act
        switch (logLevel)
        {
            case LogLevel.Critical:
                sut.Logger.LogCriticalWithContext(contextAttributes, eventId, message, messageArgs: messageId);
                break;
            case LogLevel.Debug:
                sut.Logger.LogDebugWithContext(contextAttributes, eventId, message, messageArgs: messageId);
                break;
            case LogLevel.Error:
                sut.Logger.LogErrorWithContext(contextAttributes, eventId, message, messageArgs: messageId);
                break;
            case LogLevel.Information:
                sut.Logger.LogInformationWithContext(contextAttributes, eventId, message, messageArgs: messageId);
                break;
            case LogLevel.Trace:
                sut.Logger.LogTraceWithContext(contextAttributes, eventId, message, messageArgs: messageId);
                break;
            case LogLevel.Warning:
                sut.Logger.LogWarningWithContext(contextAttributes, eventId, message, messageArgs: messageId);
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
    public void LogWithContext_GivenContextAttributesAndEventIdAndMessageAndMessageArgsArray_BeginScopeAndLog(LogLevel logLevel)
    {
        // Arrange
        var contextAttributes = ValueProvider.ContextAttributes();
        var eventId = ValueProvider.RandomEventId();
        var message = ValueProvider.LogMessageWithExpressionBody;
        var messageId = ValueProvider.RandomGuid();
        var messageArgArray = new object[] { messageId };
        var sut = LoggerTestBuilder<LoggerExtensions>
            .ConfigureTests()
            .WithLogLevel(logLevel)
            .WithContextData(contextAttributes.ContextId)
            .WithEventId(eventId)
            .WithMessage(message)
            .WithMessageArg(messageId)
            .Build();

        // Act
        switch (logLevel)
        {
            case LogLevel.Critical:
                sut.Logger.LogCriticalWithContext(contextAttributes, eventId, message, messageArgArray);
                break;
            case LogLevel.Debug:
                sut.Logger.LogDebugWithContext(contextAttributes, eventId, message, messageArgArray);
                break;
            case LogLevel.Error:
                sut.Logger.LogErrorWithContext(contextAttributes, eventId, message, messageArgArray);
                break;
            case LogLevel.Information:
                sut.Logger.LogInformationWithContext(contextAttributes, eventId, message, messageArgArray);
                break;
            case LogLevel.Trace:
                sut.Logger.LogTraceWithContext(contextAttributes, eventId, message, messageArgArray);
                break;
            case LogLevel.Warning:
                sut.Logger.LogWarningWithContext(contextAttributes, eventId, message, messageArgArray);
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
    public void LogWithContext_GivenContextAttributesAndEventIdAndMessageOnException_BeginScopeAndLog(LogLevel logLevel)
    {
        // Arrange
        var contextAttributes = ValueProvider.ContextAttributes();
        var eventId = ValueProvider.RandomEventId();
        var message = ValueProvider.LogError;
        var sut = LoggerTestBuilder<LoggerExtensions>
            .ConfigureTests()
            .WithLogLevel(logLevel)
            .WithContextData(contextAttributes.ContextId)
            .WithMessage(message)
            .WithEventId(eventId)
            .Build();

        // Act
        var action = logLevel switch
        {
            LogLevel.Critical =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogCriticalWithContext(contextAttributes, eventId, ex, ex.Message)),
            LogLevel.Debug =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogDebugWithContext(contextAttributes, eventId, ex, ex.Message)),
            LogLevel.Error =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogErrorWithContext(contextAttributes, eventId, ex, ex.Message)),
            LogLevel.Information =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogInformationWithContext(contextAttributes, eventId, ex, ex.Message)),
            LogLevel.Trace =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogTraceWithContext(contextAttributes, eventId, ex, ex.Message)),
            LogLevel.Warning =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogWarningWithContext(contextAttributes, eventId, ex, ex.Message)),
            _
            => throw new ArgumentException(null, nameof(logLevel))
        };

        // Assert
        var exception = Assert.Throws<Exception>(action);
        sut.Assert.VerifyScope();
        sut.Assert.VerifyLog(exception);
    }

    [Theory]
    [InlineData(LogLevel.Critical)]
    [InlineData(LogLevel.Debug)]
    [InlineData(LogLevel.Error)]
    [InlineData(LogLevel.Information)]
    [InlineData(LogLevel.Trace)]
    [InlineData(LogLevel.Warning)]
    public void LogWithContext_GivenContextAttributesAndEventIdAndMessageAndMessageArgsParamsOnException_BeginScopeAndLog(LogLevel logLevel)
    {
        // Arrange
        var contextAttributes = ValueProvider.ContextAttributes();
        var eventId = ValueProvider.RandomEventId();
        var message = ValueProvider.LogErrorWithExpressionBody;
        var messageId = ValueProvider.RandomGuid();
        var sut = LoggerTestBuilder<LoggerExtensions>
            .ConfigureTests()
            .WithLogLevel(logLevel)
            .WithContextData(contextAttributes.ContextId)
            .WithMessage(message)
            .WithEventId(eventId)
            .WithMessageArg(messageId)
            .Build();

        // Act
        var action = logLevel switch
        {
            LogLevel.Critical =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogCriticalWithContext(contextAttributes, eventId, ex, ex.Message, messageArgs: messageId)),
            LogLevel.Debug =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogDebugWithContext(contextAttributes, eventId, ex, ex.Message, messageArgs: messageId)),
            LogLevel.Error =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogErrorWithContext(contextAttributes, eventId, ex, ex.Message, messageArgs: messageId)),
            LogLevel.Information =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogInformationWithContext(contextAttributes, eventId, ex, ex.Message, messageArgs: messageId)),
            LogLevel.Trace =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogTraceWithContext(contextAttributes, eventId, ex, ex.Message, messageArgs: messageId)),
            LogLevel.Warning =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogWarningWithContext(contextAttributes, eventId, ex, ex.Message, messageArgs: messageId)),
            _
            => throw new ArgumentException(null, nameof(logLevel))
        };

        // Assert
        var exception = Assert.Throws<Exception>(action);
        sut.Assert.VerifyScope();
        sut.Assert.VerifyLog(exception);
    }

    [Theory]
    [InlineData(LogLevel.Critical)]
    [InlineData(LogLevel.Debug)]
    [InlineData(LogLevel.Error)]
    [InlineData(LogLevel.Information)]
    [InlineData(LogLevel.Trace)]
    [InlineData(LogLevel.Warning)]
    public void LogWithContext_GivenContextAttributesAndEventIdAndMessageAndMessageArgsArrayOnException_BeginScopeAndLog(LogLevel logLevel)
    {
        // Arrange
        var contextAttributes = ValueProvider.ContextAttributes();
        var eventId = ValueProvider.RandomEventId();
        var message = ValueProvider.LogErrorWithExpressionBody;
        var messageId = ValueProvider.RandomGuid();
        var messageArgArray = new object[] { messageId };
        var sut = LoggerTestBuilder<LoggerExtensions>
            .ConfigureTests()
            .WithLogLevel(logLevel)
            .WithContextData(contextAttributes.ContextId)
            .WithMessage(message)
            .WithEventId(eventId)
            .WithMessageArg(messageId)
            .Build();

        // Act
        var action = logLevel switch
        {
            LogLevel.Critical =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogCriticalWithContext(contextAttributes, eventId, ex, ex.Message, messageArgArray)),
            LogLevel.Debug =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogDebugWithContext(contextAttributes, eventId, ex, ex.Message, messageArgArray)),
            LogLevel.Error =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogErrorWithContext(contextAttributes, eventId, ex, ex.Message, messageArgArray)),
            LogLevel.Information =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogInformationWithContext(contextAttributes, eventId, ex, ex.Message, messageArgArray)),
            LogLevel.Trace =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogTraceWithContext(contextAttributes, eventId, ex, ex.Message, messageArgArray)),
            LogLevel.Warning =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogWarningWithContext(contextAttributes, eventId, ex, ex.Message, messageArgArray)),
            _
            => throw new ArgumentException(null, nameof(logLevel))
        };

        // Assert
        var exception = Assert.Throws<Exception>(action);
        sut.Assert.VerifyScope();
        sut.Assert.VerifyLog(exception);
    }

    [Theory]
    [InlineData(LogLevel.Critical)]
    [InlineData(LogLevel.Debug)]
    [InlineData(LogLevel.Error)]
    [InlineData(LogLevel.Information)]
    [InlineData(LogLevel.Trace)]
    [InlineData(LogLevel.Warning)]
    public void LogWithContext_GivenContextAttributesAndMessageOnException_BeginScopeAndLog(LogLevel logLevel)
    {
        // Arrange
        var contextAttributes = ValueProvider.ContextAttributes();
        var message = ValueProvider.LogError;
        var sut = LoggerTestBuilder<LoggerExtensions>
            .ConfigureTests()
            .WithLogLevel(logLevel)
            .WithContextData(contextAttributes.ContextId)
            .WithMessage(message)
            .Build();

        // Act
        var action = logLevel switch
        {
            LogLevel.Critical =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogCriticalWithContext(contextAttributes, ex, ex.Message)),
            LogLevel.Debug =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogDebugWithContext(contextAttributes, ex, ex.Message)),
            LogLevel.Error =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogErrorWithContext(contextAttributes, ex, ex.Message)),
            LogLevel.Information =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogInformationWithContext(contextAttributes, ex, ex.Message)),
            LogLevel.Trace =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogTraceWithContext(contextAttributes, ex, ex.Message)),
            LogLevel.Warning =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogWarningWithContext(contextAttributes, ex, ex.Message)),
            _
            => throw new ArgumentException(null, nameof(logLevel))
        };

        // Assert
        var exception = Assert.Throws<Exception>(action);
        sut.Assert.VerifyScope();
        sut.Assert.VerifyLog(exception);
    }

    [Theory]
    [InlineData(LogLevel.Critical)]
    [InlineData(LogLevel.Debug)]
    [InlineData(LogLevel.Error)]
    [InlineData(LogLevel.Information)]
    [InlineData(LogLevel.Trace)]
    [InlineData(LogLevel.Warning)]
    public void LogWithContext_GivenContextAttributesAndMessageAndMessageArgsParamsOnException_BeginScopeAndLog(LogLevel logLevel)
    {
        // Arrange
        var contextAttributes = ValueProvider.ContextAttributes();
        var message = ValueProvider.LogErrorWithExpressionBody;
        var messageId = ValueProvider.RandomGuid();
        var sut = LoggerTestBuilder<LoggerExtensions>
            .ConfigureTests()
            .WithLogLevel(logLevel)
            .WithContextData(contextAttributes.ContextId)
            .WithMessage(message)
            .WithMessageArg(messageId)
            .Build();

        // Act
        var action = logLevel switch
        {
            LogLevel.Critical =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogCriticalWithContext(contextAttributes, ex, ex.Message, messageArgs: messageId)),
            LogLevel.Debug =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogDebugWithContext(contextAttributes, ex, ex.Message, messageArgs: messageId)),
            LogLevel.Error =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogErrorWithContext(contextAttributes, ex, ex.Message, messageArgs: messageId)),
            LogLevel.Information =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogInformationWithContext(contextAttributes, ex, ex.Message, messageArgs: messageId)),
            LogLevel.Trace =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogTraceWithContext(contextAttributes, ex, ex.Message, messageArgs: messageId)),
            LogLevel.Warning =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogWarningWithContext(contextAttributes, ex, ex.Message, messageArgs: messageId)),
            _
            => throw new ArgumentException(null, nameof(logLevel))
        };

        // Assert
        var exception = Assert.Throws<Exception>(action);
        sut.Assert.VerifyScope();
        sut.Assert.VerifyLog(exception);
    }

    [Theory]
    [InlineData(LogLevel.Critical)]
    [InlineData(LogLevel.Debug)]
    [InlineData(LogLevel.Error)]
    [InlineData(LogLevel.Information)]
    [InlineData(LogLevel.Trace)]
    [InlineData(LogLevel.Warning)]
    public void LogWithContext_GivenContextAttributesAndMessageAndMessageArgsArrayOnException_BeginScopeAndLog(LogLevel logLevel)
    {
        // Arrange
        var contextAttributes = ValueProvider.ContextAttributes();
        var message = ValueProvider.LogErrorWithExpressionBody;
        var messageId = ValueProvider.RandomGuid();
        var messageArgArray = new object[] { messageId };
        var sut = LoggerTestBuilder<LoggerExtensions>
            .ConfigureTests()
            .WithLogLevel(logLevel)
            .WithContextData(contextAttributes.ContextId)
            .WithMessage(message)
            .WithMessageArg(messageId)
            .Build();

        // Act
        var action = logLevel switch
        {
            LogLevel.Critical =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogCriticalWithContext(contextAttributes, ex, ex.Message, messageArgArray)),
            LogLevel.Debug =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogDebugWithContext(contextAttributes, ex, ex.Message, messageArgArray)),
            LogLevel.Error =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogErrorWithContext(contextAttributes, ex, ex.Message, messageArgArray)),
            LogLevel.Information =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogInformationWithContext(contextAttributes, ex, ex.Message, messageArgArray)),
            LogLevel.Trace =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogTraceWithContext(contextAttributes, ex, ex.Message, messageArgArray)),
            LogLevel.Warning =>
                ActionProvider.ThrowExceptionFor(message, (ex) => sut
                    .Logger
                    .LogWarningWithContext(contextAttributes, ex, ex.Message, messageArgArray)),
            _
            => throw new ArgumentException(null, nameof(logLevel))
        };

        // Assert
        var exception = Assert.Throws<Exception>(action);
        sut.Assert.VerifyScope();
        sut.Assert.VerifyLog(exception);
    }

    #endregion

}
