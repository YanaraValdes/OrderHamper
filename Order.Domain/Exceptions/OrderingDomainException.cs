using System;
using System.Collections.Generic;
using System.Text;

namespace OrderHamper.Domain.Exceptions
{
    class OrderingDomainException: Exception
    {
        public OrderingDomainException()
        { }

        public OrderingDomainException(string message)
            : base(message)
        { }

        public OrderingDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
