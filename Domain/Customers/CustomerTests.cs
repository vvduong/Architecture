﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Architecture.Domain.Customers
{
    [TestFixture]
    public class CustomerTests
    {
        private readonly Customer _customer;
        private const int Id = 1;
        private const string Name = "Test";
        private const string Email = "vvduong@lacviet.com.vn";

        public CustomerTests()
        {
            _customer = new Customer();
        }

        [Test]
        public void TestSetAndGetId()
        {
            _customer.Id = Id;

            Assert.That(_customer.Id, 
                Is.EqualTo(Id));
        }

        [Test]
        public void TestSetAndGetName()
        {
            _customer.Name = Name;

            Assert.That(_customer.Name, 
                Is.EqualTo(Name));
        }

        [Test]
        public void TestSetAndGetEmail()
        {
            _customer.Email = Email;

            Assert.That(_customer.Email, 
                Is.EqualTo(Email));
        }
    }
}
