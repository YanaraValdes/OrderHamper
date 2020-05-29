using OrderHamper.Api.Application.Dtos;
using OrderHamper.Api.Application.Interfaces;
using OrderHamper.Domain.AggregateModel.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderHamper.Api.Application.Services
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        }        

        public async Task<int> AddOrder(OrderDto.OrderDetails orderDetails)
        {
            var address = new OrderAddress(orderDetails.OrderaddressId, orderDetails.Street, orderDetails.City, orderDetails.State, orderDetails.Country, orderDetails.Zipcode);
            var order = new Order(orderDetails.Ordernumber, orderDetails.ReceiverName, address);
            foreach (var item in orderDetails.Orderitems)
            {
                order.AddOrderItem(item.ProductId, item.ProductName, item.Category, item.Units);
            }            
            var result = await _orderRepository.Add(order);
            return result;
        }

        //public async Task<List<OrderDto.OrderDetails>> GetAllOrders()
        //{
        //    var orders = await _orderRepository.GetAll();
        //    var orderDetails = orders.Select(order =>
        //    {
        //        var detail = order.ToOrderDetails();
        //        return detail;
        //    }).ToList();
        //    return orderDetails;
        //}
    }
}
