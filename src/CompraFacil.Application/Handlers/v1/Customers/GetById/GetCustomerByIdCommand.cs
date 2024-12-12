using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CompraFacil.Customer.Application.Handlers.v1.Customers.GetById;

public sealed class GetCustomerByIdCommand : IRequest<GetCustomerByIdResult>
{
    [FromQuery(Name = "id")]
    public Guid Id { get; set; }
}
