namespace CompraFacil.Application.Models.Requests.CreateOrder;

public sealed class PaymentInfoRequest
{
    public string? CardNumber { get; set; }

    public string? FullName { get; set; }

    public string? ExpirationDate { get; set; }

    public string? Cvv { get; set; }
}
