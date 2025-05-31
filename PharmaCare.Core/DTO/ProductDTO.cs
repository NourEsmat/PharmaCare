using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PharmaCare.Core.Entites.Products;

namespace PharmaCare.Core.DTO
{
    public record ProductDTO
    {
        public string name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public virtual List<PhotoDTO> photos { get; set; }
        public string CategoryName { get; set; }
    }

    public record AddProductDTO
    {
        public string name { get; set; }
        public string description { get; set; }
        public decimal NewPrice { get; set; }
        public decimal OldPrice { get; set; }
        public int categoryId { get; set; }
        public IFormFileCollection photos { get; set; }
    }
}
