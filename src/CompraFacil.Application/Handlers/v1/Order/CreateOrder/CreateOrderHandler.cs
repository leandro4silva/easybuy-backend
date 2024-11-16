using MediatR;

namespace CompraFacil.Application.Handlers.v1.Order.CreateOrder;

public sealed class CreateOrderHandler : IRequestHandler<CreateOrderCommand, CreateOrderResult>
{
    public Task<CreateOrderResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
