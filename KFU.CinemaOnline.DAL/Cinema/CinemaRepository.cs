using System.Threading.Tasks;
using KFU.CinemaOnline.Core.Account;
using KFU.CinemaOnline.Core.Cinema;

namespace KFU.CinemaOnline.DAL.Cinema
{
    public class CinemaRepository : ICinemaRepository
    {
        private readonly CinemaDbContext _context;

        public CinemaRepository(CinemaDbContext context)
        {
            _context = context;
        }

        public Task CreateActorAsync(AccountEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public Task CreateDirectorAsync(DirectorEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task CreateGenreAsync(GenreEntity entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public Task CreateMovieAsync(MovieEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}