using OrderHamper.Domain.AggregateModel.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using static OrderHamper.Api.Application.Dtos.OrderDto;

namespace OrderHamper.Api.Application.Dtos
{
    public static class OrderExtension
    {
        public static OrderDetails ToOrderDetails(this Order order) {

            var orderDetails = new OrderDetails {
                City = order.Address.City,
                Country = order.Address.Country,
                Date = order.CreatedOn,
                Ordernumber = order.Id,
                OrderaddressId = order.OrderAddressId,
                State = order.Address.State,
                Status = order.OrderStatusId,
                Street = order.Address.Street,
                Total = order.GetTotal(),
                Zipcode = order.Address.ZipCode,
                ReceiverName = order.ReceiverName,
                Orderitems = SetOrderItems(order._orderItems)
            };
            return orderDetails;
        }

        private static List<OrderItemDto> SetOrderItems(List<OrderItem> orderItems)
        {
            var orderItemList = orderItems.Select(item => {
                var orderItem = new OrderItemDto
                {
                    Category = item.Category,
                    ProductId = item.ProductId,
                    Units = item.Units,
                    ProductName = item.ProductName
                };
                return orderItem;
            }).ToList();
            return orderItemList;
        }
    }
}
