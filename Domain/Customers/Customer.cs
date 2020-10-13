using System;
using Architecture.Domain.Common;

namespace Architecture.Domain.Customers
{
    public class Customer : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
    }
}
