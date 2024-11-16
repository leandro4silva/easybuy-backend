namespace CompraFacil.Application.Models.Requests.CreateOrder;

public sealed class CustomerRequest
{
    public Guid? Id { get; set; } = Guid.NewGuid();

    public string? FullName { get; set; }

    public string? Email { get; set; }
}
