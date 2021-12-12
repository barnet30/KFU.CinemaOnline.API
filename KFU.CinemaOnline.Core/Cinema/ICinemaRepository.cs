using System.Collections.Generic;
using System.Threading.Tasks;
using KFU.CinemaOnline.Core.Account;

namespace KFU.CinemaOnline.Core.Cinema
{
    public interface ICinemaRepository
    {
        Task CreateActorEntityAsync(ActorEntity entity);
        Task CreateDirectorEntityAsync(DirectorEntity entity);
        Task CreateGenreEntityAsync(GenreEntity entity);
        Task CreateMovieEntityAsync(MovieEntity entity);

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

    }
}