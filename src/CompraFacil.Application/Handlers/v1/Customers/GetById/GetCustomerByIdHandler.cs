using CompraFacil.Domain.Repositories;
using MediatR;

namespace CompraFacil.Customer.Application.Handlers.v1.Customers.GetById;

public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdCommand, GetCustomerByIdResult>
{
    private readonly ICustomerRepository _customerRepository;

    public GetCustomerByIdHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public Task<GetCustomerByIdResult> Handle(GetCustomerByIdCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
