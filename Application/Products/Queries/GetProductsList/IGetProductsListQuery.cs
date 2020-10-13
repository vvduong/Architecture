using System.Collections.Generic;

namespace Architecture.Application.Products.Queries.GetProductsList
{
    public interface IGetProductsListQuery
    {
        List<ProductModel> Execute();
    }
}