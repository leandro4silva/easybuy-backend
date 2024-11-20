using CompraFacil.Infra.MessageBus.Abstraction;
using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace CompraFacil.Infra.MessageBus.Clients;

public sealed class RabbitMqClient : IMessageBusClient
{
    private readonly IConnectionFactory _connection;

    public RabbitMqClient(IConnectionFactory connection)
    {
        _connection = connection;
    }

    public async Task PublishAsync(object message, string routingKey, string exchange, CancellationToken cancellationToken)
    {
        if (routingKey.Contains("-integration"))
        {
            routingKey = routingKey.Replace("-integration", "");
        }

        var connection = await _connection.CreateConnectionAsync(cancellationToken);
        var channel = await connection.CreateChannelAsync(cancellationToken: cancellationToken);

        var settings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        var payload = JsonConvert.SerializeObject(message, settings);
        Console.WriteLine(payload);

        var body = Encoding.UTF8.GetBytes(payload);

        await channel.ExchangeDeclareAsync(exchange, "topic", true, cancellationToken: cancellationToken);

        await channel.BasicPublishAsync(exchange, routingKey, false, body, cancellationToken);
    }
}
