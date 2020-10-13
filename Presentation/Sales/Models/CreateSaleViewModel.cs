using System.Collections.Generic;
using System.Web.Mvc;
using Architecture.Application.Sales.Commands.CreateSale;

namespace Architecture.Presentation.Sales.Models
{
    public class CreateSaleViewModel
    {
        public List<SelectListItem> Customers { get; set; }

        public List<SelectListItem> Employees { get; set; }

        public List<SelectListItem> Products { get; set; }

        public CreateSaleModel Sale { get; set; }
    }
}