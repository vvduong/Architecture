using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.Application.Menus.Queries.GetMenuDetail
{
    public interface IGetMenuDetailQuery
    {
        MenuDetailModel Execute(Guid Id);
    }
}
