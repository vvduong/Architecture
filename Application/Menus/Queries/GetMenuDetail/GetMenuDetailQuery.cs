using Architecture.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.Application.Menus.Queries.GetMenuDetail
{
    public class GetMenuDetailQuery : IGetMenuDetailQuery
    {
        private readonly IDatabaseService _database;

        public GetMenuDetailQuery(IDatabaseService database)
        {
            _database = database;
        }

        public MenuDetailModel Execute(Guid menuId)
        {
            var menu = _database.Menus
                .Where(p => p.Id == menuId)
                .Select(p => new MenuDetailModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Icon = p.Icon,
                    Url = p.Url,
                    NoOrder = p.NoOrder,
                    Created = p.Created,
                    Modified = p.Modified,
                    MenuType = p.MenuType,
                    ParentId = p.ParentId,
                })
                .Single();

            return menu;
        }
    }
}
