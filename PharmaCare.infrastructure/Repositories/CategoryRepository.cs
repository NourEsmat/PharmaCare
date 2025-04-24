using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.Core.Entites.Products;
using PharmaCare.Core.Interfaces;
using PharmaCare.infrastructure.Data;

namespace PharmaCare.infrastructure.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDBContext db) : base(db)
        {
        }
    }
}
