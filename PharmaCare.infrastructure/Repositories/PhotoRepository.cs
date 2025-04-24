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
    public class PhotoRepository : GenericRepository<Photo>, IPhotoRepository
    {
        public PhotoRepository(AppDBContext db) : base(db)
        {
        }
    }
}
