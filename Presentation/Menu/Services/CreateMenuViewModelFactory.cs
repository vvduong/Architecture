using Architecture.Presentation.Menus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Architecture.Presentation.Menus.Services
{
    public class CreateMenuViewModelFactory : ICreateMenuViewModelFactory
    {
        public CreateMenuViewModelFactory()
        {

        }
        public CreateMenuViewModel Create()
        {
            var viewModel = new CreateMenuViewModel();

            return viewModel;
        }
    }
}