using System;
using System.Collections.Generic;
using System.Text;

namespace OrderHamper.Domain.SeedWork
{
    public interface IEntity
    {
        string Id { get; }
        DateTime CreatedOn { get; }
        DateTime ModifiedOn { get; }
    }
}
