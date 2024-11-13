using CompraFacil.Domain.Enums;
using CompraFacil.Domain.Events;
using CompraFacil.Domain.ValueObjects;

namespace CompraFacil.Domain.Entities;

public class Order : AggregateRoot
{
    public decimal TotalPrice { get; set; }

    public Customer? Customer { get; set; }

    public DeliveryAddress? DeliveryAddress { get; set; }

    public PaymentAddress? PaymentAddress { get; set; }

    public PaymentInfo? PaymentInfo { get; set; }

    public List<OrderItem>? Items { get; set; }

    public OrderStatus Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public void OrderCreatedAddEvent(OrderCreated orderCreated)
    {
        AddEvent(orderCreated);
    }
}
