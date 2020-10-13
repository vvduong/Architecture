﻿using System;
using System.Collections.Generic;
using System.Linq;
using Architecture.Domain.Customers;
using Architecture.Domain.Employees;
using Architecture.Domain.Products;
using Architecture.Domain.Sales;

namespace Architecture.Application.Sales.Commands.CreateSale.Factory
{
    public interface ISaleFactory
    {
        Sale Create(DateTime date, Customer customer, Employee employee, Product product, int quantity);
    }
}