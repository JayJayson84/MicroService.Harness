using System.Text.RegularExpressions;

namespace MicroService.Security.Encryption.Extensions.Resources;

public static partial class Expressions
{
    [GeneratedRegex("^[a-zA-Z0-9\\+/]*={0,3}$", RegexOptions.None)]
    public static partial Regex Base64();
}
