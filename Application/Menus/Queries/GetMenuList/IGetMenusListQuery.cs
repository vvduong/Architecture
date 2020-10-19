using Architecture.Application.Menus.Queries.GetMenuDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.Application.Menus.Queries.GetMenuList
{
    public interface IGetMenusListQuery
    {
        List<MenuModel> Execute();
    }
}
