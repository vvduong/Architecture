using System.Data.Entity;
using Architecture.Domain.Customers;
using Architecture.Domain.Employees;
using Architecture.Domain.Products;
using Architecture.Domain.Sales;

namespace Architecture.Application.Interfaces
{
    public interface IDatabaseService
    {
        IDbSet<Customer> Customers { get; set; }

        IDbSet<Employee> Employees { get; set; }
        
        IDbSet<Product> Products { get; set; }
        
        IDbSet<Sale> Sales { get; set; }

        void Save();
    }
}