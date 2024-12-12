using CompraFacil.Customer.Domain.ValueObjects;
using CompraFacil.Domain.Events;

namespace CompraFacil.Domain.Entities;

public class Customer : AggregateRoot
{
    public string? FullName { get; set; }

    public string? Email { get; set; }

    public DateTime BirthDate { get; set; }

    public string? PhoneNumber { get; set; }

    public CustomerAddress? Address { get; set; }

    public void CreatedAddEvent(CustomerCreated customerCreated) =>
        AddEvent(customerCreated);
}
