using CompraFacil.Domain.Entities;

namespace CompraFacil.Domain.Repositories;

public interface IOrderRepository
{
    Task<Order> GetByIdAsync(Guid id);

    Task AddAsync(Order order);

    Task UpdateAsync(Order order);
}
