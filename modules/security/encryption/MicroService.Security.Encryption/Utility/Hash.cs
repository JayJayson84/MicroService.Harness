using MicroService.Security.Encryption.Extensions;
using System.Text;

namespace MicroService.Security.Encryption.Utility;

/// <summary>
/// Represents an encoder class which implements Hash conversion methods.
/// </summary>
public static class Hash
{

    /// <summary>
    /// Converts a sequence of UTF-16 code units to a computed SHA1 hash value.
    /// </summary>
    /// <param name="text">A sequence of UTF-16 code units.</param>
    /// <param name="encoding">The character encoding to encode the UTF-16 sequence of code units.</param>
    /// <returns>The computed SHA1 hash code; otherwise, <see langword="null"/>.</returns>
    public static string? ConvertToSHA1Hash(string text, Encoding? encoding = null)
    {
        return text.ToSHA1Hash(encoding);
    }

    /// <summary>
    /// Converts a sequence of UTF-16 code units to an array of computed SHA256 hash bytes.
    /// </summary>
    /// <param name="text">A sequence of UTF-16 code units.</param>
    /// <param name="length">The number of bytes to allocate to the array, based on the computed block size.</param>
    /// <returns>An array of computed SHA256 hash bytes; otherwise, <see langword="null"/>.</returns>
    public static byte[] ConvertToSHA256Bytes(string? text, int length = 0)
    {
        return text?.ToSHA256Bytes(length) ?? [];
    }

    /// <summary>
    /// Converts a sequence of UTF-16 code units to an array of computed SHA256 hash bytes.
    /// </summary>
    /// <param name="text">A sequence of UTF-16 code units.</param>
    /// <param name="encoding">The character encoding to decode the SHA256 sequence of bytes.</param>
    /// <param name="length">The number of bytes to allocate to the array, based on the computed block size.</param>
    /// <returns>An array of computed SHA256 hash bytes; otherwise, <see langword="null"/>.</returns>
    public static byte[] ConvertToSHA256Bytes(string? text, Encoding encoding, int length = 0)
    {
        return text?.ToSHA256Bytes(encoding, length) ?? [];
    }

    /// <summary>
    /// Converts a sequence of UTF-16 code units to an equivalent sequence of decoded SHA256 code units.
    /// </summary>
    /// <param name="text">A sequence of UTF-16 code units.</param>
    /// <param name="length">The number of bytes to allocate to the array, based on the computed block size.</param>
    /// <returns>The computed SHA256 hash code; otherwise, <see langword="null"/>.</returns>
    public static string? ConvertToSHA256Hash(string text, int length = 0)
    {
        return text.ToSHA256Hash(length);
    }

    /// <summary>
    /// Converts a sequence of UTF-16 code units to an equivalent sequence of decoded SHA256 code units.
    /// </summary>
    /// <param name="text">A sequence of UTF-16 code units.</param>
    /// <param name="encoding">The character encoding to decode the SHA256 sequence of bytes.</param>
    /// <param name="length">The number of bytes to allocate to the array, based on the computed block size.</param>
    /// <returns>The computed SHA256 hash code; otherwise, <see langword="null"/>.</returns>
    public static string? ConvertToSHA256Hash(string text, Encoding encoding, int length = 0)
    {
        return text.ToSHA256Hash(encoding, length);
    }

}
