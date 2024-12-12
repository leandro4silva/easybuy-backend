using DomainEntity = CompraFacil.Domain.Entities;
using CompraFacil.Domain.Repositories;

namespace CompraFacil.Infra.Data.MongoDB.Repositories;

public sealed class CustomerRespository : ICustomerRepository
{
    private readonly IMongoRepository<DomainEntity.Customer> _mongoRepository;

    public CustomerRespository(IMongoRepository<DomainEntity.Customer> mongoRepository)
    {
        _mongoRepository = mongoRepository;
    }

    public async Task AddAsync(DomainEntity.Customer customer, CancellationToken cancellationToken)
    {
        await _mongoRepository.AddAsync(customer);
    }
}
