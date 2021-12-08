using System.Collections.Generic;
using System.Threading.Tasks;

namespace KFU.CinemaOnline.Core.Cinema
{
    public interface ICinemaService
    {
        Task CreateGenre(GenreEntity entity);
        Task CreateActor(ActorEntity entity);
        Task CreateDirector(DirectorEntity entity);
        Task CreateMovie(MovieEntity entity);

        IEnumerable<GenreEntity> GetAllGenres();


        Task<MovieEntity> GetMovieById(int id);
    }
}