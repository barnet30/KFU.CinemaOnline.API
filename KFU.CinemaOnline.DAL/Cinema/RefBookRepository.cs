using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KFU.CinemaOnline.Core.RefBook;
using Microsoft.EntityFrameworkCore;

namespace KFU.CinemaOnline.DAL.Cinema
{
    public class RefBookRepository : IRefBookRepository
    {
        private readonly CinemaDbContext _dbContext;

        public RefBookRepository(CinemaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CountryRefEntity>> GetCountryEntities()
        {
            return await _dbContext.CountryRefEntities
                .OrderBy(x=>x.Name)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}