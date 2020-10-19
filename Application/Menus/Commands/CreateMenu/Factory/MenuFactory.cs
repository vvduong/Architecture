using Architecture.Application.Menus.Queries.GetMenuList;
using Architecture.Domain.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.Application.Menus.Commands.CreateMenu.Factory
{
    class MenuFactory : IMenuFactory
    {
        public Menu Create(MenuModel menuModel)
        {
            var menu = new Menu();

            menu.Name = menuModel.Name;

            menu.Icon = menuModel.Icon;

            menu.Url = menuModel.Url;

            menu.NoOrder = menuModel.NoOrder.Value;

            menu.Created = DateTime.Now;

            menu.Modified = DateTime.Now;

            // Note: Total price is calculated in domain logic

            return menu;
        }
    }
}
