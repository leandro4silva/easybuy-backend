using RabbitMQ.Client;

namespace CompraFacil.Infra.MessageBus.Connections;

public sealed class ProducerConnection
{
    public IConnection Connection { get; private set; }

    public ProducerConnection(IConnection connection)
    {
        Connection = connection;
    }
}
