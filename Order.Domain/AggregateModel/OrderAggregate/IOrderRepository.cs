using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OrderHamper.Domain.SeedWork;

namespace OrderHamper.Domain.AggregateModel.OrderAggregate
{
    public interface IOrderRepository : IRepository<Order>
    {
        Order Add(Order order);

        void Update(Order order);

        Task<Order> GetAsync(int orderId);
    }
}
