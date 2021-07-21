using Architecture.Application.Menus.Queries.GetMenuList;
using Architecture.Domain.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.Application.Menus.Commands.CreateMenu.Factory
{
    public class MenuFactory : IMenuFactory
    {
        public Menu Create(MenusListItemModel menuModel)
        {
            var menu = new Menu();

            menu.Id = menuModel.Id.Value;

            menu.Name = menuModel.Name;

            menu.Icon = menuModel.Icon;

            menu.Url = menuModel.Url;

            menu.NoOrder = menuModel.NoOrder.Value;

            menu.Created = DateTime.Now;

            menu.Modified = DateTime.Now;

            menu.ParentId = menuModel.ParentId.Value;
            // Note: Total price is calculated in domain logic
            menu.CreatedBy = menuModel.CreatedBy.Value;
            menu.ModifiedBy = menuModel.ModifiedBy.Value;
            return menu;
        }
    }
}
