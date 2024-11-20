using CompraFacil.Domain.Entities.Abstraction;
using CompraFacil.Domain.Repositories;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace CompraFacil.Infra.Data.MongoDB.Repositories;

public sealed class MongoRepository<T> : IMongoRepository<T> where T : IEntityBase
{
    public IMongoCollection<T> Collection { get; private set; }

    public MongoRepository(IMongoDatabase database, string collectionName)
    {
        Collection = database.GetCollection<T>(collectionName);
    }

    public async Task AddAsync(T entity)
    {
        await Collection.InsertOneAsync(entity);
    }

    public async Task<IReadOnlyList<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return await Collection.Find(predicate).ToListAsync();
    }

    public async Task<T> GetAsync(Guid id)
    {
        return await Collection.Find(e => e.Id.Equals(id)).SingleOrDefaultAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        await Collection.ReplaceOneAsync(e => e.Id.Equals(entity.Id), entity);
    }
}
