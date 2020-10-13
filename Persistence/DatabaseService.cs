using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Architecture.Application.Interfaces;
using Architecture.Domain.Categories;
using Architecture.Domain.Customers;
using Architecture.Domain.Employees;
using Architecture.Domain.Products;
using Architecture.Domain.Sales;
using Architecture.Persistence.Categories;
using Architecture.Persistence.Customers;
using Architecture.Persistence.Employees;
using Architecture.Persistence.Products;
using Architecture.Persistence.Sales;


namespace Architecture.Persistence
{
    public class DatabaseService : DbContext, IDatabaseService
    {
        public IDbSet<Customer> Customers { get; set; }

        public IDbSet<Employee> Employees { get; set; }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<Sale> Sales { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public DatabaseService() : base("Architecture")
        {
            Database.SetInitializer(new DatabaseInitializer());
        }

        public void Save()
        {
            this.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new EmployeeConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new SaleConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
        }
    }
}
