using System.Security.Cryptography;

namespace MicroService.Security.Encryption.Utility;

/// <summary>
/// Represents an encoder class which implements Byte conversion methods.
/// </summary>
public static class Byte
{

    #region Public Methods

    /// <summary>
    /// Fills an array of bytes with a cryptographically strong sequence of random values.
    /// </summary>
    /// <param name="count">The number of bytes to fill.</param>
    /// <returns>An array of cryptographically strong bytes of specified length.</returns>
    public static byte[] GenerateBitsOfRandomEntropy(int count)
    {
        var randomBytes = new byte[count];

        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomBytes);

        return randomBytes;
    }

    #endregion

    #region Internal Methods

    /// <summary>
    /// Extracts the IV bytes from a string previously encrypted with a symmetric algorithm.
    /// </summary>
    /// <param name="input">The UTF-16 string.</param>
    /// <param name="keySize">The size, in bits, of the secret key that was used for the cryptographic operation.</param>
    /// <param name="hasCipherGeneratedSalt">True if the input contains a cipher generated salt value; otherwise false.</param>
    /// <returns>The extracted IV bytes.</returns>
    internal static byte[] GetIvBytes(byte[] input, int keySize, bool hasCipherGeneratedSalt)
    {
        return hasCipherGeneratedSalt
            ? input
                .Skip(keySize)
                .Take(keySize)
                .ToArray()
            : input
                .Take(keySize)
                .ToArray();
    }

    /// <summary>
    /// Extracts the Cipher bytes from a string previously encrypted with a symmetric algorithm.
    /// </summary>
    /// <param name="input">The UTF-16 string.</param>
    /// <param name="keySize">The size, in bits, of the secret key that was used for the cryptographic operation.</param>
    /// <param name="hasCipherGeneratedSalt">True if the input contains a cipher generated salt value; otherwise false.</param>
    /// <returns>The extracted Cipher bytes.</returns>
    internal static byte[] GetCipherBytes(byte[] input, int keySize, bool hasCipherGeneratedSalt)
    {
        return hasCipherGeneratedSalt
            ? input
                .Skip(keySize * 2)
                .Take(input.Length - (keySize * 2))
                .ToArray()
            : input
                .Skip(keySize)
                .Take(input.Length - keySize)
                .ToArray();
    }

    #endregion

}
