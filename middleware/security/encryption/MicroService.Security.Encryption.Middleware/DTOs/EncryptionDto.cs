using MicroService.Security.Encryption.Enums;
using MicroService.Security.Encryption.Models;

namespace MicroService.Security.Encryption.Middleware.DTOs;

public record EncryptionDto
{
    public string Value { get; init; } = null!;
    public string Key { get; init; } = null!;
    public string? Salt { get; init; }
    public EncryptionMethod EncryptionMethod { get; init; }
    public SymmetricAlgorithmOptions? EncryptionOptions { get; init; }
}
