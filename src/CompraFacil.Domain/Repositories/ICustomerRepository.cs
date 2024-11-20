using CompraFacil.Domain.Entities;

namespace CompraFacil.Domain.Repositories;

public interface ICustomerRepository
{
    Task AddAsync(Customer customer, CancellationToken cancellationToken);
}
