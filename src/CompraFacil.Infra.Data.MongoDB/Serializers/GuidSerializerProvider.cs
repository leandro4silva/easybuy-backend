using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using System.Diagnostics.CodeAnalysis;

namespace CompraFacil.Infra.Data.MongoDB.Serializers;

[ExcludeFromCodeCoverage]
public sealed class GuidSerializerProvider : IBsonSerializationProvider
{
    public IBsonSerializer? GetSerializer(Type type)
    {
        return type == typeof(Guid) ? new GuidSerializer(GuidRepresentation.Standard) : null;
    }
}
