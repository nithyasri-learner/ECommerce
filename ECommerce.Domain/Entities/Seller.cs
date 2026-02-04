using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class Seller : BaseEntity
    {
        public string ShopName { get; set; }
        public ICollection<ProductSeller> ProductSellers { get; set; }
    }
}
