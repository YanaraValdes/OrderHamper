using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderHamper.Api.Application.Commands;
using OrderHamper.Api.Application.Interfaces;
using OrderHamper.Api.Application.Queries;
using OrderHamper.Domain.AggregateModel.OrderAggregate;
using static OrderHamper.Api.Application.Dtos.OrderDto;

namespace OrderHamper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        //private IOrderService _orderService;
        private IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IActionResult> GetOrdersAsync([FromQuery]GetOrderListQuery request)         
        {
            //var orders =  await _orderService.GetAllOrders();
            var orders = await _mediator.Send(request);
            return Ok(orders); 
        }
                
        [HttpPost]        
        public async Task<IActionResult> AddOrderAsync([FromBody]CreateOrderCommand order)
        {
            var id = await _mediator.Send(order);
            //var id = await _orderService.AddOrder(order);
            return Ok(id);
        }
    }
}
