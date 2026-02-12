using ECommerce.Domain.Entities;

namespace ECommerce.Application.Interfaces.Repositories
{
    public interface IProductRepository: IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllByCategoryAsync(int CategoryId);
        Task<IEnumerable<Product>> GetProductsByCategorySPAsync(int categoryId);
        Task<IEnumerable<ProductDetailView>> GetProductDetailsAsync();
    }
}
