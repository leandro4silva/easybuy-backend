using CompraFacil.Domain.Entities.Abstraction;

namespace CompraFacil.Domain.Entities;

public class OrderItem : IEntityBase
{
    public Guid Id { get; protected set; } = Guid.NewGuid();

    public Guid ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }
}
