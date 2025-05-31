using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PharmaCare.Core.Interfaces;
using PharmaCare.Core.Services;
using PharmaCare.infrastructure.Data;
using PharmaCare.infrastructure.Repositories.Service;

namespace PharmaCare.infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext _db;
        private readonly IMapper mapper;
        private readonly IImageManagmentService ims;

        public ICategoryRepository categoryRepository {get;}

        public IProductRepository productRepository { get; }

        public IPhotoRepository photoRepository { get; }

        public UnitOfWork(AppDBContext db, IMapper mapper, IImageManagmentService ims)
        {
            _db = db;
            this.mapper = mapper;
            this.ims = ims;

            categoryRepository = new CategoryRepository(db);
            productRepository = new ProductRepository(db,mapper,ims);
            photoRepository = new PhotoRepository(db);
            
        }
    }
}
