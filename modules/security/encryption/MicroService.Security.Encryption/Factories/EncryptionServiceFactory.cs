using System.Security.Cryptography;
using MicroService.Security.Encryption.Enums;
using MicroService.Security.Encryption.Interfaces;
using MicroService.Security.Encryption.Models;
using MicroService.Security.Encryption.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MicroService.Security.Encryption.Factories;

/// <inheritdoc cref="IEncryptionServiceFactory" />
public sealed class EncryptionServiceFactory(IServiceProvider serviceProvider) : IEncryptionServiceFactory
{
    readonly IServiceProvider _serviceProvider = serviceProvider;

    /// <inheritdoc />
    public IEncryptionService? CreateService(EncryptionMethod encryptionMethod)
    {
        return (EncryptionService?)Activator.CreateInstance(typeof(EncryptionService), encryptionMethod);
    }

    /// <inheritdoc />
    public IEncryptionService? CreateService(EncryptionMethod encryptionMethod, SymmetricAlgorithmOptions? encryptionOptions)
    {
        return (EncryptionService?)Activator.CreateInstance(typeof(EncryptionService), encryptionMethod, encryptionOptions);
    }

    /// <inheritdoc />
    public IEncryptionService? CreateService(EncryptionMethod encryptionMethod, int keySize, int blockSize, int derivationIterations, CipherMode cipherMode, PaddingMode paddingMode)
    {
        return (EncryptionService?)Activator.CreateInstance(typeof(EncryptionService), encryptionMethod, keySize, blockSize, derivationIterations, cipherMode, paddingMode);
    }

    /// <inheritdoc />
    public IEncryptionService? GetService(EncryptionMethod encryptionMethod)
    {
        var encryptionService = _serviceProvider.GetRequiredService<IEncryptionService>();
        encryptionService.Configure(encryptionMethod);
        return encryptionService;
    }

    /// <inheritdoc />
    public IEncryptionService? GetService(EncryptionMethod encryptionMethod, SymmetricAlgorithmOptions? encryptionOptions)
    {
        var encryptionService = _serviceProvider.GetRequiredService<IEncryptionService>();
        encryptionService.Configure(encryptionMethod, encryptionOptions);
        return encryptionService;
    }

    /// <inheritdoc />
    public IEncryptionService? GetService(EncryptionMethod encryptionMethod, int keySize, int blockSize, int derivationIterations, CipherMode cipherMode, PaddingMode paddingMode)
    {
        var encryptionService = _serviceProvider.GetRequiredService<IEncryptionService>();
        encryptionService.Configure(encryptionMethod, keySize, blockSize, derivationIterations, cipherMode, paddingMode);
        return encryptionService;
    }
}
