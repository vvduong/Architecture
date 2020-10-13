using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using Architecture.Domain.Products;

namespace Architecture.Persistence.Products
{
    public class ProductConfiguration
           : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            HasKey(p => p.Id);

            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            Property(p => p.Price)
                .IsRequired()
                .HasPrecision(5, 2);
        }
    }
}
