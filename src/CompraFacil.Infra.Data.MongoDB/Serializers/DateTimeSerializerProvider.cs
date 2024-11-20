using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using System.Diagnostics.CodeAnalysis;

namespace CompraFacil.Infra.Data.MongoDB.Serializers;

[ExcludeFromCodeCoverage]
public sealed class DateTimeSerializerProvider : IBsonSerializationProvider
{
    public IBsonSerializer? GetSerializer(Type type)
    {
        return type == typeof(DateTime) ? DateTimeSerializer.LocalInstance : null;
    }
}
