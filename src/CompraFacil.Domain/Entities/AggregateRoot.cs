using CompraFacil.Domain.Entities.Abstraction;
using CompraFacil.Domain.Events.Abstraction;

namespace CompraFacil.Domain.Entities;

public class AggregateRoot : IEntityBase
{
    private List<IDomainEvent> _events = new List<IDomainEvent>();

    public Guid Id { get; set; } = Guid.NewGuid();

    public IEnumerable<IDomainEvent> Events => _events;

    protected void AddEvent(IDomainEvent @event){
        if (@event != null)
            _events.Add(@event);
            
        _events = new List<IDomainEvent>();
    }
}
