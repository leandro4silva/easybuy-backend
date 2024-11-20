using AutoMapper;
using CompraFacil.Domain.Events;
using CompraFacil.Infra.MessageBus.IntegrationEvents;

namespace CompraFacil.Infra.MessageBus.Mappers;

public class CreateCustomerProfile : Profile
{
    public CreateCustomerProfile()
    {
        _ = CreateMap<CustomerCreated, CustomerCreatedIntegration>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName));
    }
}
