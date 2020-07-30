using MediatR;
using OrderHamper.Api.Application.Dtos;
using OrderHamper.Domain.AggregateModel.OrderAggregate;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OrderHamper.Api.Application.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Response>
    {
        private IOrderRepository _orderRepository;
        public CreateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        }
        public async Task<Response> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var address = new OrderAddress(request.OrderaddressId, request.Street, request.City, request.State, request.Country, request.Zipcode);
            var order = new Order(request.Ordernumber, request.ReceiverName, address);
            foreach (var item in request.OrderItems)
            {
                order.AddOrderItem(item.ProductId, item.ProductName, item.Category, item.Units);
            }
            var id = await _orderRepository.Add(order);
            var result = new Response
            {
                OrderId = id.ToString()
            };
            return result;
        }
    }
}
