using System.Linq.Expressions;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;
using Moq;

namespace MicroService.Logging.Tests.DSL.Subjects;

internal class LoggerTestAsserts<T>(LoggerSut<T> sut)
{
    readonly LoggerSut<T> _sut = sut;

    public LoggerTestAsserts<T> VerifyScope()
    {
        _sut.MockLogger.Verify(e => e.BeginScope(
            It.Is<It.IsAnyType>((state, type) => VerifyScopeData(state, _sut.ContextData))),
            Times.Once);

        return this;
    }

    public LoggerTestAsserts<T> VerifyLog(Exception? exception = null)
    {
        Expression<Func<EventId, bool>> eventIdExpression = _sut.EventId.HasValue
            ? (eId) => eId.Id == _sut.EventId.Value.Id
            : (eId) => eId == It.IsAny<EventId>();

        Expression<Func<object, Type, bool>> stateExpression = _sut.MessageArgs?.Count > 0
            ? (state, type) => VerifyLogData(state, _sut.Message, _sut.MessageArgs)
            : (state, type) => state.ToString() == _sut.Message;

        Expression<Func<Exception, bool>> exceptionExpression = exception is not null
            ? (ex) => ex == exception
            : (ex) => ex == It.IsAny<Exception>();

        _sut.MockLogger.Verify(e => e.Log(
            _sut.LogLevel,
            It.Is(eventIdExpression),
            It.Is<It.IsAnyType>(stateExpression),
            It.Is(exceptionExpression),
            It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
        
        return this;
    }

    private static bool VerifyLogData(object state, string? expectedMessage, Dictionary<string, object?> expectedValues)
    {
        const string messageKeyName = "{OriginalFormat}";

        var loggedValues = (IReadOnlyList<KeyValuePair<string, object>>)state;
        var loggedMessage = loggedValues.Any(
            loggedValue =>
            loggedValue.Key == messageKeyName
         && loggedValue.Value.ToString() == expectedMessage);
        var loggedValue = expectedValues.All(
            expectedValue =>
            loggedValues.Any(
                loggedValue =>
                loggedValue.Key == expectedValue.Key
             && loggedValue.Value.ToString() == expectedValue.Value?.ToString()));

        return loggedMessage && loggedValue;
    }

    private static bool VerifyScopeData(object state, Dictionary<string, object?>? expectedValues)
    {
        var loggedValues = (IDictionary<string, object>)state;
        var loggedValue = expectedValues?.All(
            expectedValue =>
            loggedValues.Any(
                loggedValue =>
                loggedValue.Key == expectedValue.Key
             && Regex.IsMatch(expectedValue.Value?.ToString()!, @"^\^.*\$$")
                ? Regex.IsMatch(loggedValue.Value.ToString()!, expectedValue.Value?.ToString()!)
                : loggedValue.Value.ToString()! == expectedValue.Value?.ToString()!));

        return loggedValue ?? false;
    }
}
