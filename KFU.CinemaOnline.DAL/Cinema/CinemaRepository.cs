using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KFU.CinemaOnline.Core.Account;
using KFU.CinemaOnline.Core.Cinema;
using Microsoft.EntityFrameworkCore;

namespace KFU.CinemaOnline.DAL.Cinema
{
    public class CinemaRepository : ICinemaRepository
    {
        private readonly CinemaDbContext _context;

        public CinemaRepository(CinemaDbContext context)
        {
            _context = context;
        }

        public async Task CreateActorEntityAsync(ActorEntity entity)
        {
            await _context.Actors.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task CreateDirectorEntityAsync(DirectorEntity entity)
        {
            await _context.Directors.AddAsync(entity);
            await _context.SaveChangesAsync();        }

        public async Task CreateGenreEntityAsync(GenreEntity entity)
        {
            await _context.Genres.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task CreateMovieEntityAsync(MovieEntity entity)
        {
            await _context.Movies.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<GenreEntity> GetAllGenreEntitiesAsync()
        {
            return  _context.Genres.ToList();
        }

        public IEnumerable<ActorEntity> GetAllActorEntitiesAsync()
        {
            return _context.Actors.ToList();
        }

        public IEnumerable<DirectorEntity> GetAllDirectorEntitiesAsync()
        {
            return _context.Directors.ToList();
        }

        public IEnumerable<MovieEntity> GetAllMovieEntitiesAsync()
        {
            return _context.Movies.ToList();
        }

        public async Task<MovieEntity> GetMovieEntityByIdAsync(int id)
        {
            return await _context.Movies.Include(x=>x.Genres).FirstOrDefaultAsync(x=>x.Id == id);
        }

        public Task<AccountEntity> UpdateActorEntityAsync(int entityId, ActorEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}