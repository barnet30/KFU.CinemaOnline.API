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

        public async Task<List<GenreEntity>> GetAllGenreEntitiesAsync()
        {
            return await _context.Genres.ToListAsync();
        }

        public async Task<List<ActorEntity>> GetAllActorEntitiesAsync()
        {
            return await _context.Actors.ToListAsync();
        }

        public async Task<List<DirectorEntity>> GetAllDirectorEntitiesAsync()
        {
            return await _context.Directors.ToListAsync();
        }

        public async Task<List<MovieEntity>> GetAllMovieEntitiesAsync()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<DirectorEntity> GetDirectorEntityByIdAsync(int id)
        {
            return await _context.Directors
                .Include(x => x.Movies)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ActorEntity> GetActorEntityByIdAsync(int id)
        {
            return await _context.Actors
                .Include(x => x.Movies)
                .FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<GenreEntity> GetGenreEntityByIdAsync(int id)
        {
            return await _context.Genres.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<MovieEntity> GetMovieEntityByIdAsync(int id)
        {
            return await _context.Movies
                .Include(x=>x.Genres)
                .Include(x=>x.Actors)
                .Include(x=>x.Director)
                .FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<ActorEntity> UpdateActorEntityAsync(ActorEntity entity)
        {
            var updateEntity = await _context.Actors.FirstOrDefaultAsync(x => x.Id == entity.Id);
            _context.Attach(updateEntity);
            _context.Entry(updateEntity).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return updateEntity;
        }

        public async Task<GenreEntity> UpdateGenreEntityAsync(GenreEntity entity)
        {
            var updateEntity = await _context.Genres.FirstOrDefaultAsync(x => x.Id == entity.Id);
            _context.Attach(updateEntity);
            _context.Entry(updateEntity).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return updateEntity;        }

        public async Task<DirectorEntity> UpdateDirectorEntityAsync(DirectorEntity entity)
        {
            var updateEntity = await _context.Directors.FirstOrDefaultAsync(x => x.Id == entity.Id);
            _context.Attach(updateEntity);
            _context.Entry(updateEntity).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return updateEntity;
        }

        public async Task<MovieEntity> UpdateMovieEntityAsync(MovieEntity entity)
        {
            var updateEntity = await _context.Movies
                .Include(x=>x.Genres)
                .Include(x=>x.Genres)
                .Include(x=>x.Director)
                .FirstOrDefaultAsync(x => x.Id == entity.Id);

            updateEntity.Actors = entity.Actors;
            updateEntity.Genres = entity.Genres;
            updateEntity.Director = entity.Director;
            _context.Attach(updateEntity);
            _context.Entry(updateEntity).CurrentValues.SetValues(entity);
            _context.Movies.Update(updateEntity);
            await _context.SaveChangesAsync();
            return updateEntity;
            
        }
    }
}