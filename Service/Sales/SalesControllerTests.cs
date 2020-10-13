using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using AutoMoq;
using Architecture.Application.Sales.Commands.CreateSale;
using Architecture.Application.Sales.Queries.GetSaleDetail;
using Architecture.Application.Sales.Queries.GetSalesList;
using Moq;
using NUnit.Framework;

namespace Architecture.Service.Sales
{
    [TestFixture]
    public class SalesControllerTests
    {
        private SalesController _controller;
        private AutoMoqer _mocker;

        [SetUp]
        public void Setup()
        {
            _mocker = new AutoMoqer();

            _controller = _mocker.Create<SalesController>();
        }

        [Test]
        public void TestGetShouldReturnListOfSales()
        {
            var sale = new SalesListItemModel();

            _mocker.GetMock<IGetSalesListQuery>()
                .Setup(p => p.Execute())
                .Returns(new List<SalesListItemModel> {sale} );

            var result = _controller.Get();

            Assert.That(result, 
                Contains.Item(sale));
        }

        [Test]
        public void TestGetShouldReturnSaleDetails()
        {
            var sale = new SaleDetailModel();

            _mocker.GetMock<IGetSaleDetailQuery>()
                .Setup(p => p.Execute(1))
                .Returns(sale);

            var result = _controller.Get(1);

            Assert.That(result,
                Is.EqualTo(sale));
        }

        [Test]
        public void TestCreateSaleShouldCreateSale()
        {
            var sale = new CreateSaleModel();

            var result = _controller.Create(sale);

            _mocker.GetMock<ICreateSaleCommand>()
                .Verify(p => p.Execute(sale),
                    Times.Once);

            Assert.That(result.StatusCode, 
                Is.EqualTo(HttpStatusCode.Created));
        }
    }
}