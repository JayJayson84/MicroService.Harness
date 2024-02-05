namespace MicroService.Security.Encryption.Extensions;

public static class ByteArray
{

    /// <summary>
    /// Converts an array of 8-bit unsigned integers to its equivalent string representation that is encoded with base-64 digits.
    /// </summary>
    /// <param name="byteArray">An array of 8-bit unsigned integers.</param>
    /// <returns>An encoded base-64 string; otherwise, <see langword="null"/>.</returns>
    public static string? ToBase64String(this byte[] byteArray)
    {
        return byteArray == null || byteArray.Length == 0
            ? null
            : Convert.ToBase64String(byteArray);
    }

}
