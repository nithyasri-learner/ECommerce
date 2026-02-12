using ECommerce.Application.Interfaces.Repositories;
using ECommerce.Domain.Entities;
using ECommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Repositories
{
    public class CategoryRepository: GenericRepository<Category>, ICategoryRepository
    {
        private readonly ECommerceDbContext _context;
        public CategoryRepository(ECommerceDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Category>> GetAllWithProductsAsync()
                => await _context.Set<Category>().Include(x => x.Products).ToListAsync();
    }
}
