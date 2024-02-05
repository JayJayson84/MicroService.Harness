using System.Runtime.CompilerServices;
using MicroService.Logging.Tests.DSL.Subjects;
using Microsoft.Extensions.Logging;
using Moq;

namespace MicroService.Logging.Tests.DSL.Builders;

internal class LoggerTestBuilder<T> where T : class
{
    private LoggerSut<T> _sut;
    private readonly Mock<ILogger<T>> _mockLogger;

    public LoggerTestBuilder()
    {
        _sut = new LoggerSut<T>();
        _mockLogger = new Mock<ILogger<T>>();
    }

    public LoggerTestBuilder<T> WithLogLevel(LogLevel level)
    {
        _sut.LogLevel = level;

        return this;
    }

#pragma warning disable IDE0060

    public LoggerTestBuilder<T> WithContextData(
        object? value,
        [CallerArgumentExpression(nameof(value))] string valueName = "",
        [CallerMemberName] string MemberName = "",
        [CallerFilePath] string FilePath = "",
        [CallerLineNumber] int LineNumber = 0)
    {
        _sut.ContextData = new Dictionary<string, object?> {
            { nameof(MemberName), MemberName },
            { nameof(FilePath), FilePath },
            { nameof(LineNumber), "^[1-9][0-9]*$" },
            { valueName, value }
        };

        return this;
    }

#pragma warning restore IDE0060

    public LoggerTestBuilder<T> AddContextData(object? value, [CallerArgumentExpression(nameof(value))] string valueName = "")
    {
        _sut.ContextData.Add(valueName, value);

        return this;
    }

    public LoggerTestBuilder<T> WithEventId(EventId eventId)
    {
        _sut.EventId = eventId;

        return this;
    }

    public LoggerTestBuilder<T> WithMessage(string message)
    {
        _sut.Message = message;

        return this;
    }

    public LoggerTestBuilder<T> WithMessageArg(object? arg, [CallerArgumentExpression(nameof(arg))] string argName = "")
    {
        _sut.MessageArgs = new Dictionary<string, object?>()
        {
            { argName, arg }
        };

        return this;
    }

    public LoggerTestBuilder<T> AddMessageArg(object? arg, [CallerArgumentExpression(nameof(arg))] string argName = "")
    {
        _sut.MessageArgs?.Add(argName, arg);

        return this;
    }

    public LoggerSut<T> Build()
    {
        _mockLogger
            .Setup(e => e.BeginScope(It.IsAny<Dictionary<string, object>>()))
            .Returns(Mock.Of<IDisposable>());

        var sut = _sut;
        sut.MockLogger = _mockLogger;
        sut.Logger = _mockLogger.Object;
        _sut = null!;
        return sut;
    }

    public static LoggerTestBuilder<T> ConfigureTests() => new();
}
