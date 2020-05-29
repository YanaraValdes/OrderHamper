using Microsoft.EntityFrameworkCore;
using OrderHamper.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderHamper.Persistence
{
    public class OrderHamperDbContextFactory : DesignTimeDbContextFactoryBase<OrderHamperContext>
    {
        protected override OrderHamperContext CreateNewInstance(DbContextOptions<OrderHamperContext> options)
        {
            return new OrderHamperContext(options);
        }
    }
}
