using System.Diagnostics.CodeAnalysis;

namespace CompraFacil.Infrastructure.Configurations;

[ExcludeFromCodeCoverage]
public sealed class AppConfiguration
{
    private const string EnvironmentDev = "dev";
    private const string EnvironmentHom = "hom";

    public MongoDbConfiguration? MongoDb { get; set; }

    public string? Environment { get; set; }

    public bool IsDevelopment =>
        EnvironmentDev.Equals(Environment, StringComparison.OrdinalIgnoreCase);

    public bool IsStaging =>
        EnvironmentHom.Equals(Environment, StringComparison.OrdinalIgnoreCase);
}

