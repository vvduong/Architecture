using Architecture.Domain.Menus;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.Persistence.Menus
{
    public class MenuConfiguration : EntityTypeConfiguration<Menu> 
    {
        public MenuConfiguration()
        {
            HasKey(p => p.Id);

            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(255);

            Property(p => p.Icon)
                .HasMaxLength(50);

            Property(p => p.Url)
                .HasMaxLength(255);

            Property(p => p.MenuType)
                .HasMaxLength(50);
        }
    }
}
