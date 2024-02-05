using System.Security.Cryptography;
using MicroService.Security.Encryption.Services;

namespace MicroService.Security.Encryption.Tests.DSL.Subjects;

public class EncryptionServiceSut<TSymmetricAlgorithm>(EncryptionService<TSymmetricAlgorithm> encryptionService) where TSymmetricAlgorithm : SymmetricAlgorithm
{
    public EncryptionService<TSymmetricAlgorithm> EncryptionService { get; } = encryptionService;
}
