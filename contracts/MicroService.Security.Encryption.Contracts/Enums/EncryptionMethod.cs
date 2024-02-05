namespace MicroService.Security.Encryption.Contracts;

/// <summary>
/// Specifies identifiers to indicate the type of symmetric algorithm to use when encrypting and decrypting.
/// </summary>
public enum EncryptionMethod
{
    /// <summary>
    /// Indicates the managed version of the Advanced Encryption Standard (AES) should be used.
    /// </summary>
    AES = 1,
    /// <summary>
    /// Indicates the cryptographic service provider (CSP) version of the Data Encryption Standard (DES) should be used.
    /// </summary>
    DES,
    /// <summary>
    /// Indicates the cryptographic service provider (CSP) version of the RC2 algorithm should be used.
    /// </summary>
    RC2,
    /// <summary>
    /// Indicates the cryptographic service provider (CSP) version of the TripleDES algorithm should be used.
    /// </summary>
    TripleDES
}
