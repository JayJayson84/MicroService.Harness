using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MicroService.Security.Encryption.Contracts;

public record EncryptionContract
{
    [Required]
    public string Value { get; init; } = null!;

    [Required]
    public string Key { get; init; } = null!;

    public string? Salt { get; init; }

    [Required]
    [EnumDataType(typeof(EncryptionOperation))]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public EncryptionOperation EncryptionOperation { get; init; }

    [Required]
    [EnumDataType(typeof(EncryptionMethod))]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public EncryptionMethod EncryptionMethod { get; init; }

    public EncryptionOptions? EncryptionOptions { get; init; }
}
