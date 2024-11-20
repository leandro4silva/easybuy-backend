using System.Diagnostics.CodeAnalysis;

namespace CompraFacil.Infrastructure.Configurations;

[ExcludeFromCodeCoverage]
public class RabbitMqConfiguration
{
    public string? HostName { get; set; }

    public string? Port { get; set; }

    public string? User { get; set; }

    public string? Password { get; set; }
}
