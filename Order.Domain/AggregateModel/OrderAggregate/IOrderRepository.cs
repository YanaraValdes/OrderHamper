using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OrderHamper.Domain.SeedWork;

namespace OrderHamper.Domain.AggregateModel.OrderAggregate
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<int> Add(Order order);

        Task<int> Update(Order order);

        Task<List<Order>> GetAll();
    }
}
