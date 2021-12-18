using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace KFU.CinemaOnline.Core.Sql
{
    public class EfRepository<T> : IEfRepository<T> where T: BaseEntity
    {
        private readonly EfDbContext _context;

        public EfRepository(EfDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> GetAllAsync()
        {
            return _context.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id).ConfigureAwait(false);
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);

            await _context.SaveChangesAsync().ConfigureAwait(false);
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            DetachLocal(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return entity;
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
                await DeleteAsync(entity).ConfigureAwait(false);
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        protected void DetachLocal(T entity)
        {
            var local = _context.Set<T>()
                .Local
                .FirstOrDefault(entry => entry.Id.Equals(entity.Id));
            if (local != null)
            {
                _context.Entry(local).State = EntityState.Detached;
            }
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
