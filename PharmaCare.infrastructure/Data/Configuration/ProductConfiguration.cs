using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmaCare.Core.Entites.Products;

namespace PharmaCare.infrastructure.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            
            builder.Property(p=>p.name).IsRequired();
            builder.Property(p=>p.description).IsRequired();
            builder.Property(p=>p.price).IsRequired().HasColumnType("decimal(18,2)");
            builder.HasData(
                new Product { name = "test name", ID = 1 ,price = 12,categoryId=1,description="test description"}
                );
        }
    }
}
