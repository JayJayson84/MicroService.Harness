namespace MicroService.Security.Encryption.Contracts;

/// <summary>
/// Specifies identifiers to indicate the type of encryption operation to use.
/// </summary>
public enum EncryptionOperation
{
    /// <summary>
    /// Indicates the crypto operation should encrypt the input.
    /// </summary>
    Encrypt,
    /// <summary>
    /// Indicates the crypto operation should decrypt the input.
    /// </summary>
    Decrypt
}
