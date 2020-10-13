using System;
using System.Linq;
using System.Web.Mvc;
using Architecture.Application.Sales.Commands.CreateSale;
using Architecture.Application.Sales.Queries.GetSaleDetail;
using Architecture.Application.Sales.Queries.GetSalesList;
using Architecture.Presentation.Sales.Models;
using Architecture.Presentation.Sales.Services;

namespace Architecture.Presentation.Sales
{
    [RoutePrefix("sales")]
    public class SalesController : Controller
    {
        private readonly IGetSalesListQuery _salesListQuery;
        private readonly IGetSaleDetailQuery _saleDetailQuery;
        private readonly ICreateSaleViewModelFactory _factory;
        private readonly ICreateSaleCommand _createCommand;

        public SalesController(
            IGetSalesListQuery salesListQuery,
            IGetSaleDetailQuery saleDetailQuery,
            ICreateSaleViewModelFactory factory,
            ICreateSaleCommand createCommand)
        {
            _salesListQuery = salesListQuery;
            _saleDetailQuery = saleDetailQuery;
            _factory = factory;
            _createCommand = createCommand;
        }

        [Route("")]
        public ViewResult Index()
        {
            var sales = _salesListQuery.Execute();

            return View(sales);
        }

        [Route("{id:int}")]
        public ViewResult Detail(int id)
        {
            var sale = _saleDetailQuery.Execute(id);

            return View(sale);
        }

        [Route("create")]
        public ViewResult Create()
        {
            var viewModel = _factory.Create();

            return View(viewModel);
        }

        [Route("create")]
        [HttpPost]
        public RedirectToRouteResult Create(CreateSaleViewModel viewModel)
        {
            var model = viewModel.Sale;            

            _createCommand.Execute(model);

            return RedirectToAction("index", "sales");
        }
    }
}