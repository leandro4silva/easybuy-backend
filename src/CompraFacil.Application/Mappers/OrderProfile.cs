using AutoMapper;
using CompraFacil.Application.Handlers.v1.Order.GetOrderById;
using CompraFacil.Domain.Entities;

namespace CompraFacil.Application.Mappers;

public sealed class OrderProfile : Profile
{
    public OrderProfile()
    {
        _ = CreateMap<Order, GetOrderByIdResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice));
    }
}
