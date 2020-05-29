using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderHamper.Api.Application.Interfaces;
using OrderHamper.Domain.AggregateModel.OrderAggregate;
using static OrderHamper.Api.Application.Dtos.OrderDto;

namespace OrderHamper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;
        public OrderController(IOrderService orderservice)
        {
            _orderService = orderservice ?? throw new ArgumentNullException(nameof(orderservice));

        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()         {
            var orders =  await _orderService.GetAllOrders();
            return Ok(orders); 
        }

        [HttpPost]
        public async Task<IActionResult> AddOrderAsync(OrderDetails order)
        {
            var id = await _orderService.AddOrder(order);
            return Ok(id);
        }
    }
}
