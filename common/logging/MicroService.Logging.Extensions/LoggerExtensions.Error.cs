using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;

namespace MicroService.Logging.Extensions;

public static partial class LoggerExtensions
{

#pragma warning disable CA2254

    #region Error

    /// <summary>
    /// Creates a scope with context data and writes and formats a error log message to the scope.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> to write to.</param>
    /// <param name="message">Format string of the log message in message template format. Example: <c>"User {User} logged in from {Address}"</c></param>
    /// <param name="messageArgs">An object array that contains zero or more objects to format.</param>
    /// <example>logger.LogError("Processing request from {Address}", messageArgs: address)</example>
    /// <remarks>Enriches logs with caller information. See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/caller-information"/>.</remarks>
    public static ILogger LogErrorWithContext(this ILogger logger, string? message,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0,
        params object?[] messageArgs)
    => LogWithContext(logger, () => logger.LogError(message, messageArgs), memberName, sourceFilePath, sourceLineNumber);

    /// <summary>
    /// Creates a scope with context data and writes and formats a error log message to the scope.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> to write to.</param>
    /// <param name="message">Format string of the log message in message template format. Example: <c>"User {User} logged in from {Address}"</c></param>
    /// <param name="messageArgs">An object array that contains zero or more objects to format.</param>
    /// <example>logger.LogError("Processing request from {Address}", new object[] { address })</example>
    /// <remarks>Enriches logs with caller information. See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/caller-information"/>.</remarks>
    public static ILogger LogErrorWithContext(this ILogger logger, string? message, object?[] messageArgs,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0)
    => LogWithContext(logger, () => logger.LogError(message, messageArgs), memberName, sourceFilePath, sourceLineNumber);

    /// <summary>
    /// Creates a scope with context data and writes and formats a error log message to the scope.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> to write to.</param>
    /// <param name="eventId">The event id associated with the log.</param>
    /// <param name="message">Format string of the log message in message template format. Example: <c>"User {User} logged in from {Address}"</c></param>
    /// <param name="messageArgs">An object array that contains zero or more objects to format.</param>
    /// <example>logger.LogError(0, "Processing request from {Address}", messageArgs: address)</example>
    /// <remarks>Enriches logs with caller information. See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/caller-information"/>.</remarks>
    public static ILogger LogErrorWithContext(this ILogger logger, EventId eventId, string? message,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0,
        params object?[] messageArgs)
    => LogWithContext(logger, () => logger.LogError(eventId, message, messageArgs), memberName, sourceFilePath, sourceLineNumber);

    /// <summary>
    /// Creates a scope with context data and writes and formats a error log message to the scope.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> to write to.</param>
    /// <param name="eventId">The event id associated with the log.</param>
    /// <param name="message">Format string of the log message in message template format. Example: <c>"User {User} logged in from {Address}"</c></param>
    /// <param name="messageArgs">An object array that contains zero or more objects to format.</param>
    /// <example>logger.LogError(0, "Processing request from {Address}", new object[] { address })</example>
    /// <remarks>Enriches logs with caller information. See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/caller-information"/>.</remarks>
    public static ILogger LogErrorWithContext(this ILogger logger, EventId eventId, string? message, object?[] messageArgs,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0)
    => LogWithContext(logger, () => logger.LogError(eventId, message, messageArgs), memberName, sourceFilePath, sourceLineNumber);

    /// <summary>
    /// Creates a scope with context data and writes and formats a error log message to the scope.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> to write to.</param>
    /// <param name="eventId">The event id associated with the log.</param>
    /// <param name="exception">The exception to log.</param>
    /// <param name="message">Format string of the log message in message template format. Example: <c>"User {User} logged in from {Address}"</c></param>
    /// <param name="messageArgs">An object array that contains zero or more objects to format.</param>
    /// <example>logger.LogError(0, exception, "Error while processing request from {Address}", messageArgs: address)</example>
    /// <remarks>Enriches logs with caller information. See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/caller-information"/>.</remarks>
    public static ILogger LogErrorWithContext(this ILogger logger, EventId eventId, Exception? exception, string? message,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0,
        params object?[] messageArgs)
    => LogWithContext(logger, () => logger.LogError(eventId, exception, message, messageArgs), memberName, sourceFilePath, sourceLineNumber);

    /// <summary>
    /// Creates a scope with context data and writes and formats a error log message to the scope.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> to write to.</param>
    /// <param name="eventId">The event id associated with the log.</param>
    /// <param name="exception">The exception to log.</param>
    /// <param name="message">Format string of the log message in message template format. Example: <c>"User {User} logged in from {Address}"</c></param>
    /// <param name="messageArgs">An object array that contains zero or more objects to format.</param>
    /// <example>logger.LogError(0, exception, "Error while processing request from {Address}", new object[] { address })</example>
    /// <remarks>Enriches logs with caller information. See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/caller-information"/>.</remarks>
    public static ILogger LogErrorWithContext(this ILogger logger, EventId eventId, Exception? exception, string? message, object?[] messageArgs,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0)
    => LogWithContext(logger, () => logger.LogError(eventId, exception, message, messageArgs), memberName, sourceFilePath, sourceLineNumber);

    /// <summary>
    /// Creates a scope with context data and writes and formats a error log message to the scope.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> to write to.</param>
    /// <param name="exception">The exception to log.</param>
    /// <param name="message">Format string of the log message in message template format. Example: <c>"User {User} logged in from {Address}"</c></param>
    /// <param name="messageArgs">An object array that contains zero or more objects to format.</param>
    /// <example>logger.LogError(exception, "Error while processing request from {Address}", messageArgs: address)</example>
    /// <remarks>Enriches logs with caller information. See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/caller-information"/>.</remarks>
    public static ILogger LogErrorWithContext(this ILogger logger, Exception? exception, string? message,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0,
        params object?[] messageArgs)
    => LogWithContext(logger, () => logger.LogError(exception, message, messageArgs), memberName, sourceFilePath, sourceLineNumber);

    /// <summary>
    /// Creates a scope with context data and writes and formats a error log message to the scope.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> to write to.</param>
    /// <param name="exception">The exception to log.</param>
    /// <param name="message">Format string of the log message in message template format. Example: <c>"User {User} logged in from {Address}"</c></param>
    /// <param name="messageArgs">An object array that contains zero or more objects to format.</param>
    /// <example>logger.LogError(exception, "Error while processing request from {Address}", new object[] { address })</example>
    /// <remarks>Enriches logs with caller information. See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/caller-information"/>.</remarks>
    public static ILogger LogErrorWithContext(this ILogger logger, Exception? exception, string? message, object?[] messageArgs,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0)
    => LogWithContext(logger, () => logger.LogError(exception, message, messageArgs), memberName, sourceFilePath, sourceLineNumber);

    #endregion

    #region Error With Context Data

    /// <summary>
    /// Creates a scope with context data and writes and formats a error log message to the scope.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> to write to.</param>
    /// <param name="contextData">A Dictionary<string, object> that contains zero or more objects to add to the scope.</param>
    /// <param name="message">Format string of the log message in message template format. Example: <c>"User {User} logged in from {Address}"</c></param>
    /// <param name="messageArgs">An object array that contains zero or more objects to format.</param>
    /// <example>logger.LogError(new Dictionary<string, object>(), "Processing request from {Address}", messageArgs: address)</example>
    /// <remarks>Enriches logs with caller information. See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/caller-information"/>.</remarks>
    public static ILogger LogErrorWithContext(this ILogger logger, Dictionary<string, object> contextData, string? message,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0,
        params object?[] messageArgs)
    => LogWithContext(logger, () => logger.LogError(message, messageArgs), contextData, memberName, sourceFilePath, sourceLineNumber);

    /// <summary>
    /// Creates a scope with context data and writes and formats a error log message to the scope.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> to write to.</param>
    /// <param name="contextData">A Dictionary<string, object> that contains zero or more objects to add to the scope.</param>
    /// <param name="message">Format string of the log message in message template format. Example: <c>"User {User} logged in from {Address}"</c></param>
    /// <param name="messageArgs">An object array that contains zero or more objects to format.</param>
    /// <example>logger.LogError(new Dictionary<string, object>(), "Processing request from {Address}", new object[] { address })</example>
    /// <remarks>Enriches logs with caller information. See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/caller-information"/>.</remarks>
    public static ILogger LogErrorWithContext(this ILogger logger, Dictionary<string, object> contextData, string? message, object?[] messageArgs,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0)
    => LogWithContext(logger, () => logger.LogError(message, messageArgs), contextData, memberName, sourceFilePath, sourceLineNumber);

    /// <summary>
    /// Creates a scope with context data and writes and formats a error log message to the scope.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> to write to.</param>
    /// <param name="contextData">A Dictionary<string, object> that contains zero or more objects to add to the scope.</param>
    /// <param name="eventId">The event id associated with the log.</param>
    /// <param name="message">Format string of the log message in message template format. Example: <c>"User {User} logged in from {Address}"</c></param>
    /// <param name="messageArgs">An object array that contains zero or more objects to format.</param>
    /// <example>logger.LogError(new Dictionary<string, object>(), 0, "Processing request from {Address}", messageArgs: address)</example>
    /// <remarks>Enriches logs with caller information. See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/caller-information"/>.</remarks>
    public static ILogger LogErrorWithContext(this ILogger logger, Dictionary<string, object> contextData, EventId eventId, string? message,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0,
        params object?[] messageArgs)
    => LogWithContext(logger, () => logger.LogError(eventId, message, messageArgs), contextData, memberName, sourceFilePath, sourceLineNumber);

    /// <summary>
    /// Creates a scope with context data and writes and formats a error log message to the scope.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> to write to.</param>
    /// <param name="contextData">A Dictionary<string, object> that contains zero or more objects to add to the scope.</param>
    /// <param name="eventId">The event id associated with the log.</param>
    /// <param name="message">Format string of the log message in message template format. Example: <c>"User {User} logged in from {Address}"</c></param>
    /// <param name="messageArgs">An object array that contains zero or more objects to format.</param>
    /// <example>logger.LogError(new Dictionary<string, object>(), 0, "Processing request from {Address}", new object[] { address })</example>
    /// <remarks>Enriches logs with caller information. See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/caller-information"/>.</remarks>
    public static ILogger LogErrorWithContext(this ILogger logger, Dictionary<string, object> contextData, EventId eventId, string? message, object?[] messageArgs,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0)
    => LogWithContext(logger, () => logger.LogError(eventId, message, messageArgs), contextData, memberName, sourceFilePath, sourceLineNumber);

    /// <summary>
    /// Creates a scope with context data and writes and formats a error log message to the scope.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> to write to.</param>
    /// <param name="contextData">A Dictionary<string, object> that contains zero or more objects to add to the scope.</param>
    /// <param name="eventId">The event id associated with the log.</param>
    /// <param name="exception">The exception to log.</param>
    /// <param name="message">Format string of the log message in message template format. Example: <c>"User {User} logged in from {Address}"</c></param>
    /// <param name="messageArgs">An object array that contains zero or more objects to format.</param>
    /// <example>logger.LogError(new Dictionary<string, object>(), 0, exception, "Error while processing request from {Address}", messageArgs: address)</example>
    /// <remarks>Enriches logs with caller information. See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/caller-information"/>.</remarks>
    public static ILogger LogErrorWithContext(this ILogger logger, Dictionary<string, object> contextData, EventId eventId, Exception? exception, string? message,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0,
        params object?[] messageArgs)
    => LogWithContext(logger, () => logger.LogError(eventId, exception, message, messageArgs), contextData, memberName, sourceFilePath, sourceLineNumber);

    /// <summary>
    /// Creates a scope with context data and writes and formats a error log message to the scope.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> to write to.</param>
    /// <param name="contextData">A Dictionary<string, object> that contains zero or more objects to add to the scope.</param>
    /// <param name="eventId">The event id associated with the log.</param>
    /// <param name="exception">The exception to log.</param>
    /// <param name="message">Format string of the log message in message template format. Example: <c>"User {User} logged in from {Address}"</c></param>
    /// <param name="messageArgs">An object array that contains zero or more objects to format.</param>
    /// <example>logger.LogError(new Dictionary<string, object>(), 0, exception, "Error while processing request from {Address}", new object[] { address })</example>
    /// <remarks>Enriches logs with caller information. See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/caller-information"/>.</remarks>
    public static ILogger LogErrorWithContext(this ILogger logger, Dictionary<string, object> contextData, EventId eventId, Exception? exception, string? message, object?[] messageArgs,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0)
    => LogWithContext(logger, () => logger.LogError(eventId, exception, message, messageArgs), contextData, memberName, sourceFilePath, sourceLineNumber);

    /// <summary>
    /// Creates a scope with context data and writes and formats a error log message to the scope.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> to write to.</param>
    /// <param name="contextData">A Dictionary<string, object> that contains zero or more objects to add to the scope.</param>
    /// <param name="exception">The exception to log.</param>
    /// <param name="message">Format string of the log message in message template format. Example: <c>"User {User} logged in from {Address}"</c></param>
    /// <param name="messageArgs">An object array that contains zero or more objects to format.</param>
    /// <example>logger.LogError(new Dictionary<string, object>(), exception, "Error while processing request from {Address}", messageArgs: address)</example>
    /// <remarks>Enriches logs with caller information. See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/caller-information"/>.</remarks>
    public static ILogger LogErrorWithContext(this ILogger logger, Dictionary<string, object> contextData, Exception? exception, string? message,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0,
        params object?[] messageArgs)
    => LogWithContext(logger, () => logger.LogError(exception, message, messageArgs), contextData, memberName, sourceFilePath, sourceLineNumber);

    /// <summary>
    /// Creates a scope with context data and writes and formats a error log message to the scope.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> to write to.</param>
    /// <param name="contextData">A Dictionary<string, object> that contains zero or more objects to add to the scope.</param>
    /// <param name="exception">The exception to log.</param>
    /// <param name="message">Format string of the log message in message template format. Example: <c>"User {User} logged in from {Address}"</c></param>
    /// <param name="messageArgs">An object array that contains zero or more objects to format.</param>
    /// <example>logger.LogError(new Dictionary<string, object>(), exception, "Error while processing request from {Address}", new object[] { address })</example>
    /// <remarks>Enriches logs with caller information. See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/caller-information"/>.</remarks>
    public static ILogger LogErrorWithContext(this ILogger logger, Dictionary<string, object> contextData, Exception? exception, string? message, object?[] messageArgs,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0)
    => LogWithContext(logger, () => logger.LogError(exception, message, messageArgs), contextData, memberName, sourceFilePath, sourceLineNumber);

    #endregion

    #region Error With Context Attributes

    /// <summary>
    /// Creates a scope with context data and writes and formats a error log message to the scope.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> to write to.</param>
    /// <param name="contextAttributes">A class that contains zero or more properties to add to the scope.</param>
    /// <param name="message">Format string of the log message in message template format. Example: <c>"User {User} logged in from {Address}"</c></param>
    /// <param name="messageArgs">An object array that contains zero or more objects to format.</param>
    /// <example>logger.LogError<ClassReference>(classInstance, "Processing request from {Address}", messageArgs: address)</example>
    /// <remarks>Enriches logs with caller information. See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/caller-information"/>.</remarks>
    public static ILogger LogErrorWithContext<TAttributes>(this ILogger logger, TAttributes contextAttributes, string? message,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0,
        params object?[] messageArgs)
        where TAttributes : class
    => LogWithContext(logger, () => logger.LogError(message, messageArgs), contextAttributes, memberName, sourceFilePath, sourceLineNumber);

    /// <summary>
    /// Creates a scope with context data and writes and formats a error log message to the scope.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> to write to.</param>
    /// <param name="contextAttributes">A class that contains zero or more properties to add to the scope.</param>
    /// <param name="message">Format string of the log message in message template format. Example: <c>"User {User} logged in from {Address}"</c></param>
    /// <param name="messageArgs">An object array that contains zero or more objects to format.</param>
    /// <example>logger.LogError<ClassReference>(classInstance, "Processing request from {Address}", new object[] { address })</example>
    /// <remarks>Enriches logs with caller information. See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/caller-information"/>.</remarks>
    public static ILogger LogErrorWithContext<TAttributes>(this ILogger logger, TAttributes contextAttributes, string? message, object?[] messageArgs,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0)
        where TAttributes : class
    => LogWithContext(logger, () => logger.LogError(message, messageArgs), contextAttributes, memberName, sourceFilePath, sourceLineNumber);

    /// <summary>
    /// Creates a scope with context data and writes and formats a error log message to the scope.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> to write to.</param>
    /// <param name="contextAttributes">A class that contains zero or more properties to add to the scope.</param>
    /// <param name="eventId">The event id associated with the log.</param>
    /// <param name="message">Format string of the log message in message template format. Example: <c>"User {User} logged in from {Address}"</c></param>
    /// <param name="messageArgs">An object array that contains zero or more objects to format.</param>
    /// <example>logger.LogError<ClassReference>(classInstance, 0, "Processing request from {Address}", messageArgs: address)</example>
    /// <remarks>Enriches logs with caller information. See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/caller-information"/>.</remarks>
    public static ILogger LogErrorWithContext<TAttributes>(this ILogger logger, TAttributes contextAttributes, EventId eventId, string? message,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0,
        params object?[] messageArgs)
        where TAttributes : class
    => LogWithContext(logger, () => logger.LogError(eventId, message, messageArgs), contextAttributes, memberName, sourceFilePath, sourceLineNumber);

    /// <summary>
    /// Creates a scope with context data and writes and formats a error log message to the scope.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> to write to.</param>
    /// <param name="contextAttributes">A class that contains zero or more properties to add to the scope.</param>
    /// <param name="eventId">The event id associated with the log.</param>
    /// <param name="message">Format string of the log message in message template format. Example: <c>"User {User} logged in from {Address}"</c></param>
    /// <param name="messageArgs">An object array that contains zero or more objects to format.</param>
    /// <example>logger.LogError<ClassReference>(classInstance, 0, "Processing request from {Address}", new object[] { address })</example>
    /// <remarks>Enriches logs with caller information. See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/caller-information"/>.</remarks>
    public static ILogger LogErrorWithContext<TAttributes>(this ILogger logger, TAttributes contextAttributes, EventId eventId, string? message, object?[] messageArgs,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0)
        where TAttributes : class
    => LogWithContext(logger, () => logger.LogError(eventId, message, messageArgs), contextAttributes, memberName, sourceFilePath, sourceLineNumber);

    /// <summary>
    /// Creates a scope with context data and writes and formats a error log message to the scope.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> to write to.</param>
    /// <param name="contextAttributes">A class that contains zero or more properties to add to the scope.</param>
    /// <param name="eventId">The event id associated with the log.</param>
    /// <param name="exception">The exception to log.</param>
    /// <param name="message">Format string of the log message in message template format. Example: <c>"User {User} logged in from {Address}"</c></param>
    /// <param name="messageArgs">An object array that contains zero or more objects to format.</param>
    /// <example>logger.LogError<ClassReference>(classInstance, 0, exception, "Error while processing request from {Address}", messageArgs: address)</example>
    /// <remarks>Enriches logs with caller information. See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/caller-information"/>.</remarks>
    public static ILogger LogErrorWithContext<TAttributes>(this ILogger logger, TAttributes contextAttributes, EventId eventId, Exception? exception, string? message,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0,
        params object?[] messageArgs)
        where TAttributes : class
    => LogWithContext(logger, () => logger.LogError(eventId, exception, message, messageArgs), contextAttributes, memberName, sourceFilePath, sourceLineNumber);

    /// <summary>
    /// Creates a scope with context data and writes and formats a error log message to the scope.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> to write to.</param>
    /// <param name="contextAttributes">A class that contains zero or more properties to add to the scope.</param>
    /// <param name="eventId">The event id associated with the log.</param>
    /// <param name="exception">The exception to log.</param>
    /// <param name="message">Format string of the log message in message template format. Example: <c>"User {User} logged in from {Address}"</c></param>
    /// <param name="messageArgs">An object array that contains zero or more objects to format.</param>
    /// <example>logger.LogError<ClassReference>(classInstance, 0, exception, "Error while processing request from {Address}", new object[] { address })</example>
    /// <remarks>Enriches logs with caller information. See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/caller-information"/>.</remarks>
    public static ILogger LogErrorWithContext<TAttributes>(this ILogger logger, TAttributes contextAttributes, EventId eventId, Exception? exception, string? message, object?[] messageArgs,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0)
        where TAttributes : class
    => LogWithContext(logger, () => logger.LogError(eventId, exception, message, messageArgs), contextAttributes, memberName, sourceFilePath, sourceLineNumber);

    /// <summary>
    /// Creates a scope with context data and writes and formats a error log message to the scope.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> to write to.</param>
    /// <param name="contextAttributes">A class that contains zero or more properties to add to the scope.</param>
    /// <param name="exception">The exception to log.</param>
    /// <param name="message">Format string of the log message in message template format. Example: <c>"User {User} logged in from {Address}"</c></param>
    /// <param name="messageArgs">An object array that contains zero or more objects to format.</param>
    /// <example>logger.LogError<ClassReference>(classInstance, exception, "Error while processing request from {Address}", messageArgs: address)</example>
    /// <remarks>Enriches logs with caller information. See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/caller-information"/>.</remarks>
    public static ILogger LogErrorWithContext<TAttributes>(this ILogger logger, TAttributes contextAttributes, Exception? exception, string? message,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0,
        params object?[] messageArgs)
        where TAttributes : class
    => LogWithContext(logger, () => logger.LogError(exception, message, messageArgs), contextAttributes, memberName, sourceFilePath, sourceLineNumber);

    /// <summary>
    /// Creates a scope with context data and writes and formats a error log message to the scope.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> to write to.</param>
    /// <param name="contextAttributes">A class that contains zero or more properties to add to the scope.</param>
    /// <param name="exception">The exception to log.</param>
    /// <param name="message">Format string of the log message in message template format. Example: <c>"User {User} logged in from {Address}"</c></param>
    /// <param name="messageArgs">An object array that contains zero or more objects to format.</param>
    /// <example>logger.LogError<ClassReference>(classInstance, exception, "Error while processing request from {Address}", new object[] { address })</example>
    /// <remarks>Enriches logs with caller information. See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/caller-information"/>.</remarks>
    public static ILogger LogErrorWithContext<TAttributes>(this ILogger logger, TAttributes contextAttributes, Exception? exception, string? message, object?[] messageArgs,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0)
        where TAttributes : class
    => LogWithContext(logger, () => logger.LogError(exception, message, messageArgs), contextAttributes, memberName, sourceFilePath, sourceLineNumber);

    #endregion

#pragma warning restore CA2254

}
