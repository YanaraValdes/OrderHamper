using MediatR;
using OrderHamper.Domain.AggregateModel.OrderAggregate;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OrderHamper.Api.Application.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private IOrderRepository _orderRepository;
        public CreateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        }
        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var address = new OrderAddress(request.OrderaddressId, request.Street, request.City, request.State, request.Country, request.Zipcode);
            var order = new Order(request.Ordernumber, request.ReceiverName, address);
            foreach (var item in request.OrderItems)
            {
                order.AddOrderItem(item.ProductId, item.ProductName, item.Category, item.Units);
            }
            var result = await _orderRepository.Add(order);
            return result;
        }
    }
}
