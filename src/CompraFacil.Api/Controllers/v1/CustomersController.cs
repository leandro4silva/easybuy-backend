﻿using CompraFacil.Application.Common.Models;
using CompraFacil.Application.Handlers.v1.Customers.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CompraFacil.Api.Controllers.v1;

[ApiVersion("1.0")]
[Route("v{version:apiVersion}/customers")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(BaseResponse<CreateCustomerResult>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Post(
        CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);

        return response is not null ? CreatedAtAction(nameof(Post), response) : NoContent();
    }
}
