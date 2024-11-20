using System.Text.Json.Serialization;

namespace CompraFacil.Application.Handlers.v1.Customers.Create;

public sealed class CreateCustomerResult
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
}
