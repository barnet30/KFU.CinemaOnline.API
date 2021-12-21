using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using KFU.CinemaOnline.Common;
using KFU.CinemaOnline.Core;
using KFU.CinemaOnline.Core.Cinema;
using LinqKit;
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

        public async Task<ActorEntity> CreateActorEntityAsync(ActorEntity entity)
        {
            await _context.Actors.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<DirectorEntity> CreateDirectorEntityAsync(DirectorEntity entity)
        {
            await _context.Directors.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<GenreEntity> CreateGenreEntityAsync(GenreEntity entity)
        {
            await _context.Genres.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<MovieEntity> CreateMovieEntityAsync(MovieEntity entity)
        {
            await _context.Movies.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
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
            return await _context.Movies
                .Include(x=>x.Actors)
                .Include(x=>x.Genres)
                .Include(x=>x.Director)
                .ToListAsync();
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

        public async Task DeleteActorEntityByIdAsync(int id)
        {
            var entity = await _context.Actors.FirstOrDefaultAsync(x=>x.Id == id);
            _context.Actors.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGenreEntityByIdAsync(int id)
        {
            var entity = await _context.Genres.FirstOrDefaultAsync(x=>x.Id == id);
            _context.Genres.Remove(entity);
            await _context.SaveChangesAsync();        }

        public async Task DeleteDirectorEntityByIdAsync(int id)
        {
            var entity = await _context.Directors.FirstOrDefaultAsync(x=>x.Id == id);
            _context.Directors.Remove(entity);
            await _context.SaveChangesAsync();        }

        public async Task DeleteMovieEntityByIdAsync(int id)
        {
            var entity = await _context.Movies.FirstOrDefaultAsync(x=>x.Id == id);
            _context.Movies.Remove(entity);
            await _context.SaveChangesAsync();        }

        public async Task<PagingResult<MovieEntity>> GetQueryMoviesAsync(MovieFilterSettings filterSettings)
        {
            if (filterSettings == null)
            {
                var total = await _context.Movies.CountAsync();
                if (total == 0)
                {
                    return PagingResult<MovieEntity>.Empty;
                }

                var items = await _context.Movies
                    .Take(PagingSettings.DefaultLimit)
                    .AsNoTracking()
                    .ToArrayAsync();

                return new PagingResult<MovieEntity>
                {
                    Total = total,
                    Items = items
                };
            }

            var table = _context.Movies
                .Include(x=>x.Actors)
                .Include(x=>x.Genres)
                .Include(x=>x.Director)
                .AsQueryable();
            var predicate = PredicateBuilder.New<MovieEntity>(true);

            predicate
                .And(filterSettings.Country, x => x.Country.Contains(filterSettings.Country))
                .And(filterSettings.Name, x => x.Name.Contains(filterSettings.Name))
                .And(filterSettings.YearMax, x => x.Year <= filterSettings.YearMax)
                .And(filterSettings.YearMin, x => x.Year >= filterSettings.YearMin)
                .And(filterSettings.Genres, x => x.Genres.Any(genre => filterSettings.Genres.Contains(genre.Id)));
            var query = table.Where(predicate);

            var sortColumns = filterSettings.SortColumn != null ? ResolveMovieSortColumn(filterSettings.SortColumn) : null;

         return await QueryItems(query, filterSettings, sortColumns);
        }

        private Expression<Func<MovieEntity, object>> ResolveMovieSortColumn(string sortColumn) =>
            sortColumn.ToLowerInvariant() switch
            {
                "year" => x => x.Year,
                "name" => x => x.Name,
                "county" => x => x.Country,
                _ => null
            };

        private async Task<PagingResult<TEntity>> QueryItems<TEntity>(IQueryable<TEntity> query,
            PagingSortSettings pagingSettings, Expression<Func<TEntity, object>> resolveSortColumns)
            where TEntity : BaseEntity 
        {
            var total = await query.CountAsync();
            if (total == 0)
                return PagingResult<TEntity>.Empty;
            
            if (pagingSettings.Limit == 0 || pagingSettings.Offset >= total)
                return new PagingResult<TEntity>
                {
                    Total = total,
                    Items = Array.Empty<TEntity>()
                };
            
            var items = await ApplySortSettings(query,pagingSettings,resolveSortColumns)
                .Skip(pagingSettings.Offset)
                .Take(pagingSettings.Limit)
                .AsNoTracking()
                .ToArrayAsync();
            
            return new PagingResult<TEntity>
            {
                Total = total,
                Items = items
            };
        }

        private IQueryable<TEntity> ApplySortSettings<TEntity>(IQueryable<TEntity> query,
            PagingSortSettings pagingSettings, Expression<Func<TEntity, object>> resolveSortColumns)
        {
            if (string.IsNullOrEmpty(pagingSettings.SortColumn))
                return query;

            if (resolveSortColumns == null)
                return query;

            return pagingSettings.SortOrder == SortOrder.Desc
                ? query.OrderByDescending(resolveSortColumns)
                : query.OrderBy(resolveSortColumns);
        }
    }
}