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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.ID).IsRequired();
            builder.Property(c => c.name).IsRequired().HasMaxLength(30);
            builder.HasData(
                new Category { description="Test description" , name = "test name" , ID=1}
                );
        }
    }
}
