using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
