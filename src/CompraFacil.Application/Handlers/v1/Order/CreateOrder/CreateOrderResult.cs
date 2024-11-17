using System.Text.Json.Serialization;

namespace CompraFacil.Application.Handlers.v1.Order.CreateOrder;

public sealed class CreateOrderResult
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
}
