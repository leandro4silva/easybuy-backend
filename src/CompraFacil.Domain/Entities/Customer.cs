using CompraFacil.Domain.Entities.Abstraction;

namespace CompraFacil.Domain.Entities;

public class Customer : IEntityBase
{
    public Guid Id { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }
}
