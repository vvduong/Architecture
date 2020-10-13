using System.Collections.Generic;

namespace Architecture.Application.Sales.Queries.GetSalesList
{
    public interface IGetSalesListQuery
    {
        List<SalesListItemModel> Execute();
    }
}