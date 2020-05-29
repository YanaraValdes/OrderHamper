using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderHamper.Domain.AggregateModel.OrderAggregate;
using OrderHamper.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderHamper.Persistence.Configurations
{
    class OrderStatusConfiguration : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(EntityTypeBuilder<OrderStatus> orderStatusConfiguration)
        {
            orderStatusConfiguration.ToTable("orderstatus", OrderHamperContext.DEFAULT_SCHEMA);

            orderStatusConfiguration.HasKey(o => o.OrderStatusId);

            orderStatusConfiguration.Property(o => o.OrderStatusId)
                .HasDefaultValue(1)
                .ValueGeneratedNever()
                .IsRequired();

            orderStatusConfiguration.Property(o => o.Name)
                .HasMaxLength(200)
                .IsRequired();

            orderStatusConfiguration
                .Property<DateTime>("CreatedOn")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("CreatedOn")
                .IsRequired();

            orderStatusConfiguration
               .Property<DateTime>("ModifiedOn")
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("ModifiedOn")
               .IsRequired();
        }
    }
}
