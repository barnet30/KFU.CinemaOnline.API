using System.Threading.Tasks;
using KFU.CinemaOnline.Core.Account;

namespace KFU.CinemaOnline.Core.Cinema
{
    public interface ICinemaRepository
    {
        Task<ActorEntity> CreateActorAsync(AccountEntity entity);
        Task<DirectorEntity> CreateDirectorAsync(DirectorEntity entity);
        Task<GenreEntity> CreateGenreAsync(GenreEntity entity);
        Task<MovieEntity> CreateMovieAsync(MovieEntity entity);

    }
}