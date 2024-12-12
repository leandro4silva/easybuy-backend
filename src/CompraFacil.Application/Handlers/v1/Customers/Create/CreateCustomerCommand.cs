using CompraFacil.Customer.Application.Models.Requests.Customer;
using CompraFacil.Customer.Domain.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace CompraFacil.Application.Handlers.v1.Customers.Create;

public sealed class CreateCustomerCommand : IRequest<CreateCustomerResult>
{
    [FromBody]
    public Payload? Payload { get; set; }
}


public sealed class Payload 
{
    [JsonPropertyName("fullName")]
    public string? FullName { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("birthDate")]
    public DateTime BirthDate { get; set; }

    [JsonPropertyName("phoneNumber")]
    public string? PhoneNumber { get; set; }

    [JsonPropertyName("address")]
    public AddressRequest? Address { get; set; }
}