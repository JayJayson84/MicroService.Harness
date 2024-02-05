using MicroService.Security.Encryption.Middleware.Tests.DSL.Subjects;

namespace MicroService.Security.Encryption.Middleware.Tests.DSL.Asserts;

public class EncryptionOrchestratorAsserts(EncryptionOrchestratorSut sut)
{
    readonly EncryptionOrchestratorSut _sut = sut;
}
