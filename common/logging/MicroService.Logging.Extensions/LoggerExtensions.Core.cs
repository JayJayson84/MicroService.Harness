using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;

namespace MicroService.Logging.Extensions;

/// <summary>
/// ILogger extension methods for common scenarios.
/// </summary>
public static partial class LoggerExtensions
{

    #region Log Action

    /// <summary>
    /// Creates a scope with context data and writes and formats a log message to the scope.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> to write to.</param>
    /// <param name="logAction">A log action to invoke in the created scope.</param>
    /// <example>logger.LogWithContext(() => logger.LogError(eventId, exception, message, args))</example>
    /// <returns>The <see cref="ILogger"/> instance.</returns>
    /// <remarks>Enriches logs with caller information. See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/caller-information"/>.</remarks>
    public static ILogger LogWithContext(this ILogger logger, Action? logAction,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0)
    {
        var contextData = new Dictionary<string, object>()
        {
            { "FilePath", sourceFilePath },
            { "MemberName", memberName },
            { "LineNumber", sourceLineNumber }
        };

        using (logger.BeginScope(contextData))
        {
            logAction?.Invoke();
        }

        return logger;
    }

    /// <summary>
    /// Creates a scope with context data and writes and formats a log message to the scope.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> to write to.</param>
    /// <param name="logAction">A log action to invoke in the created scope.</param>
    /// <param name="contextData">A Dictionary<string, object> that contains zero or more objects to add to the scope.</param>
    /// <example>logger.LogWithContext(() => logger.LogError(eventId, exception, message, args), new Dictionary<string, object>())</example>
    /// <returns>The <see cref="ILogger"/> instance.</returns>
    /// <remarks>Enriches logs with caller information. See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/caller-information"/>.</remarks>
    public static ILogger LogWithContext(this ILogger logger, Action? logAction, Dictionary<string, object> contextData,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0)
    {
        contextData = contextData == null
            ? []
            : new Dictionary<string, object>(contextData);

        contextData.Add("FilePath", sourceFilePath);
        contextData.Add("MemberName", memberName);
        contextData.Add("LineNumber", sourceLineNumber);

        using (logger.BeginScope(contextData))
        {
            logAction?.Invoke();
        }

        return logger;
    }

    /// <summary>
    /// Creates a scope with context data and writes and formats a log message to the scope.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> to write to.</param>
    /// <param name="logAction">A log action to invoke in the created scope.</param>
    /// <param name="contextAttributes">A class that contains zero or more properties to add to the scope.</param>
    /// <example>logger.LogWithContext<ClassReference>(() => logger.LogError(eventId, exception, message, args), classInstance)</example>
    /// <returns>The <see cref="ILogger"/> instance.</returns>
    /// <remarks>Enriches logs with caller information. See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/caller-information"/>.</remarks>
    public static ILogger LogWithContext<TAttributes>(this ILogger logger, Action? logAction, TAttributes contextAttributes,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0
    )
    where TAttributes : class
    {
        var contextData = new Dictionary<string, object?>()
        {
            { "FilePath", sourceFilePath },
            { "MemberName", memberName },
            { "LineNumber", sourceLineNumber }
        };

        var properties = typeof(TAttributes).GetProperties();

        foreach (var property in properties)
        {
            if (!contextData.ContainsKey(property.Name)) contextData.Add(property.Name, property.GetValue(contextAttributes));
        }

        using (logger.BeginScope(contextData))
        {
            logAction?.Invoke();
        }

        return logger;
    }

    #endregion

    #region Log Scope

    /// <summary>
    /// Begins a logical operation scope with context data.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> to write to.</param>
    /// <example>using (logger.BeginScopeWithContext()) { }</example>
    /// <returns>An <see cref="IDisposable"/> that ends the logical operation scope on dispose.</returns>
    /// <remarks>Enriches logs with caller information. See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/caller-information"/>.</remarks>
    public static IDisposable? BeginScopeWithContext(this ILogger logger,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0)
    {
        var contextData = new Dictionary<string, object>()
        {
            { "FilePath", sourceFilePath },
            { "MemberName", memberName },
            { "LineNumber", sourceLineNumber }
        };

        return logger.BeginScope(contextData);
    }

    /// <summary>
    /// Begins a logical operation scope with context data.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> to write to.</param>
    /// <param name="contextData">A Dictionary<string, object> that contains zero or more objects to add to the scope.</param>
    /// <example>using (logger.BeginScopeWithContext(new Dictionary<string, object>())) { }</example>
    /// <returns>An <see cref="IDisposable"/> that ends the logical operation scope on dispose.</returns>
    /// <remarks>Enriches logs with caller information. See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/caller-information"/>.</remarks>
    public static IDisposable? BeginScopeWithContext(this ILogger logger, Dictionary<string, object> contextData,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0)
    {
        contextData = contextData == null
            ? []
            : new Dictionary<string, object>(contextData);

        contextData.Add("FilePath", sourceFilePath);
        contextData.Add("MemberName", memberName);
        contextData.Add("LineNumber", sourceLineNumber);

        return logger.BeginScope(contextData);
    }

    /// <summary>
    /// Begins a logical operation scope with context data.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> to write to.</param>
    /// <param name="contextAttributes">A class that contains zero or more properties to add to the scope.</param>
    /// <example>using (logger.BeginScopeWithContext<ClassReference>(classInstance)) { }</example>
    /// <returns>An <see cref="IDisposable"/> that ends the logical operation scope on dispose.</returns>
    /// <remarks>Enriches logs with caller information. See <see href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/caller-information"/>.</remarks>
    public static IDisposable? BeginScopeWithContext<TAttributes>(this ILogger logger, TAttributes contextAttributes,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0
    )
    where TAttributes : class
    {
        var contextData = new Dictionary<string, object?>()
        {
            { "FilePath", sourceFilePath },
            { "MemberName", memberName },
            { "LineNumber", sourceLineNumber }
        };

        var properties = typeof(TAttributes).GetProperties();

        foreach (var property in properties)
        {
            contextData.Add(property.Name, property.GetValue(contextAttributes));
        }

        return logger.BeginScope(contextData);
    }

    #endregion

}
