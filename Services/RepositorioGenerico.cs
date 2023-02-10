using Bodega.Data;
using Microsoft.EntityFrameworkCore;

namespace Bodega.Domain.Services
{
    public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T : class
    {
        protected BodegaContext _context;
        internal DbSet<T> _dbSet;
        public RepositorioGenerico(BodegaContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual async void Delete(int id)
        {
            var entity = await _dbSet.FindAsync(id);

            if (entity != null)
                throw new Exception($"La entidad con el id {id.ToString()} no existe");

            _dbSet.Remove(entity);
        }

        public virtual async Task<IEnumerable<T>> GetAllSync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        void IRepositorioGenerico<T>.Add(T entity)
        {
            throw new NotImplementedException();
        }

        void IRepositorioGenerico<T>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<T>> IRepositorioGenerico<T>.GetAllSync()
        {
            throw new NotImplementedException();
        }

        Task<T> IRepositorioGenerico<T>.GetByIdAsybc(int id)
        {
            throw new NotImplementedException();
        }

        void IRepositorioGenerico<T>.Update(T entity)
        {
            throw new NotImplementedException();
        }
    }

}
