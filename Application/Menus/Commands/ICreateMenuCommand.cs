using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.Application.Menus.Commands
{
    public interface ICreateMenuCommand
    {
        void Execute(CreateMenuModel model);
    }
}
