using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.Core.DTO;
using PharmaCare.Core.Entites.Products;

namespace PharmaCare.Core.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<bool> AddAsync(AddProductDTO productDTO);
        
    }
}
