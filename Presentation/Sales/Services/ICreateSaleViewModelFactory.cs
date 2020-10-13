using Architecture.Presentation.Sales.Models;

namespace Architecture.Presentation.Sales.Services
{
    public interface ICreateSaleViewModelFactory
    {
        CreateSaleViewModel Create();
    }
}