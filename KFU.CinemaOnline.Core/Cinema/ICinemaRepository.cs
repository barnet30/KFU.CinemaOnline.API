using System.Threading.Tasks;
using KFU.CinemaOnline.Core.Account;

namespace KFU.CinemaOnline.Core.Cinema
{
    public interface ICinemaRepository
    {
        Task CreateActorAsync(AccountEntity entity);
        Task CreateDirectorAsync(DirectorEntity entity);
        Task CreateGenreAsync(GenreEntity entity);
        Task CreateMovieAsync(MovieEntity entity);

    }
}