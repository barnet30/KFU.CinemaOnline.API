using System.Collections.Generic;
using System.Threading.Tasks;
using KFU.CinemaOnline.Common;

namespace KFU.CinemaOnline.Core.Cinema
{
    public interface ICinemaService
    {
        Task<GenreEntity> CreateGenre(GenreEntity entity);
        Task<ActorEntity> CreateActor(ActorEntity entity);
        Task<DirectorEntity> CreateDirector(DirectorEntity entity);
        Task<MovieResponseModel> CreateMovie(MovieCreateModel entity);

        Task<List<GenreEntity>> GetAllGenres();
        Task<List<ActorEntity>> GetAllActors();
        Task<List<DirectorEntity>> GetAllDirectors();
        Task<PagingResult<MovieEntity>> GetFilteredMovies(MovieFilterSettings filter);


        Task<GenreEntity> GetGenreById(int id);
        Task<ActorEntity> GetActorById(int id);
        Task<DirectorEntity> GetDirectorById(int id);
        Task<MovieEntity> GetMovieById(int id);


        Task<ActorEntity> UpdateActor(ActorEntity actorEntity);
        Task<GenreEntity> UpdateGenre(GenreEntity genreEntity);
        Task<DirectorEntity> UpdateDirector(DirectorEntity directorEntity);
        Task<MovieResponseModel> UpdateMovie(MovieUpdateModel updateModel);


        Task DeleteGenreById(int id);
        Task DeleteDirectorById(int id);
        Task DeleteActorById(int id);
        Task DeleteMovieById(int id);
    }
}