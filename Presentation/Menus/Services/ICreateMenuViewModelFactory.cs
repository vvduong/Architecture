using Architecture.Presentation.Menus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Architecture.Presentation.Menus.Services
{
    public interface ICreateMenuViewModelFactory
    {
        CreateMenuViewModel Create();
    }
}