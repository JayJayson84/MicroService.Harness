namespace MicroService.Security.Encryption.Contracts;

public record EncryptionResponse
{
    public string? Message { get; set; }
    public int ResponseCode { get; set; }
    public string? ResponseType { get; set; }
}
