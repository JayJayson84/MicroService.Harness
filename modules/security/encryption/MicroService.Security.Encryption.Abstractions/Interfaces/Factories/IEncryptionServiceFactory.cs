using System.Security.Cryptography;
using MicroService.Security.Encryption.Enums;
using MicroService.Security.Encryption.Models;

namespace MicroService.Security.Encryption.Interfaces;

/// <summary>
/// Provides a managed implementation for encrypting and decrypting with a cryptographic symmetric algorithm.
/// </summary>
public interface IEncryptionServiceFactory
{
    /// <inheritdoc cref="IEncryptionServiceFactory" />
    /// <param name="encryptionMethod">The type of symmetric algorithm to use.</param>
    public IEncryptionService? CreateService(EncryptionMethod encryptionMethod);

    /// <inheritdoc cref="IEncryptionServiceFactory" />
    /// <param name="encryptionMethod">The type of symmetric algorithm to use.</param>
    /// <param name="encryptionOptions">The values to use to set symmetric algorithm options.</param>
    public IEncryptionService? CreateService(EncryptionMethod encryptionMethod, SymmetricAlgorithmOptions? encryptionOptions);

    /// <inheritdoc cref="IEncryptionServiceFactory" />
    /// <param name="encryptionMethod">The type of symmetric algorithm to use.</param>
    /// <param name="keySize">The size, in bits, of the secret key used for the cryptographic operation.</param>
    /// <param name="blockSize">The block size, in bits, of the cryptographic operation.</param>
    /// <param name="derivationIterations">The number of iterations for the operation.</param>
    /// <param name="cipherMode">The block cipher mode to use for encryption.</param>
    /// <param name="paddingMode">The type of padding to apply when the message data block is shorter than the full number of bytes needed for a cryptographic operation.</param>
    public IEncryptionService? CreateService(EncryptionMethod encryptionMethod, int keySize, int blockSize, int derivationIterations, CipherMode cipherMode, PaddingMode paddingMode);

    /// <inheritdoc cref="IEncryptionServiceFactory" />
    /// <param name="encryptionMethod">The type of symmetric algorithm to use.</param>
    /// <remarks>(Resolves the service from the service provider)</remarks>
    public IEncryptionService? GetService(EncryptionMethod encryptionMethod);

    /// <inheritdoc cref="IEncryptionServiceFactory" />
    /// <param name="encryptionMethod">The type of symmetric algorithm to use.</param>
    /// <param name="encryptionOptions">The values to use to set symmetric algorithm options.</param>
    /// <remarks>(Resolves the service from the service provider)</remarks>
    public IEncryptionService? GetService(EncryptionMethod encryptionMethod, SymmetricAlgorithmOptions? encryptionOptions);

    /// <inheritdoc cref="IEncryptionServiceFactory" />
    /// <param name="encryptionMethod">The type of symmetric algorithm to use.</param>
    /// <param name="keySize">The size, in bits, of the secret key used for the cryptographic operation.</param>
    /// <param name="blockSize">The block size, in bits, of the cryptographic operation.</param>
    /// <param name="derivationIterations">The number of iterations for the operation.</param>
    /// <param name="cipherMode">The block cipher mode to use for encryption.</param>
    /// <param name="paddingMode">The type of padding to apply when the message data block is shorter than the full number of bytes needed for a cryptographic operation.</param>
    /// <remarks>(Resolves the service from the service provider)</remarks>
    public IEncryptionService? GetService(EncryptionMethod encryptionMethod, int keySize, int blockSize, int derivationIterations, CipherMode cipherMode, PaddingMode paddingMode);
}
