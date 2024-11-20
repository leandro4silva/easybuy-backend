using CompraFacil.Domain.Entities;
using CompraFacil.Domain.Repositories;

namespace CompraFacil.Infra.Data.MongoDB.Repositories;

public sealed class CustomerRespository : ICustomerRepository
{
    private readonly IMongoRepository<Customer> _mongoRepository;

    public CustomerRespository(IMongoRepository<Customer> mongoRepository)
    {
        _mongoRepository = mongoRepository;
    }

    public async Task AddAsync(Customer customer, CancellationToken cancellationToken)
    {
        await _mongoRepository.AddAsync(customer);
    }
}
