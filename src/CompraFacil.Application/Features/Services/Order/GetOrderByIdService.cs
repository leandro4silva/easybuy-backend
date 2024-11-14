using CompraFacil.Application.Features.Abstraction;
using CompraFacil.Application.Features.Contracts.Requests;
using CompraFacil.Application.Features.Contracts.Responses;

namespace CompraFacil.Application.Features.Services.Order;

public class GetOrderByIdService : IGetOrderByIdService
{


    public Task<GetOrderByIdResponse?> ExecuteAsync(GetOrderByIdRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
