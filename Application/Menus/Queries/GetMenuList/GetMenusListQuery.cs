using Architecture.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.Application.Menus.Queries.GetMenuList
{
    public class GetMenusListQuery : IGetMenusListQuery
    {
        private readonly IDatabaseService _database;

        public GetMenusListQuery(IDatabaseService database)
        {
            _database = database;
        }

        public List<MenuModel> Execute()
        {
            var menus = _database.Menus
                .Select(p => new MenuModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Icon = p.Icon,
                    Url = p.Url,
                    NoOrder = p.NoOrder,
                    Created = p.Created,
                    Modified = p.Modified,
                    MenuType = p.MenuType,
                });

            return menus.ToList();
        }
    }
}
