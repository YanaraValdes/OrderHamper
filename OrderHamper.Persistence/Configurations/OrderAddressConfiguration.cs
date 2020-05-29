using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderHamper.Domain.AggregateModel.OrderAggregate;
using OrderHamper.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderHamper.Persistence.Configurations
{
    class OrderAddressConfiguration : IEntityTypeConfiguration<OrderAddress>
    {
        public void Configure(EntityTypeBuilder<OrderAddress> orderAddressConfiguration)
        {
            orderAddressConfiguration.ToTable("orderaddress", OrderHamperContext.DEFAULT_SCHEMA);

            orderAddressConfiguration.HasKey(o => o.OrderAddressId);

            orderAddressConfiguration.Property(o => o.OrderAddressId)
                .HasDefaultValue(1)
                .ValueGeneratedNever()
                .IsRequired();

            orderAddressConfiguration.Property(o => o.Street)
                .HasMaxLength(200)
                .IsRequired();

            orderAddressConfiguration.Property(o => o.State)
                .HasMaxLength(200)
                .IsRequired();

            orderAddressConfiguration.Property(o => o.City)
                .HasMaxLength(200)
                .IsRequired();

            orderAddressConfiguration.Property(o => o.ZipCode)
               .HasMaxLength(200)
               .IsRequired();

            orderAddressConfiguration.Property(o => o.Country)
               .HasMaxLength(200)
               .IsRequired();           
        }
    }      
    
}
