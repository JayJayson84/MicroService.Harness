using System.Text;

namespace MicroService.Security.Encryption.Utility;

/// <summary>
/// Represents an encoder class which implements String conversion methods.
/// </summary>
public static class String
{

    /// <summary>
    /// Generates a random sequence of UTF-16 code units of specified length.
    /// </summary>
    /// <param name="length">The number of code units to allocate to the string.</param>
    /// <returns>A random string of specified length; otherwise, <see langword="null"/>.</returns>
    public static string? GenerateRandomString(int length)
    {
        var random = new Random();
        var stringBuilder = new StringBuilder();

        for (int i = 0; i < length; i++)
        {
            stringBuilder.Append(Convert.ToChar(random.Next(33, 126)));
        }

        return stringBuilder.ToString();
    }

}
