using Microsoft.Extensions.Configuration;

namespace MicroService.Configuration;

public record RabbitMqConfiguration
{
    private readonly IConfiguration _config;
    private readonly IConfigurationSection _rabbitMqConfig;

    public RabbitMqConfiguration(IConfiguration config, string? connectionName = null)
    {
        _config = config;
        _rabbitMqConfig = _config.GetSection("RabbitMq");

        var hostname = _rabbitMqConfig["Hostname"];
        if (hostname?.Contains(';') == true)
        {
            Nodes = hostname.Split(';', StringSplitOptions.RemoveEmptyEntries);
            Host = "rabbitmq://RabbitMqCluster/";
            IsCluster = true;
        }
        else
        {
            var virtualHost = connectionName ?? _rabbitMqConfig["VirtualHost"];

            Nodes = [];
            Host = string.IsNullOrEmpty(virtualHost) || virtualHost.Equals("/") ? $"rabbitmq://{hostname}" : $"rabbitmq://{hostname}/{virtualHost}";
            IsCluster = false;
        }
    }

    public string Host { get; }
    public string? Username => _rabbitMqConfig["Username"];
    public string? Password => _rabbitMqConfig["Password"];
    public ushort HeartbeatInterval => _rabbitMqConfig.GetValue<ushort>("Heartbeat_Interval");
    public bool IsCluster { get; init; }
    public IReadOnlyCollection<string> Nodes { get; init; }
}
