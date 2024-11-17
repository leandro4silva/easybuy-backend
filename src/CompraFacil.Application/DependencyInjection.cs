using CompraFacil.Application.Handlers.v1.Order.CreateOrder;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CompraFacil.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        #region MediatR
        
        services.AddMediatR(typeof(CreateOrderHandler));

        #endregion

        return services;
    }
}
