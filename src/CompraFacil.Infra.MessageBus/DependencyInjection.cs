using CompraFacil.Infra.MessageBus.Abstraction;
using CompraFacil.Infra.MessageBus.Clients;
using CompraFacil.Infra.MessageBus.Connections;
using CompraFacil.Infra.MessageBus.Event;
using CompraFacil.Infrastructure.Configurations;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace CompraFacil.Infra.MessageBus;

public static class DependencyInjection
{
    public static async Task<IServiceCollection> AddRabbitMqAsync(this IServiceCollection services, AppConfiguration appConfiguration)
    {
        var connectionFactory = new ConnectionFactory
        {
            HostName = appConfiguration.RabbitMq?.HostName!,
            Port = 
        };

        var connection = await connectionFactory.CreateConnectionAsync("customers-service-producer");

        services.AddSingleton(new ProducerConnection(connection));

        services.AddSingleton<IMessageBusClient, RabbitMqClient>();
        services.AddTransient<IEventProcessor, EventProcessor>();

        return services;
    }
}
