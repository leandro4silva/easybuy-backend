using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace CompraFacil.Application.Handlers.v1.Customers.Create;

public class CreateCustomerCommand : IRequest<CreateCustomerResult>
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
}