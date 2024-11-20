using AutoMapper;
using CompraFacil.Application.Handlers.v1.Order.CreateOrder;
using CompraFacil.Application.Helpers;
using CompraFacil.Domain.Events;
using CompraFacil.Domain.Repositories;
using CompraFacil.Infrastructure.Notifications.Abstraction;
using MediatR;
using Microsoft.Extensions.Logging;
using DomainEntity = CompraFacil.Domain.Entities;

namespace CompraFacil.Application.Handlers.v1.Customers.Create;

public sealed class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerResult>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly ILogger<CreateOrderHandler> _logger;
    private readonly INotificationService _notificationService;
    private readonly IMapper _mapper;

    public CreateCustomerHandler(
        ICustomerRepository customerRepository, ILogger<CreateOrderHandler> logger, INotificationService notificationService, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _logger = logger;
        _notificationService = notificationService;
        _mapper = mapper;
    }

    public async Task<CreateCustomerResult> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = _mapper.Map<DomainEntity.Customer>(request);
        
        try
        {
            var customerCreatedEvent = _mapper.Map<CustomerCreated>(customer);

            customer.CreatedAddEvent(customerCreatedEvent);

            await _customerRepository.AddAsync(customer, cancellationToken);


        }
        catch (Exception ex)
        {
            var msg = "Erro indefinido no cadastro de usuario";
            NotificationHelper.Notificar(ex, msg, _notificationService, _logger);
        }

        return _mapper.Map<CreateCustomerResult>(customer);
    }
}
