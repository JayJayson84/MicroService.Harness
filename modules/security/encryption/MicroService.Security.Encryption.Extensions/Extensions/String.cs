using MicroService.Security.Encryption.Extensions.Resources;
using System.Security.Cryptography;
using System.Text;

namespace MicroService.Security.Encryption.Extensions;

public static partial class String
{

    /// <summary>
    /// An extension method to check if a string is not null, empty or consists of only whitespace characters.
    /// </summary>
    /// <param name="value">Instance type to extend.</param>
    /// <returns><see langword="true"/> if the string contains a value. Otherwise <see langword="false"/>.</returns>
    public static bool HasValue(this string? value)
    {
        if (value == null || value.Length == 0) return false;

        for (int i = 0; i < value.Length; i++)
        {
            if (!char.IsWhiteSpace(value[i]))
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Indicates whether the UTF-16 code units match the base-64 string pattern.
    /// </summary>
    /// <param name="string">A sequence of UTF-16 code units.</param>
    /// <returns><see langword="True"/> if the string matches the base-64 string pattern; otherwise, <see langword="false"/>.</returns>
    public static bool IsBase64String(this string @string)
    {
        @string = @string.Trim();
        return @string.Length % 4 == 0 && Expressions.Base64().IsMatch(@string);
    }

    /// <summary>
    /// Converts a sequence of UTF-16 code units to its equivalent string representation that is encoded with base-64 digits.
    /// </summary>
    /// <param name="string">A sequence of UTF-16 code units.</param>
    /// <returns>An encoded base-64 string; otherwise, <see langword="null"/>.</returns>
    public static string? ToBase64String(this string @string)
    {
        return @string != null
            ? Convert.ToBase64String(Encoding.UTF8.GetBytes(@string))
            : null;
    }

    /// <summary>
    /// Converts the specified string, which encodes binary data as base-64 digits, to an equivalent 8-bit unsigned integer array.
    /// </summary>
    /// <param name="string">An encoded base-64 string.</param>
    /// <returns>An array of 8-bit unsigned integers that is equivalent to <paramref name="string"/>; otherwise, <see langword="null"/>.</returns>
    public static byte[] FromBase64String(this string @string)
    {
        return @string == null
            ? Array.Empty<byte>()
            : Convert.FromBase64String(@string);
    }

    /// <summary>
    /// Converts the specified string, which encodes binary data as base-64 digits, to an equivalent sequence of decoded code units.
    /// </summary>
    /// <param name="string">An encoded base-64 string.</param>
    /// <param name="encoding">The character encoding to decode the base-64 sequence of bytes.</param>
    /// <returns>A string that contains the results of decoding the specified sequence of bytes; otherwise, <see langword="null"/>.</returns>
    public static string? FromBase64String(this string @string, Encoding encoding)
    {
        var array = @string.FromBase64String();

        return array?.Length > 0
            ? encoding.GetString(array)
            : null;
    }

    /// <summary>
    /// Returns a computed SHA1 hash value for the specified UTF-16 string.
    /// </summary>
    /// <param name="string">A sequence of UTF-16 code units.</param>
    /// <param name="encoding">The character encoding to encode the UTF-16 sequence of code units.</param>
    /// <returns>The computed SHA1 hash code; otherwise, <see langword="null"/>.</returns>
    public static string? ToSHA1Hash(this string @string, Encoding? encoding = null)
    {
        encoding ??= Encoding.Default;

        byte[] hash = SHA256.HashData(encoding.GetBytes(@string));

        var stringBuilder = new StringBuilder(hash.Length * 2);

        Array.ForEach(hash, x => stringBuilder.Append(x.ToString("X2")));

        return stringBuilder.ToString();
    }

    /// <summary>
    /// Returns an array of computed SHA256 hash bytes for the specified UTF-16 string.
    /// </summary>
    /// <param name="string">A sequence of UTF-16 code units.</param>
    /// <param name="length">The number of bytes to allocate to the array, based on the computed block size.</param>
    /// <returns>An array of computed SHA256 hash bytes; otherwise, <see langword="null"/>.</returns>
    public static byte[] ToSHA256Bytes(this string @string, int length = 0)
    {
        return @string.ToSHA256Bytes(Encoding.UTF8, length);
    }

    /// <summary>
    /// Returns an array of computed SHA256 hash bytes for the specified UTF-16 string.
    /// </summary>
    /// <param name="string">A sequence of UTF-16 code units.</param>
    /// <param name="encoding">The character encoding to decode the SHA256 sequence of bytes.</param>
    /// <param name="length">The number of bytes to allocate to the array, based on the computed block size.</param>
    /// <returns>An array of computed SHA256 hash bytes; otherwise, <see langword="null"/>.</returns>
    public static byte[] ToSHA256Bytes(this string @string, Encoding encoding, int length = 0)
    {
        byte[] hash = SHA256.HashData(encoding.GetBytes(@string));

        if (length == 0) return hash;

        var hashArray = new byte[length];
        Array.Copy(hash, hashArray, length);

        return hashArray;
    }

    /// <summary>
    /// Returns a computed SHA256 hash value for the specified UTF-16 string, as an equivalent sequence of decoded code units.
    /// </summary>
    /// <param name="string">A sequence of UTF-16 code units.</param>
    /// <param name="length">The number of bytes to allocate to the array, based on the computed block size.</param>
    /// <returns>The computed SHA256 hash code; otherwise, <see langword="null"/>.</returns>
    public static string? ToSHA256Hash(this string @string, int length = 0)
    {
        return @string.ToSHA256Hash(Encoding.UTF8, length);
    }

    /// <summary>
    /// Returns a computed SHA256 hash value for the specified UTF-16 string, as an equivalent sequence of decoded code units.
    /// </summary>
    /// <param name="string">A sequence of UTF-16 code units.</param>
    /// <param name="encoding">The character encoding to decode the SHA256 sequence of bytes.</param>
    /// <param name="length">The number of bytes to allocate to the array, based on the computed block size.</param>
    /// <returns>The computed SHA256 hash code; otherwise, <see langword="null"/>.</returns>
    public static string? ToSHA256Hash(this string @string, Encoding encoding, int length = 0)
    {
        var hashBytes = @string.ToSHA256Bytes(encoding, length);
        if (hashBytes.Length == 0) return null;

        var hash = new StringBuilder();

        foreach (var @byte in hashBytes)
        {
            hash.Append(@byte.ToString("x2"));
        }

        return hash.ToString();
    }

}
