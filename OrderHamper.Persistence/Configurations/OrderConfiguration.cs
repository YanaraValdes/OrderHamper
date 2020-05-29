using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderHamper.Domain.AggregateModel.OrderAggregate;
using OrderHamper.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderHamper.Persistence.Configurations
{
    class OrderConfiguration: IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> orderConfiguration)
        {
            orderConfiguration.ToTable("orders", OrderHamperContext.DEFAULT_SCHEMA);

            orderConfiguration.HasKey(o => o.Id);            

            //Address value object persisted as owned entity type supported since EF Core 2.0
            //orderConfiguration
            //    .OwnsOne(o => o.Address, a =>
            //    {
            //        a.WithOwner();
            //    });

            orderConfiguration
                .Property<int>("ReceiverId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("ReceiverId")
                .IsRequired();

            orderConfiguration
                .Property<DateTime>("CreatedOn")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("CreatedOn")
                .IsRequired();

            orderConfiguration
                .Property<DateTime>("ModifiedOn")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("ModifiedOn")
                .IsRequired();

            orderConfiguration
                .Property<int>("OrderStatusId")
                // .HasField("_orderStatusId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("OrderStatusId")
                .IsRequired();

            orderConfiguration
                .Property<int>("OrderAddressId")                
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("OrderAddressId")
                .IsRequired();



            var navigation = orderConfiguration.Metadata.FindNavigation(nameof(Order.OrderItems));

            // DDD Patterns comment:
            //Set as field (New since EF 1.1) to access the OrderItem collection property through its field
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);           

            orderConfiguration.HasOne(o => o.OrderStatus)
                .WithMany()
                // .HasForeignKey("OrderStatusId");
                .HasForeignKey("OrderStatusId");

            orderConfiguration.HasOne(o => o.Address)
                .WithMany()
                // .HasForeignKey("OrderStatusId");
                .HasForeignKey("OrderAddressId");
        }
    }
}
