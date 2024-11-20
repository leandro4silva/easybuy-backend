using CompraFacil.Domain.Events;

namespace CompraFacil.Domain.Entities;

public class Customer : AggregateRoot
{
    public string? FullName { get; set; }

    public string? Email { get; set; }

    public void CreatedAddEvent(CustomerCreated customerCreated) =>
        AddEvent(customerCreated);
}
