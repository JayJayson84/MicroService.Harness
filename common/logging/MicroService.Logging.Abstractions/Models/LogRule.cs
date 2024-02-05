namespace MicroService.Logging.Models;

public sealed record LogRule
{
    public string? MinLevel { get; set; }
    public string? MaxLevel { get; set; }
    public string? LoggerNamePattern { get; set; }
}
