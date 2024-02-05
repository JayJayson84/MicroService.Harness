using MicroService.Security.Encryption.Interfaces;
using MicroService.Security.Encryption.Models;
using System.Security.Cryptography;

namespace MicroService.Security.Encryption.Services;

/// <inheritdoc cref="IEncryptionService{TSymmetricAlgorithm}" />
public class EncryptionService<TSymmetricAlgorithm> : IEncryptionService<TSymmetricAlgorithm> where TSymmetricAlgorithm : SymmetricAlgorithm
{

    #region Constructor

    /// <inheritdoc cref="EncryptionService{TSymmetricAlgorithm}" />
    public EncryptionService()
    {
        Configure();
    }

    /// <inheritdoc cref="EncryptionService{TSymmetricAlgorithm}" />
    /// <param name="encryptionOptions">The values to use to set symmetric algorithm options.</param>
    public EncryptionService(SymmetricAlgorithmOptions? encryptionOptions)
    {
        Configure(encryptionOptions);
    }

    /// <inheritdoc cref="EncryptionService{TSymmetricAlgorithm}" />
    /// <param name="keySize">The size, in bits, of the secret key used for the cryptographic operation.</param>
    /// <param name="blockSize">The block size, in bits, of the cryptographic operation.</param>
    /// <param name="derivationIterations">The number of iterations for the operation.</param>
    /// <param name="cipherMode">The block cipher mode to use for encryption.</param>
    /// <param name="paddingMode">The type of padding to apply when the message data block is shorter than the full number of bytes needed for a cryptographic operation.</param>
    public EncryptionService(int keySize, int blockSize, int derivationIterations, CipherMode cipherMode, PaddingMode paddingMode)
    {
        Configure(keySize, blockSize, derivationIterations, cipherMode, paddingMode);
    }

    #endregion

    #region Properties

    /// <summary>
    /// The values to use to set symmetric algorithm options.
    /// </summary>
    public SymmetricAlgorithmOptions EncryptionOptions { get; private set; } = null!;

    #endregion

    #region Public Methods

    /// <inheritdoc />
    public void Configure(SymmetricAlgorithmOptions? encryptionOptions = null)
    {
        EncryptionOptions = encryptionOptions ?? typeof(TSymmetricAlgorithm).Name switch
        {
            "Aes" => AesOptions.Default,
            "DES" => DesOptions.Default,
            "RC2" => Rc2Options.Default,
            "TripleDES" => TripleDesOptions.Default,
            _
            => null!
        };
    }

    /// <inheritdoc />
    public void Configure(int keySize, int blockSize, int derivationIterations, CipherMode cipherMode, PaddingMode paddingMode)
    {
        EncryptionOptions = new SymmetricAlgorithmOptions(keySize, blockSize, derivationIterations, cipherMode, paddingMode);
    }

    /// <inheritdoc />
    public virtual string? EncryptString(string input, string key, string? salt = null)
    {
        ArgumentNullException.ThrowIfNull(EncryptionOptions);

        return Utility.SymmetricAlgorithm.EncryptString<TSymmetricAlgorithm>(input, key, salt, EncryptionOptions);
    }

    /// <inheritdoc />
    public virtual string? DecryptString(string input, string key, string? salt = null)
    {
        ArgumentNullException.ThrowIfNull(EncryptionOptions);

        return Utility.SymmetricAlgorithm.DecryptString<TSymmetricAlgorithm>(input, key, salt, EncryptionOptions);
    }

    #endregion

}
