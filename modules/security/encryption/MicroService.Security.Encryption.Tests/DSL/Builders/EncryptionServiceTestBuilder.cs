using MicroService.Security.Encryption.Enums;
using MicroService.Security.Encryption.Services;
using MicroService.Security.Encryption.Tests.DSL.Subjects;

namespace MicroService.Security.Encryption.Tests.DSL.Builders;

public class EncryptionServiceTestBuilder
{
    private EncryptionService _encryptionService = null!;

    public EncryptionServiceTestBuilder WithEncryptionMethod(EncryptionMethod encryptionMethod)
    {
        _encryptionService = new(encryptionMethod);

        return this;
    }

    public EncryptionServiceSut Build()
    {
        _encryptionService ??= new();

        return new EncryptionServiceSut(_encryptionService);
    }
    
    public static EncryptionServiceTestBuilder ConfigureTests() => new();
}
