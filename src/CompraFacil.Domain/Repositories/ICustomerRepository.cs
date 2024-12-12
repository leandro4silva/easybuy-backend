using DomainEntity = CompraFacil.Domain.Entities;

namespace CompraFacil.Domain.Repositories;

public interface ICustomerRepository
{
    Task AddAsync(DomainEntity.Customer customer, CancellationToken cancellationToken);
}
