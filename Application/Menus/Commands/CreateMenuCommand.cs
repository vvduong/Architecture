using Architecture.Application.Interfaces;
using Architecture.Application.Menus.Commands.CreateMenu.Factory;
using Architecture.Application.Menus.Queries.GetMenuList;
using Architecture.Common.Dates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.Application.Menus.Commands
{
    public class CreateMenuCommand : ICreateMenuCommand
    {
        private readonly IDateService _dateService;
        private readonly IDatabaseService _database;
        private readonly IMenuFactory _factory;

        public CreateMenuCommand(
           IDateService dateService,
           IDatabaseService database,
           IMenuFactory factory)
        {
            _dateService = dateService;
            _database = database;
            _factory = factory;
        }

        public void Execute(CreateMenuModel model)
        {
            var date = _dateService.GetDate();

            var menuModel = new MenuModel();
            menuModel.Id = Guid.NewGuid();
            menuModel.Name = model.Name;
            menuModel.Icon = model.Icon;
            menuModel.Url = model.Url;
            menuModel.Created = date;
            menuModel.Modified = date;
            menuModel.MenuType = model.MenuType;

            var menu = _factory.Create(menuModel);

            _database.Menus.Add(menu);

            _database.Save();
        }
    }
}
