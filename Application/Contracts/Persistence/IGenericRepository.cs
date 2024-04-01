namespace Assesment.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Add(T entity);
        Task Delete(T entity);
        Task Update(T entity);
        Task<T> Find(string entity);
    }
}
