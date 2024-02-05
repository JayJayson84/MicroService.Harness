using MicroService.Security.Encryption.Services;

namespace MicroService.Security.Encryption.Tests.DSL.Subjects;

public class EncryptionServiceSut(EncryptionService encryptionService)
{
    public EncryptionService EncryptionService { get; } = encryptionService;
}
