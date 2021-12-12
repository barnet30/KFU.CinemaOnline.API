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

        Task<List<GenreEntity>> GetAllGenres();
        Task<List<ActorEntity>> GetAllActors();
        Task<List<DirectorEntity>> GetAllDirectors();
        Task<List<MovieEntity>> GetAllMovies();


        Task<GenreEntity> GetGenreById(int id);
        Task<ActorEntity> GetActorById(int id);
        Task<DirectorEntity> GetDirectorById(int id);
        Task<MovieEntity> GetMovieById(int id);


        Task<ActorEntity> UpdateActor(ActorEntity actorEntity);
        Task<GenreEntity> UpdateGenre(GenreEntity genreEntity);
        Task<DirectorEntity> UpdateDirector(DirectorEntity directorEntity);
        Task<MovieEntity> UpdateMovie(MovieEntity actorEntity);


        Task DeleteGenreById(int id);
        Task DeleteDirectorById(int id);
        Task DeleteActorById(int id);
        Task DeleteMovieById(int id);

    }
}