using System.Collections.Generic;
using System.Threading.Tasks;
using KFU.CinemaOnline.Core.Account;

namespace KFU.CinemaOnline.Core.Cinema
{
    public interface ICinemaRepository
    {
        Task CreateActorEntityAsync(AccountEntity entity);
        Task CreateDirectorEntityAsync(DirectorEntity entity);
        Task CreateGenreEntityAsync(GenreEntity entity);
        Task CreateMovieEntityAsync(MovieEntity entity);

        IEnumerable<GenreEntity> GetAllGenreEntitiesAsync();
        IEnumerable<ActorEntity> GetAllActorEntitiesAsync();
        IEnumerable<DirectorEntity> GetAllDirectorEntitiesAsync();
        IEnumerable<MovieEntity> GetAllMovieEntitiesAsync();


        Task<MovieEntity> GetMovieEntityByIdAsync(int id);
        
        Task<AccountEntity> UpdateActorEntityAsync(int entityId, ActorEntity entity);

    }
}