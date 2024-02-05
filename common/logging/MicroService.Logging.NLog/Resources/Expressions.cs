using System.Text.RegularExpressions;

namespace MicroService.Logging.NLog.Resources;

internal static partial class Expressions
{
    [GeneratedRegex(@"^([a-z][a-z0-9]*\.?)+$", RegexOptions.IgnoreCase, "en-GB")]
    internal static partial Regex LogLevel();
}
