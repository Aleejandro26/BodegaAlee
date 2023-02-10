namespace Bodega.Domain.Services
{
    public interface IRepositorioGenerico<T> where T : class
    {
        Task<IEnumerable<T>> GetAllSync();

        Task<T> GetByIdAsybc(int id);

        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
