using System.Security.Cryptography;

namespace MicroService.Security.Encryption.Contracts;

/// <summary>
/// Provides values to use to set symmetric algorithm options.
/// </summary>
public record EncryptionOptions
{
    /// <summary>
    /// Gets or sets the size, in bits, of the secret key used for the cryptographic operation.
    /// </summary>
    public int? KeySize { get; set; }

    /// <summary>
    /// Gets or sets the block size, in bits, of the cryptographic operation.
    /// </summary>
    public int? BlockSize { get; set; }

    /// <summary>
    /// Gets or sets the number of iterations for the operation.
    /// </summary>
    public int? DerivationIterations { get; set; }

    /// <summary>
    /// Gets or sets the block cipher mode to use for encryption.
    /// </summary>
    public CipherMode? CipherMode { get; set; }

    /// <summary>
    /// Gets or sets the type of padding to apply when the message data block is shorter than the full number of bytes needed for a cryptographic operation.
    /// </summary>
    public PaddingMode? PaddingMode { get; set; }
}
