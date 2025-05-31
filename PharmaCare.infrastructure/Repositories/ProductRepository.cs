using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PharmaCare.Core.DTO;
using PharmaCare.Core.Entites.Products;
using PharmaCare.Core.Interfaces;
using PharmaCare.Core.Services;
using PharmaCare.infrastructure.Data;

namespace PharmaCare.infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly AppDBContext db;
        public readonly IMapper mapper;
        public readonly IImageManagmentService ims;
        public ProductRepository(AppDBContext db, IMapper mapper, IImageManagmentService ims) : base(db)
        {
            this.db = db;
            this.mapper = mapper;
            this.ims = ims;
        }

        public async Task<bool> AddAsync(AddProductDTO productDTO)
        {
            if (productDTO == null) return false;

            var product = mapper.Map<Product>(productDTO);
            await db.Products.AddAsync(product);
            await db.SaveChangesAsync();

            var imagePath = await ims.AddImage(productDTO.photos, productDTO.name);

            var image = imagePath.Select(p => new Photo
            {
                ImageName = p,
                productId = product.ID,
                
            }).ToList();

            db.Photos.AddRange(image);
            await db.SaveChangesAsync();
            return true;
        }
    }
}
