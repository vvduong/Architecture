using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Architecture.Application.Products.Queries.GetProductsList;

namespace Architecture.Service.Products
{
    public class ProductsController : ApiController
    {
        private readonly IGetProductsListQuery _query;

        public ProductsController(IGetProductsListQuery query)
        {
            _query = query;
        }

        public IEnumerable<ProductModel> Get()
        {
            return _query.Execute();
        }
    }
}