using MediatR;

namespace CompraFacil.Application.Handlers.v1.Order.GetOrderById;

public sealed class GetOrderByIdQuery : IRequest<GetOrderByIdResult>
{
    public Guid Id { get; set; }
}
