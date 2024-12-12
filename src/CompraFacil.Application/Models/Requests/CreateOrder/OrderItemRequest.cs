using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace CompraFacil.Application.Models.Requests.CreateOrder;

[ExcludeFromCodeCoverage]
public sealed class OrderItemRequest
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }

    [JsonPropertyName("price")]
    public decimal Price { get; set; }
}
