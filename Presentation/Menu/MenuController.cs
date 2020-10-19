using Architecture.Application.Menus.Commands;
using Architecture.Application.Menus.Queries.GetMenuDetail;
using Architecture.Application.Menus.Queries.GetMenuList;
using Architecture.Presentation.Menus.Models;
using Architecture.Presentation.Menus.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Architecture.Presentation.Menus
{
    [RoutePrefix("admin/menus")]
    public class MenuController : Controller
    {
        private readonly IGetMenusListQuery _menusListQuery;
        private readonly IGetMenuDetailQuery _menuDetailQuery;
        private readonly ICreateMenuViewModelFactory _factory;
        private readonly ICreateMenuCommand _createCommand;

        public MenuController(
            IGetMenusListQuery menusListQuery,
            IGetMenuDetailQuery menuDetailQuery,
            ICreateMenuViewModelFactory factory,
            ICreateMenuCommand createCommand)
        {
            _menusListQuery = menusListQuery;
            _menuDetailQuery = menuDetailQuery;
            _factory = factory;
            _createCommand = createCommand;
        }
        [Route("")]
        public ViewResult Index()
        {
            var menus = _menusListQuery.Execute();

            return View(menus);
        }

        [Route("{id:guid}")]
        public ViewResult Detail(Guid id)
        {
            var menu = _menuDetailQuery.Execute(id);

            return View(menu);
        }

        [Route("create")]
        public ViewResult Create()
        {
            var viewModel = _factory.Create();

            return View(viewModel);
        }

        [Route("create")]
        [HttpPost]
        public RedirectToRouteResult Create(CreateMenuViewModel viewModel)
        {
            var model = viewModel.Menu;

            _createCommand.Execute(model);

            return RedirectToAction("index", "menus");
        }
    }
}