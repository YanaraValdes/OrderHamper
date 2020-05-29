using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static OrderHamper.Api.Application.Dtos.OrderDto;

namespace OrderHamper.Api.Application.Interfaces
{
    public interface IOrderService
    {
        public Task<List<OrderDetails>> GetAllOrders();
        public Task<int> AddOrder(OrderDetails order);
    }
}
