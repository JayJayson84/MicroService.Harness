using MicroService.Security.Encryption.Middleware.Orchestrators.Interfaces;
using MicroService.Security.Encryption.Middleware.Tests.DSL.Asserts;

namespace MicroService.Security.Encryption.Middleware.Tests.DSL.Subjects;

public class EncryptionOrchestratorSut
{
    public EncryptionOrchestratorSut()
    {
        Assert = new(this);
    }

    public IEncryptionOrchestrator EncryptionOrchestrator { get; set; } = null!;
    public EncryptionOrchestratorAsserts Assert { get; }
}
