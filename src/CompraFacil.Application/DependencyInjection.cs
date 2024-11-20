using CompraFacil.Application.Handlers.v1.Order.CreateOrder;
using CompraFacil.Application.Mappers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CompraFacil.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        #region MediatR
        
        services.AddMediatR(typeof(CreateOrderHandler));
        services.AddAutoMapperProfiles();

        #endregion

        return services;
    }

    private static IServiceCollection AddAutoMapperProfiles(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(OrderProfile));
        return services;
    }
}
