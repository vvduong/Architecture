using System;
using System.Collections.Generic;
using System.Linq;
using Architecture.Domain.Customers;
using Architecture.Domain.Employees;
using Architecture.Domain.Products;
using Architecture.Domain.Sales;

namespace Architecture.Application.Sales.Commands.CreateSale.Factory
{
    public class SaleFactory : ISaleFactory
    {
        public Sale Create(DateTime date, Customer customer, Employee employee, Product product, int quantity)
        {
            var sale = new Sale();

            sale.Date = date;

            sale.Customer = customer;

            sale.Employee = employee;

            sale.Product = product;

            sale.UnitPrice = sale.Product.Price;

            sale.Quantity = quantity;

            // Note: Total price is calculated in domain logic

            return sale;
        }
    }
}
