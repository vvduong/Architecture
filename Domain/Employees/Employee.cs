using System;
using Architecture.Domain.Common;

namespace Architecture.Domain.Employees
{
    public class Employee : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
