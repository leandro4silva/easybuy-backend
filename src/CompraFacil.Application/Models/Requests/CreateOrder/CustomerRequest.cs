using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace CompraFacil.Application.Models.Requests.CreateOrder;

[ExcludeFromCodeCoverage]
public sealed class CustomerRequest
{
    [JsonPropertyName("id")]
    public Guid? Id { get; set; }

    [JsonPropertyName("fullName")]
    public string? FullName { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }
}
