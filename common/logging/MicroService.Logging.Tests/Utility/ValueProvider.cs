using System.Runtime.CompilerServices;
using MicroService.Components.Tests.Utility;
using MicroService.Logging.Tests.Fakes;
using Microsoft.Extensions.Logging;

namespace MicroService.Logging.Tests.Utility;

public class ValueProvider : GlobalValueProvider
{
    public const string LogMessage = "Test Message";
    public const string LogMessageWithExpressionBody = "Message ID: {messageId}";
    public const string LogError = "Exception Message";
    public const string LogErrorWithExpressionBody = "Exception thrown on Message ID: {messageId}";

    public static EventId RandomEventId() => new(RandomInt(1));
    public static FakeContextAttributes ContextAttributes(Guid? contextId = null) => new() { ContextId = contextId ?? RandomGuid() };
    public static Dictionary<string, object> ContextData(object value, [CallerArgumentExpression(nameof(value))] string valueName = "") => new() { { valueName, value } };
}
