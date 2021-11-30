using System;
using System.Linq;
using System.Threading.Tasks;

namespace KFU.CinemaOnline.Core
{
    public interface IEfRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteByIdAsync(Guid id);
        Task DeleteAsync(T entity);
    }
}
