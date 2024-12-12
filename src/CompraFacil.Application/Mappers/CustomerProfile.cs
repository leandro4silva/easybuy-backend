
using AutoMapper;
using CompraFacil.Application.Handlers.v1.Customers.Create;
using DomainEntity = CompraFacil.Domain.Entities;
using CompraFacil.Domain.Events;
using CompraFacil.Customer.Application.Mappers;
using Microsoft.AspNetCore.Routing.Constraints;

namespace CompraFacil.Application.Mappers;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        _ = CreateMap<CreateCustomerCommand, DomainEntity.Customer>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Payload!.Email))
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Payload!.FullName))
            .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.Payload!.BirthDate))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Payload!.PhoneNumber))
            .ForMember(dest => dest.Address, opt => opt.ConvertUsing(new AddressMapper()));

        _ = CreateMap<DomainEntity.Customer, CreateCustomerResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

        _ = CreateMap<DomainEntity.Customer, CustomerCreated>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName));
    }
}
