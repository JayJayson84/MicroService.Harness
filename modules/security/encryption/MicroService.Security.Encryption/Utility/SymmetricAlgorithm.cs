using MicroService.Security.Encryption.Enums;
using MicroService.Security.Encryption.Extensions;
using MicroService.Security.Encryption.Models;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace MicroService.Security.Encryption.Utility;

/// <summary>
/// Provides a managed utility wrapper for encrypting and decrypting with a cryptographic symmetric algorithm.
/// </summary>
/// <remarks>Supported algorithms: <see cref="Aes"/>, <see cref="DES"/>, <see cref="RC2"/>, <see cref="TripleDES"/>.</remarks>
public static class SymmetricAlgorithm
{

    /// <summary>
    /// Encrypts a string using a <see cref="System.Security.Cryptography.SymmetricAlgorithm"/>.
    /// </summary>
    /// <param name="input">The UTF-16 string to encrypt.</param>
    /// <param name="key">The secret key to use for the symmetric algorithm.</param>
    /// <param name="encryptionMethod">The type of symmetric algorithm to use.</param>
    /// <returns>A string encrypted using the algorithm specified by <paramref name="encryptionMethod"/>.</returns>
    public static string? EncryptString(string input, string key, EncryptionMethod encryptionMethod)
    {
        return EncryptString(input, key, null, encryptionMethod);
    }

    /// <summary>
    /// Encrypts a string using a <see cref="System.Security.Cryptography.SymmetricAlgorithm"/>.
    /// </summary>
    /// <param name="input">The UTF-16 string to encrypt.</param>
    /// <param name="key">The secret key to use for the symmetric algorithm.</param>
    /// <param name="salt">The salt value to use for the symmetric algorithm. If omitted, a unique salt is generated and appended to the output.</param>
    /// <param name="encryptionMethod">The type of symmetric algorithm to use.</param>
    /// <returns>A string encrypted using the algorithm specified by <paramref name="encryptionMethod"/>.</returns>
    /// <exception cref="ArgumentException"></exception>
    public static string? EncryptString(string input, string key, string? salt, EncryptionMethod encryptionMethod)
    {
        return encryptionMethod switch
        {
            EncryptionMethod.AES => EncryptString<Aes, AesOptions>(input, key, salt),
            EncryptionMethod.DES => EncryptString<DES, DesOptions>(input, key, salt),
            EncryptionMethod.RC2 => EncryptString<RC2, Rc2Options>(input, key, salt),
            EncryptionMethod.TripleDES => EncryptString<TripleDES, TripleDesOptions>(input, key, salt),
            _ => throw new ArgumentException("An invalid argument value was passed to a method and could not be handled.", nameof(encryptionMethod))
        };
    }

    /// <summary>
    /// Encrypts a string using a <see cref="System.Security.Cryptography.SymmetricAlgorithm"/>.
    /// </summary>
    /// <param name="input">The UTF-16 string to encrypt.</param>
    /// <param name="key">The secret key to use for the symmetric algorithm.</param>
    /// <param name="encryptionMethod">The type of symmetric algorithm to use.</param>
    /// <param name="keySize">The size, in bits, of the secret key used for the cryptographic operation.</param>
    /// <param name="blockSize">The block size, in bits, of the cryptographic operation.</param>
    /// <param name="derivationIterations">The number of iterations for the operation.</param>
    /// <param name="cipherMode">The block cipher mode to use for encryption.</param>
    /// <param name="paddingMode">The type of padding to apply when the message data block is shorter than the full number of bytes needed for a cryptographic operation.</param>
    /// <returns>A string encrypted using the algorithm specified by <paramref name="encryptionMethod"/>.</returns>
    public static string? EncryptString(string input, string key, EncryptionMethod encryptionMethod, int keySize, int blockSize, int derivationIterations, CipherMode cipherMode, PaddingMode paddingMode)
    {
        return EncryptString(input, key, null, encryptionMethod, keySize, blockSize, derivationIterations, cipherMode, paddingMode);
    }

    /// <summary>
    /// Encrypts a string using a <see cref="System.Security.Cryptography.SymmetricAlgorithm"/>.
    /// </summary>
    /// <param name="input">The UTF-16 string to encrypt.</param>
    /// <param name="key">The secret key to use for the symmetric algorithm.</param>
    /// <param name="salt">The salt value to use for the symmetric algorithm. If omitted, a unique salt is generated and appended to the output.</param>
    /// <param name="encryptionMethod">The type of symmetric algorithm to use.</param>
    /// <param name="keySize">The size, in bits, of the secret key used for the cryptographic operation.</param>
    /// <param name="blockSize">The block size, in bits, of the cryptographic operation.</param>
    /// <param name="derivationIterations">The number of iterations for the operation.</param>
    /// <param name="cipherMode">The block cipher mode to use for encryption.</param>
    /// <param name="paddingMode">The type of padding to apply when the message data block is shorter than the full number of bytes needed for a cryptographic operation.</param>
    /// <returns>A string encrypted using the algorithm specified by <paramref name="encryptionMethod"/>.</returns>
    public static string? EncryptString(string input, string key, string? salt, EncryptionMethod encryptionMethod, int keySize, int blockSize, int derivationIterations, CipherMode cipherMode, PaddingMode paddingMode)
    {
        var encryptionOptions = new SymmetricAlgorithmOptions
        {
            KeySize = keySize,
            BlockSize = blockSize,
            DerivationIterations = derivationIterations,
            CipherMode = cipherMode,
            PaddingMode = paddingMode
        };

        return EncryptString(input, key, salt, encryptionMethod, encryptionOptions);
    }

    /// <summary>
    /// Encrypts a string using a <see cref="System.Security.Cryptography.SymmetricAlgorithm"/>.
    /// </summary>
    /// <param name="input">The UTF-16 string to encrypt.</param>
    /// <param name="key">The secret key to use for the symmetric algorithm.</param>
    /// <param name="encryptionMethod">The type of symmetric algorithm to use.</param>
    /// <param name="encryptionOptions">The values to use to set symmetric algorithm options.</param>
    /// <returns>A string encrypted using the algorithm specified by <paramref name="encryptionMethod"/>.</returns>
    public static string? EncryptString(string input, string key, EncryptionMethod encryptionMethod, SymmetricAlgorithmOptions encryptionOptions)
    {
        return EncryptString(input, key, null, encryptionMethod, encryptionOptions);
    }

    /// <summary>
    /// Encrypts a string using a <see cref="System.Security.Cryptography.SymmetricAlgorithm"/>.
    /// </summary>
    /// <param name="input">The UTF-16 string to encrypt.</param>
    /// <param name="key">The secret key to use for the symmetric algorithm.</param>
    /// <param name="salt">The salt value to use for the symmetric algorithm. If omitted, a unique salt is generated and appended to the output.</param>
    /// <param name="encryptionMethod">The type of symmetric algorithm to use.</param>
    /// <param name="encryptionOptions">The values to use to set symmetric algorithm options.</param>
    /// <returns>A string encrypted using the algorithm specified by <paramref name="encryptionMethod"/>.</returns>
    /// <exception cref="ArgumentException"></exception>
    public static string? EncryptString(string input, string key, string? salt, EncryptionMethod encryptionMethod, SymmetricAlgorithmOptions encryptionOptions)
    {
        return encryptionMethod switch
        {
            EncryptionMethod.AES => EncryptString<Aes>(input, key, salt, encryptionOptions),
            EncryptionMethod.DES => EncryptString<DES>(input, key, salt, encryptionOptions),
            EncryptionMethod.RC2 => EncryptString<RC2>(input, key, salt, encryptionOptions),
            EncryptionMethod.TripleDES => EncryptString<TripleDES>(input, key, salt, encryptionOptions),
            _ => throw new ArgumentException("An invalid argument value was passed to a method and could not be handled.", nameof(encryptionMethod))
        };
    }

    /// <summary>
    /// Encrypts a string using a <see cref="System.Security.Cryptography.SymmetricAlgorithm"/>.
    /// </summary>
    /// <typeparam name="T">A symmetric algorithm.</typeparam>
    /// <typeparam name="TOptions">The values to use to set symmetric algorithm options.</typeparam>
    /// <param name="input">The UTF-16 string to encrypt.</param>
    /// <param name="key">The secret key to use for the symmetric algorithm.</param>
    /// <param name="salt">The salt value to use for the symmetric algorithm. If omitted, a unique salt is generated and appended to the output.</param>
    /// <returns>A string encrypted using the algorithm specified by <typeparamref name="T"/> with the default option values defined in <typeparamref name="TOptions"/>.</returns>
    /// <remarks>Supported algorithms: <see cref="Aes"/>, <see cref="DES"/>, <see cref="RC2"/>, <see cref="TripleDES"/>.</remarks>
    public static string? EncryptString<T, TOptions>(string input, string key, string? salt = null) where T : System.Security.Cryptography.SymmetricAlgorithm where TOptions : SymmetricAlgorithmOptions, new()
    {
        var options = new TOptions();

        return EncryptString<T>(input, key, salt, options.KeySize, options.BlockSize, options.DerivationIterations, options.CipherMode, options.PaddingMode);
    }

    /// <summary>
    /// Encrypts a string using a <see cref="System.Security.Cryptography.SymmetricAlgorithm"/>.
    /// </summary>
    /// <typeparam name="T">A symmetric algorithm.</typeparam>
    /// <param name="input">The UTF-16 string to encrypt.</param>
    /// <param name="key">The secret key to use for the symmetric algorithm.</param>
    /// <param name="encryptionOptions">The values to use to set symmetric algorithm options.</param>
    /// <returns>A string encrypted using the algorithm specified by <typeparamref name="T"/>.</returns>
    /// <remarks>Supported algorithms: <see cref="Aes"/>, <see cref="DES"/>, <see cref="RC2"/>, <see cref="TripleDES"/>.</remarks>
    public static string? EncryptString<T>(string input, string key, SymmetricAlgorithmOptions encryptionOptions) where T : System.Security.Cryptography.SymmetricAlgorithm
    {
        return EncryptString<T>(input, key, null, encryptionOptions.KeySize, encryptionOptions.BlockSize, encryptionOptions.DerivationIterations, encryptionOptions.CipherMode, encryptionOptions.PaddingMode);
    }

    /// <summary>
    /// Encrypts a string using a <see cref="System.Security.Cryptography.SymmetricAlgorithm"/>.
    /// </summary>
    /// <typeparam name="T">A symmetric algorithm.</typeparam>
    /// <param name="input">The UTF-16 string to encrypt.</param>
    /// <param name="key">The secret key to use for the symmetric algorithm.</param>
    /// <param name="salt">The salt value to use for the symmetric algorithm. If omitted, a unique salt is generated and appended to the output.</param>
    /// <param name="encryptionOptions">The values to use to set symmetric algorithm options.</param>
    /// <returns>A string encrypted using the algorithm specified by <typeparamref name="T"/>.</returns>
    /// <remarks>Supported algorithms: <see cref="Aes"/>, <see cref="DES"/>, <see cref="RC2"/>, <see cref="TripleDES"/>.</remarks>
    public static string? EncryptString<T>(string input, string key, string? salt, SymmetricAlgorithmOptions encryptionOptions) where T : System.Security.Cryptography.SymmetricAlgorithm
    {
        return EncryptString<T>(input, key, salt, encryptionOptions.KeySize, encryptionOptions.BlockSize, encryptionOptions.DerivationIterations, encryptionOptions.CipherMode, encryptionOptions.PaddingMode);
    }

    /// <summary>
    /// Encrypts a string using a <see cref="System.Security.Cryptography.SymmetricAlgorithm"/>.
    /// </summary>
    /// <typeparam name="T">A symmetric algorithm.</typeparam>
    /// <param name="input">The UTF-16 string to encrypt.</param>
    /// <param name="key">The secret key to use for the symmetric algorithm.</param>
    /// <param name="salt">The salt value to use for the symmetric algorithm. If omitted, a unique salt is generated and appended to the output.</param>
    /// <param name="keySize">The size, in bits, of the secret key used for the cryptographic operation.</param>
    /// <param name="blockSize">The block size, in bits, of the cryptographic operation.</param>
    /// <param name="derivationIterations">The number of iterations for the operation.</param>
    /// <param name="cipherMode">The block cipher mode to use for encryption.</param>
    /// <param name="paddingMode">The type of padding to apply when the message data block is shorter than the full number of bytes needed for a cryptographic operation.</param>
    /// <returns>A string encrypted using the algorithm specified by <typeparamref name="T"/>.</returns>
    /// <remarks>Supported algorithms: <see cref="Aes"/>, <see cref="DES"/>, <see cref="RC2"/>, <see cref="TripleDES"/>.</remarks>
    public static string? EncryptString<T>(string input, string key, string? salt, int keySize, int blockSize, int derivationIterations, CipherMode cipherMode, PaddingMode paddingMode) where T : System.Security.Cryptography.SymmetricAlgorithm
    {
        if (typeof(T).GetMethod(nameof(System.Security.Cryptography.SymmetricAlgorithm.Create), Type.EmptyTypes) is not MethodInfo methodInfo) return null;
        if (methodInfo.Invoke(null, []) is not object methodInvoked) return null;

        var keyByteSize = keySize / 8;
        var blockByteSize = blockSize / 8;
        var saltBytes = salt.HasValue()
            ? Hash.ConvertToSHA256Bytes(salt, keyByteSize)
            : Byte.GenerateBitsOfRandomEntropy(blockByteSize);
        var ivBytes = Byte.GenerateBitsOfRandomEntropy(blockByteSize);
        var inputBytes = Encoding.UTF8.GetBytes(input);

        using var password = new Rfc2898DeriveBytes(key, saltBytes, derivationIterations, HashAlgorithmName.SHA256);

        var keyBytes = password.GetBytes(keyByteSize);

        using T symmetricKey = (T)methodInvoked;
        symmetricKey.BlockSize = blockSize;
        symmetricKey.Mode = cipherMode;
        symmetricKey.Padding = paddingMode;

        using var encryptor = symmetricKey.CreateEncryptor(keyBytes, ivBytes);
        using var memoryStream = new MemoryStream();
        using var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);

        cryptoStream.Write(inputBytes, 0, inputBytes.Length);
        cryptoStream.FlushFinalBlock();

        var cipherTextBytes = string.IsNullOrWhiteSpace(salt)
            ? saltBytes
            : [];
        cipherTextBytes = cipherTextBytes.Concat(ivBytes).ToArray();
        cipherTextBytes = cipherTextBytes.Concat(memoryStream.ToArray()).ToArray();

        return cipherTextBytes.ToBase64String();
    }

    /// <summary>
    /// Decrypts a string using a <see cref="System.Security.Cryptography.SymmetricAlgorithm"/>.
    /// </summary>
    /// <param name="input">The UTF-16 string to decrypt.</param>
    /// <param name="key">The secret key to use for the symmetric algorithm.</param>
    /// <param name="encryptionMethod">The type of symmetric algorithm to use.</param>
    /// <returns>A string decrypted using the algorithm specified by <paramref name="encryptionMethod"/>.</returns>
    public static string? DecryptString(string input, string key, EncryptionMethod encryptionMethod)
    {
        return DecryptString(input, key, null, encryptionMethod);
    }

    /// <summary>
    /// Decrypts a string using a <see cref="System.Security.Cryptography.SymmetricAlgorithm"/>.
    /// </summary>
    /// <param name="input">The UTF-16 string to decrypt.</param>
    /// <param name="key">The secret key to use for the symmetric algorithm.</param>
    /// <param name="salt">The salt value to use for the symmetric algorithm. If omitted, the salt is extracted from the input.</param>
    /// <param name="encryptionMethod">The type of symmetric algorithm to use.</param>
    /// <returns>A string decrypted using the algorithm specified by <paramref name="encryptionMethod"/>.</returns>
    /// <exception cref="ArgumentException"></exception>
    public static string? DecryptString(string input, string key, string? salt, EncryptionMethod encryptionMethod)
    {
        return encryptionMethod switch
        {
            EncryptionMethod.AES => DecryptString<Aes, AesOptions>(input, key, salt),
            EncryptionMethod.DES => DecryptString<DES, DesOptions>(input, key, salt),
            EncryptionMethod.RC2 => DecryptString<RC2, Rc2Options>(input, key, salt),
            EncryptionMethod.TripleDES => DecryptString<TripleDES, TripleDesOptions>(input, key, salt),
            _ => throw new ArgumentException("An invalid argument value was passed to a method and could not be handled.", nameof(encryptionMethod))
        };
    }

    /// <summary>
    /// Decrypts a string using a <see cref="System.Security.Cryptography.SymmetricAlgorithm"/>.
    /// </summary>
    /// <param name="input">The UTF-16 string to decrypt.</param>
    /// <param name="key">The secret key to use for the symmetric algorithm.</param>
    /// <param name="encryptionMethod">The type of symmetric algorithm to use.</param>
    /// <param name="keySize">The size, in bits, of the secret key used for the cryptographic operation.</param>
    /// <param name="blockSize">The block size, in bits, of the cryptographic operation.</param>
    /// <param name="derivationIterations">The number of iterations for the operation.</param>
    /// <param name="cipherMode">The block cipher mode to use for decryption.</param>
    /// <param name="paddingMode">The type of padding to apply when the message data block is shorter than the full number of bytes needed for a cryptographic operation.</param>
    /// <returns>A string decrypted using the algorithm specified by <paramref name="encryptionMethod"/>.</returns>
    public static string? DecryptString(string input, string key, EncryptionMethod encryptionMethod, int keySize, int blockSize, int derivationIterations, CipherMode cipherMode, PaddingMode paddingMode)
    {
        return DecryptString(input, key, null, encryptionMethod, keySize, blockSize, derivationIterations, cipherMode, paddingMode);
    }

    /// <summary>
    /// Decrypts a string using a <see cref="System.Security.Cryptography.SymmetricAlgorithm"/>.
    /// </summary>
    /// <param name="input">The UTF-16 string to decrypt.</param>
    /// <param name="key">The secret key to use for the symmetric algorithm.</param>
    /// <param name="salt">The salt value to use for the symmetric algorithm. If omitted, the salt is extracted from the input.</param>
    /// <param name="encryptionMethod">The type of symmetric algorithm to use.</param>
    /// <param name="keySize">The size, in bits, of the secret key used for the cryptographic operation.</param>
    /// <param name="blockSize">The block size, in bits, of the cryptographic operation.</param>
    /// <param name="derivationIterations">The number of iterations for the operation.</param>
    /// <param name="cipherMode">The block cipher mode to use for decryption.</param>
    /// <param name="paddingMode">The type of padding to apply when the message data block is shorter than the full number of bytes needed for a cryptographic operation.</param>
    /// <returns>A string decrypted using the algorithm specified by <paramref name="encryptionMethod"/>.</returns>
    public static string? DecryptString(string input, string key, string? salt, EncryptionMethod encryptionMethod, int keySize, int blockSize, int derivationIterations, CipherMode cipherMode, PaddingMode paddingMode)
    {
        var encryptionOptions = new SymmetricAlgorithmOptions
        {
            KeySize = keySize,
            BlockSize = blockSize,
            DerivationIterations = derivationIterations,
            CipherMode = cipherMode,
            PaddingMode = paddingMode
        };

        return DecryptString(input, key, salt, encryptionMethod, encryptionOptions);
    }

    /// <summary>
    /// Decrypts a string using a <see cref="System.Security.Cryptography.SymmetricAlgorithm"/>.
    /// </summary>
    /// <param name="input">The UTF-16 string to decrypt.</param>
    /// <param name="key">The secret key to use for the symmetric algorithm.</param>
    /// <param name="encryptionMethod">The type of symmetric algorithm to use.</param>
    /// <param name="encryptionOptions">The values to use to set symmetric algorithm options.</param>
    /// <returns>A string decrypted using the algorithm specified by <paramref name="encryptionMethod"/>.</returns>
    public static string? DecryptString(string input, string key, EncryptionMethod encryptionMethod, SymmetricAlgorithmOptions encryptionOptions)
    {
        return DecryptString(input, key, null, encryptionMethod, encryptionOptions);
    }

    /// <summary>
    /// Decrypts a string using a <see cref="System.Security.Cryptography.SymmetricAlgorithm"/>.
    /// </summary>
    /// <param name="input">The UTF-16 string to decrypt.</param>
    /// <param name="key">The secret key to use for the symmetric algorithm.</param>
    /// <param name="salt">The salt value to use for the symmetric algorithm. If omitted, the salt is extracted from the input.</param>
    /// <param name="encryptionMethod">The type of symmetric algorithm to use.</param>
    /// <param name="encryptionOptions">The values to use to set symmetric algorithm options.</param>
    /// <returns>A string decrypted using the algorithm specified by <paramref name="encryptionMethod"/>.</returns>
    /// <exception cref="ArgumentException"></exception>
    public static string? DecryptString(string input, string key, string? salt, EncryptionMethod encryptionMethod, SymmetricAlgorithmOptions encryptionOptions)
    {
        return encryptionMethod switch
        {
            EncryptionMethod.AES => DecryptString<Aes>(input, key, salt, encryptionOptions),
            EncryptionMethod.DES => DecryptString<DES>(input, key, salt, encryptionOptions),
            EncryptionMethod.RC2 => DecryptString<RC2>(input, key, salt, encryptionOptions),
            EncryptionMethod.TripleDES => DecryptString<TripleDES>(input, key, salt, encryptionOptions),
            _ => throw new ArgumentException("An invalid argument value was passed to a method and could not be handled.", nameof(encryptionMethod))
        };
    }

    /// <summary>
    /// Decrypts a string using a <see cref="System.Security.Cryptography.SymmetricAlgorithm"/>.
    /// </summary>
    /// <typeparam name="T">A symmetric algorithm.</typeparam>
    /// <typeparam name="TOptions">The values to use to set symmetric algorithm options.</typeparam>
    /// <param name="input">The UTF-16 string to decrypt.</param>
    /// <param name="key">The secret key to use for the symmetric algorithm.</param>
    /// <param name="salt">The salt value to use for the symmetric algorithm. If omitted, the salt is extracted from the input.</param>
    /// <returns>A string decrypted using the algorithm specified by <typeparamref name="T"/> with the default option values defined in <typeparamref name="TOptions"/>.</returns>
    /// <remarks>Supported algorithms: <see cref="Aes"/>, <see cref="DES"/>, <see cref="RC2"/>, <see cref="TripleDES"/>.</remarks>
    public static string? DecryptString<T, TOptions>(string input, string key, string? salt = null) where T : System.Security.Cryptography.SymmetricAlgorithm where TOptions : SymmetricAlgorithmOptions, new()
    {
        var options = new TOptions();

        return DecryptString<T>(input, key, salt, options.KeySize, options.BlockSize, options.DerivationIterations, options.CipherMode, options.PaddingMode);
    }

    /// <summary>
    /// Decrypts a string using a <see cref="System.Security.Cryptography.SymmetricAlgorithm"/>.
    /// </summary>
    /// <typeparam name="T">A symmetric algorithm.</typeparam>
    /// <param name="input">The UTF-16 string to decrypt.</param>
    /// <param name="key">The secret key to use for the symmetric algorithm.</param>
    /// <param name="encryptionOptions">The values to use to set symmetric algorithm options.</param>
    /// <returns>A string decrypted using the algorithm specified by <typeparamref name="T"/>.</returns>
    /// <remarks>Supported algorithms: <see cref="Aes"/>, <see cref="DES"/>, <see cref="RC2"/>, <see cref="TripleDES"/>.</remarks>
    public static string? DecryptString<T>(string input, string key, SymmetricAlgorithmOptions options) where T : System.Security.Cryptography.SymmetricAlgorithm
    {
        return DecryptString<T>(input, key, null, options.KeySize, options.BlockSize, options.DerivationIterations, options.CipherMode, options.PaddingMode);
    }

    /// <summary>
    /// Decrypts a string using a <see cref="System.Security.Cryptography.SymmetricAlgorithm"/>.
    /// </summary>
    /// <typeparam name="T">A symmetric algorithm.</typeparam>
    /// <param name="input">The UTF-16 string to decrypt.</param>
    /// <param name="key">The secret key to use for the symmetric algorithm.</param>
    /// <param name="salt">The salt value to use for the symmetric algorithm. If omitted, the salt is extracted from the input.</param>
    /// <param name="encryptionOptions">The values to use to set symmetric algorithm options.</param>
    /// <returns>A string decrypted using the algorithm specified by <typeparamref name="T"/>.</returns>
    /// <remarks>Supported algorithms: <see cref="Aes"/>, <see cref="DES"/>, <see cref="RC2"/>, <see cref="TripleDES"/>.</remarks>
    public static string? DecryptString<T>(string input, string key, string? salt, SymmetricAlgorithmOptions options) where T : System.Security.Cryptography.SymmetricAlgorithm
    {
        return DecryptString<T>(input, key, salt, options.KeySize, options.BlockSize, options.DerivationIterations, options.CipherMode, options.PaddingMode);
    }

    /// <summary>
    /// Decrypts a string using a <see cref="System.Security.Cryptography.SymmetricAlgorithm"/>.
    /// </summary>
    /// <typeparam name="T">A symmetric algorithm.</typeparam>
    /// <param name="input">The UTF-16 string to decrypt.</param>
    /// <param name="key">The secret key to use for the symmetric algorithm.</param>
    /// <param name="salt">The salt value to use for the symmetric algorithm. If omitted, the salt is extracted from the input.</param>
    /// <param name="keySize">The size, in bits, of the secret key used for the cryptographic operation.</param>
    /// <param name="blockSize">The block size, in bits, of the cryptographic operation.</param>
    /// <param name="derivationIterations">The number of iterations for the operation.</param>
    /// <param name="cipherMode">The block cipher mode to use for decryption.</param>
    /// <param name="paddingMode">The type of padding to apply when the message data block is shorter than the full number of bytes needed for a cryptographic operation.</param>
    /// <returns>A string decrypted using the algorithm specified by <typeparamref name="T"/>.</returns>
    /// <remarks>Supported algorithms: <see cref="AesManaged"/>, <see cref="DESCryptoServiceProvider"/>, <see cref="RC2CryptoServiceProvider"/>, <see cref="TripleDESCryptoServiceProvider"/></remarks>
    public static string? DecryptString<T>(string input, string key, string? salt, int keySize, int blockSize, int derivationIterations, CipherMode cipherMode, PaddingMode paddingMode) where T : System.Security.Cryptography.SymmetricAlgorithm
    {
        if (typeof(T).GetMethod(nameof(System.Security.Cryptography.SymmetricAlgorithm.Create), Type.EmptyTypes) is not MethodInfo methodInfo) return null;
        if (methodInfo.Invoke(null, []) is not object methodInvoked) return null;

        var hasCipherGeneratedSalt = !salt.HasValue();
        var keyByteSize = keySize / 8;
        var blockByteSize = blockSize / 8;
        var inputBytes = input.FromBase64String();
        var saltBytes = hasCipherGeneratedSalt
            ? inputBytes
                .Take(blockByteSize)
                .ToArray()
            : Hash.ConvertToSHA256Bytes(salt, keyByteSize);
        var ivBytes = Byte.GetIvBytes(inputBytes, blockByteSize, hasCipherGeneratedSalt);
        var cipherBytes = Byte.GetCipherBytes(inputBytes, blockByteSize, hasCipherGeneratedSalt);

        using var password = new Rfc2898DeriveBytes(key, saltBytes, derivationIterations, HashAlgorithmName.SHA256);

        var keyBytes = password.GetBytes(keyByteSize);

        using T symmetricKey = (T)methodInvoked;
        symmetricKey.BlockSize = blockSize;
        symmetricKey.Mode = cipherMode;
        symmetricKey.Padding = paddingMode;

        using var decryptor = symmetricKey.CreateDecryptor(keyBytes, ivBytes);
        using var memoryStream = new MemoryStream(cipherBytes);
        using var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
        using var streamReader = new StreamReader(cryptoStream, Encoding.UTF8);

        return streamReader.ReadToEnd();
    }

}
