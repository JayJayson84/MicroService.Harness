using System.Security.Cryptography;
using MicroService.Security.Encryption.Services;
using MicroService.Security.Encryption.Tests.DSL.Subjects;

namespace MicroService.Security.Encryption.Tests.DSL.Builders;

public class EncryptionServiceTestBuilder<TSymmetricAlgorithm> where TSymmetricAlgorithm : SymmetricAlgorithm
{
    private EncryptionService<TSymmetricAlgorithm> _encryptionService = null!;

    public EncryptionServiceSut<TSymmetricAlgorithm> Build()
    {
        _encryptionService ??= Activator.CreateInstance<EncryptionService<TSymmetricAlgorithm>>();

        return new EncryptionServiceSut<TSymmetricAlgorithm>(_encryptionService);
    }
    
    public static EncryptionServiceTestBuilder<TSymmetricAlgorithm> ConfigureTests() => new();
}
