using MicroService.Security.Encryption.Contracts;

namespace MicroService.Security.Encryption.Middleware.Orchestrators.Interfaces;

public interface IEncryptionOrchestrator
{
    Task<EncryptionResponse> ExecuteCryptoOperationAsync(EncryptionContract contract, CancellationToken cancellationToken = default);
    Task<EncryptionResponse> EncryptStringAsync(EncryptionContract contract, CancellationToken cancellationToken = default);
    Task<EncryptionResponse> DecryptStringAsync(EncryptionContract contract, CancellationToken cancellationToken = default);
}
