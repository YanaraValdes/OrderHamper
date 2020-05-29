using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderHamper.Domain.AggregateModel.OrderAggregate;
using OrderHamper.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderHamper.Persistence.Configurations
{
    class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public object OrderingContext { get; private set; }

        public void Configure(EntityTypeBuilder<OrderItem> orderItemConfiguration)
        {
            orderItemConfiguration.ToTable("orderItems", OrderHamperContext.DEFAULT_SCHEMA);

            orderItemConfiguration.HasKey(o => o.Id);           

            orderItemConfiguration.Property<int>("OrderId")
                .IsRequired();            
           
            orderItemConfiguration
                .Property<string>("_productName")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("ProductName")
                .IsRequired();            

            orderItemConfiguration
                .Property<int>("_units")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Units")
                .IsRequired();

            orderItemConfiguration
              .Property<string>("_category")
              .UsePropertyAccessMode(PropertyAccessMode.Field)
              .HasColumnName("Category")
              .IsRequired();

        }
    }
}
