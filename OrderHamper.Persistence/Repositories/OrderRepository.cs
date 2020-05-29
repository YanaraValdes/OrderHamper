using Microsoft.EntityFrameworkCore;
using OrderHamper.Domain.AggregateModel.OrderAggregate;
using OrderHamper.Domain.SeedWork;
using OrderHamper.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrderHamper.Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        OrderHamperContext _context;
        public IUnitOfWork UnityOfWork => _context;        

        public OrderRepository(OrderHamperContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<int> Add(Order order)
        {
           var result =  await _context.Order.AddAsync(order);
            await _context.SaveEntitiesAsync();
            return result.Entity.Id;
        }

        public async Task<List<Order>> GetAll()
        {
            var orderList = await _context.Order.Include(s=>s.OrderItems).Include(o=> o.Address).ToListAsync();
            return orderList;
        }

        public Task<int> Update(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
