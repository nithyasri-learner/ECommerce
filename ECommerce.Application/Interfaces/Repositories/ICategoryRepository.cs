using ECommerce.Domain.Entities;

namespace ECommerce.Application.Interfaces.Repositories
{
    public interface ICategoryRepository: IGenericRepository<Category>
    {
        Task<IEnumerable<Category>> GetAllWithProductsAsync();
    }
}
