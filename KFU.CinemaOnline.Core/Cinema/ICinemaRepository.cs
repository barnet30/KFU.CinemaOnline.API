using System.Collections.Generic;
using System.Threading.Tasks;
using KFU.CinemaOnline.Common;
using KFU.CinemaOnline.Core.Account;

namespace KFU.CinemaOnline.Core.Cinema
{
    public interface ICinemaRepository
    {
        Task<ActorEntity> CreateActorEntityAsync(ActorEntity entity);
        Task<DirectorEntity> CreateDirectorEntityAsync(DirectorEntity entity);
        Task<GenreEntity> CreateGenreEntityAsync(GenreEntity entity);
        Task<MovieEntity> CreateMovieEntityAsync(MovieEntity entity);

        Task<List<GenreEntity>> GetAllGenreEntitiesAsync();
        Task<List<ActorEntity>> GetAllActorEntitiesAsync();
        Task<List<DirectorEntity>> GetAllDirectorEntitiesAsync();
        Task<List<MovieEntity>> GetAllMovieEntitiesAsync();


        Task<DirectorEntity> GetDirectorEntityByIdAsync(int id);
        Task<ActorEntity> GetActorEntityByIdAsync(int id);
        Task<GenreEntity> GetGenreEntityByIdAsync(int id);
        Task<MovieEntity> GetMovieEntityByIdAsync(int id);
        
        
        Task<ActorEntity> UpdateActorEntityAsync(ActorEntity entity);
        Task<GenreEntity> UpdateGenreEntityAsync(GenreEntity entity);
        Task<DirectorEntity> UpdateDirectorEntityAsync(DirectorEntity entity);
        Task<MovieEntity> UpdateMovieEntityAsync(MovieEntity entity);


        Task DeleteActorEntityByIdAsync(int id);
        Task DeleteGenreEntityByIdAsync(int id);
        Task DeleteDirectorEntityByIdAsync(int id);
        Task DeleteMovieEntityByIdAsync(int id);

        Task<PagingResult<MovieEntity>> GetQueryMoviesAsync(MovieFilterSettings filterSettings, Category category);
    }
}