using CompraFacil.Domain.Repositories;
using CompraFacil.Infra.Data.MongoDB.Repositories;
using CompraFacil.Infrastructure.Configurations;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Diagnostics.CodeAnalysis;

namespace CompraFacil.Infra.Data.MongoDB;

[ExcludeFromCodeCoverage]
public static class DependencyInjection
{
    public static IServiceCollection AddMongoDB(this IServiceCollection services, AppConfiguration appConfiguration)
    {
        services.AddSingleton<IMongoClient, MongoClient>(sp =>
        {
            return new MongoClient(appConfiguration.MongoDb?.ConnectionString);
        });

        services.AddScoped<IMongoDatabase>(sp =>
        {
            var client = sp.GetRequiredService<IMongoClient>();
            return client.GetDatabase(appConfiguration.MongoDb?.Database);
        });


        services.AddRepositories();

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IOrderRepository, OrderRepository>();

        return services;
    }
}
