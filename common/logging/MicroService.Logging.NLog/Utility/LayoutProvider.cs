using NLog.Layouts;

namespace MicroService.Logging.NLog.Utility;

internal static class LayoutProvider
{
    internal static JsonLayout GenerateJsonLayout()
    {
        var rootLayout = new JsonLayout
        {
            IncludeScopeProperties = true,
            IncludeGdc = true
        };

        rootLayout.Attributes.Add(new JsonAttribute("date", @"${date:universalTime=True:format=yyyy-MM-ddTHH\:mm\:ss.fff}"));
        rootLayout.Attributes.Add(new JsonAttribute("level", @"${level:upperCase=true}"));
        rootLayout.Attributes.Add(new JsonAttribute("message", @"${message}"));
        rootLayout.Attributes.Add(new JsonAttribute("exception", @"${exception:format=ToString}"));
        rootLayout.Attributes.Add(new JsonAttribute("namespace", @"${logger}"));
        rootLayout.Attributes.Add(new JsonAttribute("eventProperties", new JsonLayout()
        {
            IncludeEventProperties = true,
            MaxRecursionLimit = 2
        },
        encode: false));

        return rootLayout;
    }
}
