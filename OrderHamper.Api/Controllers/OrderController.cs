using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderHamper.Api.Application.Commands;
using OrderHamper.Api.Application.Exeptions;
using OrderHamper.Api.Application.Interfaces;
using OrderHamper.Api.Application.Queries;
using OrderHamper.Domain.AggregateModel.OrderAggregate;
using static OrderHamper.Api.Application.Dtos.OrderDto;

namespace OrderHamper.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {        
        private IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetOrdersAsync([FromQuery] GetOrderListQuery request)
        {           
            var orders = await _mediator.Send(request);
            return Ok(orders);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddOrderAsync([FromBody] CreateOrderCommand order)
        {
            var result = await _mediator.Send(order);
            return result.Error == null ? (IActionResult)Ok(result.OrderId) : BadRequest(result.Error);
        }

    }
}

