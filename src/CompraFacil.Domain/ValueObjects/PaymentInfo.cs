
namespace CompraFacil.Domain.ValueObjects;

public class PaymentInfo
{
    public string? CardNumber { get; set; }

    public string? FullName { get; set; }

    public string? Expiration { get; set; }

    public string? Cvv { get; set; }

    public override bool Equals(object? obj)
    {
        return obj is PaymentInfo info &&
               CardNumber == info.CardNumber &&
               FullName == info.FullName &&
               Expiration == info.Expiration &&
               Cvv == info.Cvv;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(CardNumber, FullName, Expiration, Cvv);
    }
}
