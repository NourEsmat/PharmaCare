using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaCare.Core.Entites.Products
{
    public class Category:BaseEntity<int>
    {
        public string name { get; set; }
        public string description { get; set; }
        public ICollection<Product> products{ get; set; } = new HashSet<Product>();
    }
}
