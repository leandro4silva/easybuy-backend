using AutoMapper;
using CompraFacil.Customer.Application.Models.Requests.Customer;
using CompraFacil.Customer.Domain.ValueObjects;

namespace CompraFacil.Customer.Application.Mappers;

public class AddressMapper : IValueConverter<AddressRequest, CustomerAddress>
{
    public CustomerAddress Convert(AddressRequest sourceMember, ResolutionContext context)
    {
        return new CustomerAddress()
        {
            City = sourceMember.City,
            Number = sourceMember.Number,
            State = sourceMember.State,
            ZipCode = sourceMember.ZipCode,
            Street = sourceMember.Street,
        };
    }
}
