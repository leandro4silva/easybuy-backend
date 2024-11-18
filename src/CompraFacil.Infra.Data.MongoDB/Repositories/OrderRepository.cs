using CompraFacil.Domain.Entities;
using CompraFacil.Domain.Repositories;
using MongoDB.Driver;

namespace CompraFacil.Infra.Data.MongoDB.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly IMongoCollection<Order> _collection;
    
    public OrderRepository(IMongoDatabase mongoDatabase)
    {
        _collection = mongoDatabase.GetCollection<Order>("orders");
    }

    public async Task AddAsync(Order order)
    {
        await _collection.InsertOneAsync(order);
    }

    public async Task<Order> GetByIdAsync(Guid id)
    {
        return await _collection.Find(c => c.Id == id).FirstOrDefaultAsync();
    }

    public async Task UpdateAsync(Order order)
    {
        await _collection.ReplaceOneAsync(c => c.Id == order.Id, order);
    }
}
