using System;
using System.Collections.Generic;
using System.Text;

namespace OrderHamper.Domain.SeedWork
{
    public class Entity
    {
        private int _id;
        private DateTime createdOn;
        private DateTime modifiedOn;

        public int Id { get => _id; set => _id = value; }
        public DateTime CreatedOn { get => createdOn; private set => createdOn = DateTime.Now; }
        public DateTime ModifiedOn { get => modifiedOn; set => modifiedOn = DateTime.Now; }
    }
}
