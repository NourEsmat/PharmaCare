using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaCare.Core.Entites.Products
{
    public class Photo:BaseEntity<int>
    {
        public string ImageName { get; set; }
        public int productId { get; set; }
        [ForeignKey(nameof(productId))]
        public virtual Product Product { get; set; }
    }
}
