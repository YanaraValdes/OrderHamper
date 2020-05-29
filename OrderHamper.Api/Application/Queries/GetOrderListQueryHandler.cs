using MediatR;
using Microsoft.EntityFrameworkCore;
using OrderHamper.Api.Application.Dtos;
using OrderHamper.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static OrderHamper.Api.Application.Dtos.OrderDto;

namespace OrderHamper.Api.Application.Queries
{
    public class GetOrderListQueryHandler : IRequestHandler<GetOrderListQuery, List<OrderDetails>>
    {
        private readonly OrderHamperContext _context;
        public GetOrderListQueryHandler(OrderHamperContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<List<OrderDetails>> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
        {
            var orderList = await _context.Order.Include(s => s.OrderItems).Include(o => o.Address).ToListAsync();
            var orderListDto = orderList.Select(order => {
                var orderDto = order.ToOrderDetails();
                return orderDto;
            }).ToList();
            return orderListDto;

        }
    }
}
