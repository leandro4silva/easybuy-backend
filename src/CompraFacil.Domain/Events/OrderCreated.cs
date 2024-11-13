using CompraFacil.Domain.Events.Abstraction;
using CompraFacil.Domain.ValueObjects;

namespace CompraFacil.Domain.Events;

public class OrderCreated : IDomainEvent
{
    public Guid Id { get; set; }

    public decimal TotalPrice { get; set; }

    public PaymentInfo? PaymentInfo { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }
}
