using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.Core.Interfaces;
using PharmaCare.infrastructure.Data;

namespace PharmaCare.infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext _db;

        public ICategoryRepository categoryRepository {get;}

        public IProductRepository productRepository { get; }

        public IPhotoRepository photoRepository { get; }

        public UnitOfWork(AppDBContext db)
        {
            _db = db;
            categoryRepository = new CategoryRepository(db);
            productRepository = new ProductRepository(db);
            photoRepository = new PhotoRepository(db);
        }
    }
}
