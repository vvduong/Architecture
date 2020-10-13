using Architecture.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.Domain.Categories
{
    public class Category : IEntity
    {
        public int Id  { get; set; }

        public string Name { get; set; }
    }
}
