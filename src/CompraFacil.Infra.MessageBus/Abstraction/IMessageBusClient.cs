namespace CompraFacil.Infra.MessageBus.Abstraction;

public interface IMessageBusClient
{
    Task PublishAsync(object message, string routingKey, string exchange, CancellationToken cancellationToken);
}
