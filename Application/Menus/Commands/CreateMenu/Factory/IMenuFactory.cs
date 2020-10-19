using Architecture.Application.Menus.Queries.GetMenuList;
using Architecture.Domain.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.Application.Menus.Commands.CreateMenu.Factory
{
    public interface IMenuFactory
    {
        Menu Create(MenusListItemModel menuModel);
    }
}
