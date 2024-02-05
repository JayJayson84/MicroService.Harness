using Microsoft.Extensions.Logging;
using Moq;

namespace MicroService.Logging.Tests.DSL.Subjects;

internal record LoggerSut<T>
{
    public LoggerSut()
    {
        Assert = new(this);
    }

    public ILogger<T> Logger { get; set; } = null!;
    public Mock<ILogger<T>> MockLogger { get; set; } = null!;
    public LogLevel LogLevel { get; set; }
    public Dictionary<string, object?> ContextData { get; set; } = [];
    public EventId? EventId { get; set; }
    public string? Message { get; set; }
    public Dictionary<string, object?>? MessageArgs { get; set; }
    public LoggerTestAsserts<T> Assert { get; }
}
