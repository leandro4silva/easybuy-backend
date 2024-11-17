using AutoMapper;
using CompraFacil.Application.Handlers.v1.Order.CreateOrder;
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

        _ = CreateMap<Order, CreateOrderCommand>()
            .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer))
            .ForMember(dest => dest.DeliveryAddress, opt => opt.MapFrom(src => src.DeliveryAddress))
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items))
            .ForMember(dest => dest.PaymentAddress, opt => opt.MapFrom(src => src.PaymentAddress))
            .ForMember(dest => dest.PaymentInfo, opt => opt.MapFrom(src => src.PaymentInfo));

        _ = CreateMap<Order, CreateOrderResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

    }

    private 
}
