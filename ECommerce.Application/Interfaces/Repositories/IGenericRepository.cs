namespace ECommerce.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task AddAsync(T entity);  //Create
        Task<T> GetbyIdAsync(int id);  //Read
        Task<IEnumerable<T>> GetAllAsync(); //Read

        void Update(T entity);
        void Delete(T entity);

    }
}
