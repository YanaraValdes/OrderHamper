using OrderHamper.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderHamper.Domain.AggregateModel.PersonAggregate
{
    public abstract class Receiver : IEntity, IAggregateRoot
    {
        public string IdentityGuid { get; private set; }

        public string Name { get; private set; }

        public DateTime CreatedOn { get; private set; }

        public DateTime ModifiedOn { get; private set; }
        public string Id { get; private set; }


        private Receiver()
        {
            //Required for serialization
        }


        public Receiver(string id, string identity, string name) : this()
        {
            var timeSpan = DateTime.Now;
            CreatedOn = timeSpan;
            ModifiedOn = timeSpan;
            Id = id;
            IdentityGuid = !string.IsNullOrWhiteSpace(identity) ? identity : throw new ArgumentNullException(nameof(identity));
            Name = !string.IsNullOrWhiteSpace(name) ? name : throw new ArgumentNullException(nameof(name));
        }        

        
    }
}
