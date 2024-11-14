using CompraFacil.Application.Features.Contracts.Requests;
using CompraFacil.Application.Features.Contracts.Responses;

namespace CompraFacil.Application.Features.Abstraction;

public interface IGetOrderByIdService
{
    Task<GetOrderByIdResponse?> ExecuteAsync(GetOrderByIdRequest request, CancellationToken cancellationToken);
}
