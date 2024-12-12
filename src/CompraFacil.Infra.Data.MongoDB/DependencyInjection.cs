using DomainEntity = CompraFacil.Domain.Entities;
using CompraFacil.Domain.Entities.Abstraction;
using CompraFacil.Domain.Repositories;
using CompraFacil.Infra.Data.MongoDB.Repositories;
using CompraFacil.Infrastructure.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.Diagnostics.CodeAnalysis;

namespace CompraFacil.Infra.Data.MongoDB;

[ExcludeFromCodeCoverage]
public static class DependencyInjection
{
    public static IServiceCollection AddMongoDB(this IServiceCollection services, AppConfiguration appConfiguration, IConfiguration configuration)
    {
        BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));

        services.AddSingleton<IMongoClient, MongoClient>(sp =>
        {
            return new MongoClient(appConfiguration.MongoDb?.ConnectionString);
        });

        services.AddTransient<IMongoDatabase>(sp =>
        {
            var client = sp.GetRequiredService<IMongoClient>();
            return client.GetDatabase(appConfiguration.MongoDb?.Database);
        });


        services.AddRepositories();

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddMongoRepository<DomainEntity.Customer>("customers");
        services.AddMongoRepository<DomainEntity.Order>("orders");

        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<ICustomerRepository, CustomerRespository>();

        return services;
    }

    private static IServiceCollection AddMongoRepository<T>(this IServiceCollection services, string collection) where T : IEntityBase
    {
        services.AddScoped<IMongoRepository<T>>(f =>
        {
            var mongoDatabase = f.GetRequiredService<IMongoDatabase>();

            return new MongoRepository<T>(mongoDatabase, collection);
        });

        return services;
    }
}
