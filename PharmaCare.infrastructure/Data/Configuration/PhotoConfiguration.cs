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
    public class PhotoConfiguration:IEntityTypeConfiguration<Photo>
    {

        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.HasData(

                new Photo { ImageName = "test name", ID = 1, productId = 3 }
                );
        }
    }
}
