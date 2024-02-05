using System.Security.Cryptography;

namespace MicroService.Security.Encryption.Models;

/// <summary>
/// Provides values to use to set options for the cryptographic service provider (CSP) version of the TripleDES algorithm.
/// </summary>
public sealed class TripleDesOptions : SymmetricAlgorithmOptions
{

    #region Constants

    public const int DEFAULT_KEY_SIZE = 192;
    public const int DEFAULT_BLOCK_SIZE = 64;
    public const int DEFAULT_DERIVATION_ITERATIONS = 5000;
    public const CipherMode DEFAULT_CIPHER_MODE = CipherMode.CBC;
    public const PaddingMode DEFAULT_PADDING_MODE = PaddingMode.PKCS7;

    #endregion

    #region Properties

    public override int KeySize { get; set; } = DEFAULT_KEY_SIZE;
    public override int BlockSize { get; set; } = DEFAULT_BLOCK_SIZE;
    public override int DerivationIterations { get; set; } = DEFAULT_DERIVATION_ITERATIONS;
    public override CipherMode CipherMode { get; set; } = DEFAULT_CIPHER_MODE;
    public override PaddingMode PaddingMode { get; set; } = DEFAULT_PADDING_MODE;

    #endregion

    #region Constructor

    /// <summary>
    /// Provides values to use to set options for the cryptographic service provider (CSP) version of the TripleDES algorithm.
    /// </summary>
    public TripleDesOptions() { }

    /// <summary>
    /// Provides values to use to set options for the cryptographic service provider (CSP) version of the TripleDES algorithm.
    /// </summary>
    /// <param name="keySize">The size, in bits, of the secret key used for the cryptographic operation.</param>
    /// <param name="blockSize">The block size, in bits, of the cryptographic operation.</param>
    /// <param name="derivationIterations">The number of iterations for the operation.</param>
    /// <param name="cipherMode">The block cipher mode to use for encryption.</param>
    /// <param name="paddingMode">The type of padding to apply when the message data block is shorter than the full number of bytes needed for a cryptographic operation.</param>
    public TripleDesOptions(int keySize, int blockSize, int derivationIterations, CipherMode cipherMode, PaddingMode paddingMode)
    {
        KeySize = keySize;
        BlockSize = blockSize;
        DerivationIterations = derivationIterations;
        CipherMode = cipherMode;
        PaddingMode = paddingMode;
    }

    #endregion

    #region Static Members

    /// <summary>
    /// Provides a copy of the TripleDesOptions with default values.
    /// </summary>
    public static TripleDesOptions Default => new();

    #endregion

}
