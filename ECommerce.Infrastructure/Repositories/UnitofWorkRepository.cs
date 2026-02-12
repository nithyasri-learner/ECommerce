using ECommerce.Application.Interfaces.Repositories;
using ECommerce.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Repositories
{
    public class UnitofWorkRepository : IUnitofWork
    {
        public readonly ECommerceDbContext _context;
        public ICategoryRepository Categoryrepo { get; }
        public IProductRepository Productrepo { get; }
        public UnitofWorkRepository(ECommerceDbContext context)
        {
            _context = context;
            Categoryrepo = new CategoryRepository(_context);
            Productrepo = new ProductRepository(_context);
        }
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
