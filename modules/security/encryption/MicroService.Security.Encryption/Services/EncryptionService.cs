using MicroService.Security.Encryption.Enums;
using MicroService.Security.Encryption.Interfaces;
using MicroService.Security.Encryption.Models;
using System.ComponentModel;
using System.Security.Cryptography;

namespace MicroService.Security.Encryption.Services;

/// <inheritdoc cref="IEncryptionService" />
public class EncryptionService : IEncryptionService
{

    #region Constructor

    /// <inheritdoc cref="EncryptionService" />
    public EncryptionService() { }

    /// <inheritdoc cref="EncryptionService" />
    /// <param name="encryptionMethod">The type of symmetric algorithm to use.</param>
    public EncryptionService(EncryptionMethod encryptionMethod)
    {
        Configure(encryptionMethod);
    }

    /// <inheritdoc cref="EncryptionService" />
    /// <param name="encryptionMethod">The type of symmetric algorithm to use.</param>
    /// <param name="encryptionOptions">The values to use to set symmetric algorithm options.</param>
    public EncryptionService(EncryptionMethod encryptionMethod, SymmetricAlgorithmOptions? encryptionOptions)
    {
        Configure(encryptionMethod, encryptionOptions);
    }

    /// <inheritdoc cref="EncryptionService" />
    /// <param name="encryptionMethod">The type of symmetric algorithm to use.</param>
    /// <param name="keySize">The size, in bits, of the secret key used for the cryptographic operation.</param>
    /// <param name="blockSize">The block size, in bits, of the cryptographic operation.</param>
    /// <param name="derivationIterations">The number of iterations for the operation.</param>
    /// <param name="cipherMode">The block cipher mode to use for encryption.</param>
    /// <param name="paddingMode">The type of padding to apply when the message data block is shorter than the full number of bytes needed for a cryptographic operation.</param>
    public EncryptionService(EncryptionMethod encryptionMethod, int keySize, int blockSize, int derivationIterations, CipherMode cipherMode, PaddingMode paddingMode)
    {
        Configure(encryptionMethod, keySize, blockSize, derivationIterations, cipherMode, paddingMode);
    }

    #endregion

    #region Properties

    /// <summary>
    /// The type of symmetric algorithm to use.
    /// </summary>
    public EncryptionMethod EncryptionMethod { get; private set; }

    /// <summary>
    /// The values to use to set symmetric algorithm options.
    /// </summary>
    public SymmetricAlgorithmOptions EncryptionOptions { get; private set; } = null!;

    #endregion

    #region Public Methods

    /// <inheritdoc />
    public void Configure(EncryptionMethod encryptionMethod)
    {
        EncryptionMethod = encryptionMethod;
        EncryptionOptions = encryptionMethod switch
        {
            EncryptionMethod.AES => AesOptions.Default,
            EncryptionMethod.DES => DesOptions.Default,
            EncryptionMethod.RC2 => Rc2Options.Default,
            EncryptionMethod.TripleDES => TripleDesOptions.Default,
            _
            => null!
        };
    }

    /// <inheritdoc />
    public void Configure(EncryptionMethod encryptionMethod, SymmetricAlgorithmOptions? encryptionOptions)
    {
        EncryptionMethod = encryptionMethod;
        EncryptionOptions = encryptionOptions ?? encryptionMethod switch
        {
            EncryptionMethod.AES => AesOptions.Default,
            EncryptionMethod.DES => DesOptions.Default,
            EncryptionMethod.RC2 => Rc2Options.Default,
            EncryptionMethod.TripleDES => TripleDesOptions.Default,
            _
            => null!
        };
    }

    /// <inheritdoc />
    public void Configure(EncryptionMethod encryptionMethod, int keySize, int blockSize, int derivationIterations, CipherMode cipherMode, PaddingMode paddingMode)
    {
        EncryptionMethod = encryptionMethod;
        EncryptionOptions = new SymmetricAlgorithmOptions(keySize, blockSize, derivationIterations, cipherMode, paddingMode);
    }

    /// <inheritdoc />
    public virtual string? EncryptString(string input, string key, string? salt = null)
    {
        if (EncryptionMethod == EncryptionMethod.NotSet)
        {
            throw new InvalidEnumArgumentException(nameof(EncryptionMethod), (int)EncryptionMethod.NotSet, typeof(EncryptionMethod));
        }

        ArgumentNullException.ThrowIfNull(EncryptionOptions);

        return Utility.SymmetricAlgorithm.EncryptString(input, key, salt, EncryptionMethod, EncryptionOptions);
    }

    /// <inheritdoc />
    public virtual string? DecryptString(string input, string key, string? salt = null)
    {
        if (EncryptionMethod == EncryptionMethod.NotSet)
        {
            throw new InvalidEnumArgumentException(nameof(EncryptionMethod), (int)EncryptionMethod.NotSet, typeof(EncryptionMethod));
        }

        ArgumentNullException.ThrowIfNull(EncryptionOptions);

        return Utility.SymmetricAlgorithm.DecryptString(input, key, salt, EncryptionMethod, EncryptionOptions);
    }

    #endregion

}
