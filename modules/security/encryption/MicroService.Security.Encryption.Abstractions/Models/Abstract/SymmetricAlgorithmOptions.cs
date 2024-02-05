using System.Security.Cryptography;

namespace MicroService.Security.Encryption.Models;

/// <summary>
/// Provides values to use to set symmetric algorithm options.
/// </summary>
public class SymmetricAlgorithmOptions
{

    #region Properties

    /// <summary>
    /// Gets or sets the size, in bits, of the secret key used for the cryptographic operation.
    /// </summary>
    public virtual int KeySize { get; set; }

    /// <summary>
    /// Gets or sets the block size, in bits, of the cryptographic operation.
    /// </summary>
    public virtual int BlockSize { get; set; }

    /// <summary>
    /// Gets or sets the number of iterations for the operation.
    /// </summary>
    public virtual int DerivationIterations { get; set; }

    /// <summary>
    /// Gets or sets the block cipher mode to use for encryption.
    /// </summary>
    public virtual CipherMode CipherMode { get; set; }

    /// <summary>
    /// Gets or sets the type of padding to apply when the message data block is shorter than the full number of bytes needed for a cryptographic operation.
    /// </summary>
    public virtual PaddingMode PaddingMode { get; set; }

    #endregion

    #region Constructor

    /// <summary>
    /// Provides values to use to set symmetric algorithm options.
    /// </summary>
    public SymmetricAlgorithmOptions() { }

    /// <summary>
    /// Provides values to use to set symmetric algorithm options.
    /// </summary>
    /// <param name="keySize">The size, in bits, of the secret key used for the cryptographic operation.</param>
    /// <param name="blockSize">The block size, in bits, of the cryptographic operation.</param>
    /// <param name="derivationIterations">The number of iterations for the operation.</param>
    /// <param name="cipherMode">The block cipher mode to use for encryption.</param>
    /// <param name="paddingMode">The type of padding to apply when the message data block is shorter than the full number of bytes needed for a cryptographic operation.</param>
    public SymmetricAlgorithmOptions(int keySize, int blockSize, int derivationIterations, CipherMode cipherMode, PaddingMode paddingMode)
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
    /// Provides a copy of the SymmetricAlgorithmOptions with empty values.
    /// </summary>
    public static SymmetricAlgorithmOptions Empty => new();

    #endregion

}
