using ECommerce.Application.Interfaces.Repositories;
using ECommerce.Domain.Entities;
using ECommerce.Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly ECommerceDbContext _context;
        public ProductRepository(ECommerceDbContext context): base(context) {
            _context= context;
        }
        public async Task<IEnumerable<Product>> GetAllByCategoryAsync(int CategoryId)
            => await _context.Set<Product>().Where(p => p.CategoryId == CategoryId).ToListAsync();

        public async Task<IEnumerable<Product>> GetProductsByCategorySPAsync(int categoryId)
        {
            return await _context.Set<Product>()
                .FromSqlRaw("EXEC GetProductsByCategory @CategoryId",
                    new SqlParameter("@CategoryId", categoryId))
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductDetailView>> GetProductDetailsAsync()
        {
            return await _context.ProductDetails.AsNoTracking().ToListAsync();
        }
    }
}
