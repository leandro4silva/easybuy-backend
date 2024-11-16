using System.Text.Json.Serialization;

namespace CompraFacil.Application.Handlers.v1.Order.GetOrderById;

public sealed class GetOrderByIdResult
{
    [JsonPropertyName("id")]
    public Guid Id { get; private set; }

    [JsonPropertyName("totalPrice")]
    public decimal TotalPrice { get; private set; }

    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; private set; }

    [JsonPropertyName("status")]
    public string? Status { get; private set; }
}
