using AutoMapper;
using CompraFacil.Application.Helpers;
using CompraFacil.Domain.Repositories;
using CompraFacil.Infrastructure.Notifications.Abstraction;
using MediatR;
using Microsoft.Extensions.Logging;
using DomainEntity = CompraFacil.Domain.Entities;

namespace CompraFacil.Application.Handlers.v1.Order.CreateOrder;

public sealed class CreateOrderHandler : IRequestHandler<CreateOrderCommand, CreateOrderResult>
{
    private readonly IOrderRepository _orderRepository;
    private readonly ILogger<CreateOrderHandler> _logger;
    private readonly INotificationService _notificationService;
    private readonly IMapper _mapper;

    public CreateOrderHandler(
        IOrderRepository orderRepository, ILogger<CreateOrderHandler> logger, INotificationService notificationService, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _logger = logger;
        _notificationService = notificationService;
        _mapper = mapper;
    }

    public async Task<CreateOrderResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = _mapper.Map<DomainEntity.Order>(request);

        try
        {
            await _orderRepository.AddAsync(order);
        }
        catch(Exception ex)
        {
            var msg = "Erro indefinido no cadastro de usuario";
            NotificationHelper.Notificar(ex, msg, _notificationService, _logger);
        }

        return _mapper.Map<CreateOrderResult>(order);
    }
}
