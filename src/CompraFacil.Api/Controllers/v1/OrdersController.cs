using Amazon.Runtime.Internal;
using CompraFacil.Application.Common.Models;
using CompraFacil.Application.Handlers.v1.Order.CreateOrder;
using CompraFacil.Application.Handlers.v1.Order.GetOrderById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CompraFacil.Api.Controllers.v1;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrdersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(BaseResponse<GetOrderByIdResult>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get(
        GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);

        return response is not null ? Ok(response) : NoContent();
    }

    [HttpPost]
    [ProducesResponseType(typeof(BaseResponse<CreateOrderResult>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Post(
        CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);

        return response is not null ? CreatedAtAction(nameof(Get), request) : NoContent();
    }
}
