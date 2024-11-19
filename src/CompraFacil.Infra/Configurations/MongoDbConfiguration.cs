using System.Diagnostics.CodeAnalysis;

namespace CompraFacil.Infrastructure.Configurations;

[ExcludeFromCodeCoverage]
public sealed class MongoDbConfiguration
{
    public string? Database { get; set; }

    public string? ConnectionString { get; set; }
}
