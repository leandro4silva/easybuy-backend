using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CompraFacil.Application.Handlers.v1.Order.GetOrderById;

public sealed class GetOrderByIdQuery : IRequest<GetOrderByIdResult>
{
    [FromRoute(Name = "id")]
    public Guid Id { get; set; }
}
