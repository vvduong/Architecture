using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.Application.Menus.Queries.GetMenuDetail
{
    public class MenuDetailModel
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public int? NoOrder { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        public string MenuType { get; set; }
    }
}
