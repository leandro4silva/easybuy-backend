using CompraFacil.Domain.Events;
using CompraFacil.Domain.Events.Abstraction;
using CompraFacil.Infra.MessageBus.Abstraction;
using CompraFacil.Infra.MessageBus.IntegrationEvents;
using System.Text;

namespace CompraFacil.Infra.MessageBus.Event;

public sealed class EventProcessor : IEventProcessor
{
    private readonly IMessageBusClient _bus;

    public EventProcessor(
        IMessageBusClient bus)
    {
        _bus = bus;
    }

    public IEnumerable<IEvent> MapAll(IEnumerable<IDomainEvent> events)
    {
        return events.Select(Map);
    }

    public IEvent Map(IDomainEvent @event)
    {
        return @event switch
        {
            CustomerCreated e => new CustomerCreatedIntegration(e.Id, e.FullName, e.Email),
            _ => throw new InvalidOperationException($"Evento não suportado: {@event.GetType().Name}")
        };
    }

    public async void Process(IEnumerable<IDomainEvent> events, CancellationToken cancellationToken)
    {
        var integrationEvents = MapAll(events);

        foreach (var @event in integrationEvents)
        {
            await _bus.PublishAsync(@event, MapConvention(@event), "customer-service", cancellationToken);
        }
    }

    private string MapConvention(IEvent @event)
    {
        return ToDashCase(@event.GetType().Name);
    }

    public string ToDashCase(string text)
    {
        if (text == null)
        {
            throw new ArgumentNullException(nameof(text));
        }
        if (text.Length < 2)
        {
            return text;
        }
        var sb = new StringBuilder();
        sb.Append(char.ToLowerInvariant(text[0]));
        for (int i = 1; i < text.Length; ++i)
        {
            char c = text[i];
            if (char.IsUpper(c))
            {
                sb.Append('-');
                sb.Append(char.ToLowerInvariant(c));
            }
            else
            {
                sb.Append(c);
            }
        }

        Console.WriteLine($"ToDashCase: " + sb.ToString());

        return sb.ToString();
    }
}
