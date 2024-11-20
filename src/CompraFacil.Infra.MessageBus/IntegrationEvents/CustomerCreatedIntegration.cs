using CompraFacil.Infra.MessageBus.Abstraction;

namespace CompraFacil.Infra.MessageBus.IntegrationEvents;

public class CustomerCreatedIntegration : IEvent
{
    public Guid Id { get; private set; }

    public string? FullName { get; private set; }

    public string? Email { get; private set; }
}
