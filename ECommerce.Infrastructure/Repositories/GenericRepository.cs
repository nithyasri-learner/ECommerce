using ECommerce.Application.Interfaces.Repositories;
using ECommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T: class
    {
        protected readonly ECommerceDbContext _context;
        public GenericRepository(ECommerceDbContext context) {
            _context = context; 
        }
        public async Task<T> GetbyIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public async Task AddAsync(T entity)
                => await _context.Set<T>().AddAsync(entity);
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
        public void Delete(T entity)
            => _context.Set<T>().Remove(entity);
    }
}
