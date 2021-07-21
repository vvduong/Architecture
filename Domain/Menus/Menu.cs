using System;

namespace Architecture.Domain.Menus
{
    public class Menu
    {
        private DateTime _Created;
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public int NoOrder { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string MenuType { get; set; }
        public Guid ParentId { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }
    }
}
