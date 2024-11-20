using AutoMapper;
using CompraFacil.Domain.Repositories;
using MediatR;

namespace CompraFacil.Application.Handlers.v1.Order.GetOrderById;

public sealed class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, GetOrderByIdResult>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public GetOrderByIdHandler(
        IOrderRepository orderRepository, IMapper mapper)
    {

        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<GetOrderByIdResult> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(request.Id, cancellationToken);

        return _mapper.Map<GetOrderByIdResult>(order);
    }
}
