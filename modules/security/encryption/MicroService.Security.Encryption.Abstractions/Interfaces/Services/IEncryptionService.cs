using System.ComponentModel;
using System.Security.Cryptography;
using MicroService.Security.Encryption.Enums;
using MicroService.Security.Encryption.Models;

namespace MicroService.Security.Encryption.Interfaces;

/// <summary>
/// Provides a managed implementation for encrypting and decrypting with a cryptographic symmetric algorithm.
/// </summary>
/// <remarks>Supported algorithms: <see cref="Aes"/>, <see cref="DES"/>, <see cref="RC2"/>, <see cref="TripleDES"/>.</remarks>
public interface IEncryptionService
{
    /// <summary>
    /// Configures a managed implementation for encrypting and decrypting with a cryptographic symmetric algorithm.
    /// </summary>
    /// <param name="encryptionMethod">The type of symmetric algorithm to use.</param>
    void Configure(EncryptionMethod encryptionMethod);

    /// <inheritdoc cref="Configure(EncryptionMethod)" />
    /// <param name="encryptionMethod">The type of symmetric algorithm to use.</param>
    /// <param name="encryptionOptions">The values to use to set symmetric algorithm options.</param>
    void Configure(EncryptionMethod encryptionMethod, SymmetricAlgorithmOptions? encryptionOptions);

    /// <inheritdoc cref="Configure(EncryptionMethod)" />
    /// <param name="encryptionMethod">The type of symmetric algorithm to use.</param>
    /// <param name="keySize">The size, in bits, of the secret key used for the cryptographic operation.</param>
    /// <param name="blockSize">The block size, in bits, of the cryptographic operation.</param>
    /// <param name="derivationIterations">The number of iterations for the operation.</param>
    /// <param name="cipherMode">The block cipher mode to use for encryption.</param>
    /// <param name="paddingMode">The type of padding to apply when the message data block is shorter than the full number of bytes needed for a cryptographic operation.</param>
    void Configure(EncryptionMethod encryptionMethod, int keySize, int blockSize, int derivationIterations, CipherMode cipherMode, PaddingMode paddingMode);

    /// <summary>
    /// Encrypts a string using the algorithm defined in <see cref="EncryptionMethod"/>.
    /// </summary>
    /// <param name="input">The UTF-16 string to encrypt.</param>
    /// <param name="key">The secret key to use for the symmetric algorithm.</param>
    /// <param name="salt">The salt value to use for the symmetric algorithm. If omitted, a unique salt is generated and appended to the output.</param>
    /// <returns>A string encrypted using the algorithm defined in <see cref="EncryptionMethod"/> with the option values defined in <see cref="EncryptionOptions"/>.</returns>
    /// <exception cref="InvalidEnumArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    string? EncryptString(string input, string key, string? salt = null);

    /// <summary>
    /// Decrypts a string using the algorithm defined in <see cref="EncryptionMethod"/>.
    /// </summary>
    /// <param name="input">The UTF-16 string to decrypt.</param>
    /// <param name="key">The secret key to use for the symmetric algorithm.</param>
    /// <param name="salt">The salt value to use for the symmetric algorithm. If omitted, the salt is extracted from the input.</param>
    /// <returns>A string decrypted using the algorithm defined in <see cref="EncryptionMethod"/> with the option values defined in <see cref="EncryptionOptions"/>.</returns>
    /// <exception cref="InvalidEnumArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    string? DecryptString(string input, string key, string? salt = null);
}
