using CompraFacil.Domain.Events.Abstraction;

namespace CompraFacil.Infra.MessageBus.Abstraction;

public interface IEventProcessor
{
    void Process(IEnumerable<IDomainEvent> events, CancellationToken cancellationToken);
}
