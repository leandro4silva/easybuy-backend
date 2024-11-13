
namespace CompraFacil.Domain.ValueObjects;

public class DeliveryAddress
{
    public string? Street { get; set; }

    public int? Number { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? ZipCode { get; set; }

    public override bool Equals(object? obj)
    {
        return obj is DeliveryAddress address &&
               Street == address.Street &&
               Number == address.Number &&
               City == address.City &&
               State == address.State &&
               ZipCode == address.ZipCode;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Street, Number, City, State, ZipCode);
    }
}
