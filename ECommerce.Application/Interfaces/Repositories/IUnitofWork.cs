namespace ECommerce.Application.Interfaces.Repositories
{
    public interface IUnitofWork
    {
        ICategoryRepository Categoryrepo { get; }
        IProductRepository Productrepo { get; }

        Task SaveChanges();
    }
}
