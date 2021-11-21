using System;
using System.Linq;
using System.Threading.Tasks;
using KFU.CinemaOnline.DAL.Entities;

namespace KFU.CinemaOnline.DAL.Interfaces
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
