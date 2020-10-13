﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMoq;
using Architecture.Application.Interfaces;
using Architecture.Common.Mocks;
using Architecture.Domain.Products;
using NUnit.Framework;

namespace Architecture.Application.Products.Queries.GetProductsList
{
    [TestFixture]
    public class GetProductsListQueryTests
    {
        private GetProductsListQuery _query;
        private AutoMoqer _mocker;
        private Product _product;

        private const int Id = 1;
        private const string Name = "Product 1";

        [SetUp]
        public void SetUp()
        {
            _mocker = new AutoMoqer();

            _product = new Product()
            {
                Id = Id,
                Name = Name
            };

            _mocker.GetMock<IDbSet<Product>>()
                .SetUpDbSet(new List<Product> { _product });

            _mocker.GetMock<IDatabaseService>()
                .Setup(p => p.Products)
                .Returns(_mocker.GetMock<IDbSet<Product>>().Object);

            _query = _mocker.Create<GetProductsListQuery>();
        }

        [Test]
        public void TestExecuteShouldReturnListOfProducts()
        {
            var results = _query.Execute();

            var result = results.Single();

            Assert.That(result.Id, Is.EqualTo(Id));
            Assert.That(result.Name, Is.EqualTo(Name));
        }
    }
}
