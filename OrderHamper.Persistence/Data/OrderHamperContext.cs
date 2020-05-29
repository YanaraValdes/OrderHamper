using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderHamper.Domain.AggregateModel.OrderAggregate;
using OrderHamper.Domain.SeedWork;
using OrderHamper.Persistence.Configurations;

namespace OrderHamper.Persistence.Data
{
    public class OrderHamperContext: DbContext, IUnitOfWork
    {
        public const string DEFAULT_SCHEMA = "ordering";
        public OrderHamperContext(DbContextOptions<OrderHamperContext> options)
                : base(options)
            {
            }

        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }
        public DbSet<OrderAddress> OrderAddress { get; set; }

        public async Task<int> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<OrderAddress>();
            //modelBuilder.ApplyConfiguration(new OrderAddressConfiguration());
            //modelBuilder.ApplyConfiguration(new OrderConfiguration());
            //modelBuilder.ApplyConfiguration(new OrderStatusConfiguration());
            //modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
            //base.OnModelCreating(modelBuilder);
        }
    }
}
