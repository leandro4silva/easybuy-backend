using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace CompraFacil.Customer.Application.Models.Requests.Customer;

[ExcludeFromCodeCoverage]
public sealed class AddressRequest
{
    [JsonPropertyName("street")]
    public string? Street { get; private set; }

    [JsonPropertyName("number")]
    public string? Number { get; private set; }

    [JsonPropertyName("city")]
    public string? City { get; private set; }

    [JsonPropertyName("state")]
    public string? State { get; private set; }

    [JsonPropertyName("zipCode")]
    public string? ZipCode { get; set; }
}
