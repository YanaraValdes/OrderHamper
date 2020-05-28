using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using OrderHamper.Domain.AggregateModel.OrderAggregate;

namespace OrderHamper.Persistence.Data
{
    public class OrderHamperContext: DbContext
    {
          public OrderHamperContext(DbContextOptions<OrderHamperContext> options)
                : base(options)
            {
            }

        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }
    }
}
