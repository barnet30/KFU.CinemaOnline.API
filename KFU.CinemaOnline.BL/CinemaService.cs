using System.Collections.Generic;
using System.Threading.Tasks;
using KFU.CinemaOnline.Core.Cinema;

namespace KFU.CinemaOnline.BL
{
    public class CinemaService : ICinemaService
    {
        private readonly ICinemaRepository _cinemaRepository;

        public CinemaService(ICinemaRepository cinemaRepository)
        {
            _cinemaRepository = cinemaRepository;
        }

        public async Task CreateGenre(GenreEntity entity)
        {
            await _cinemaRepository.CreateGenreEntityAsync(entity);
        }

        public async Task CreateActor(ActorEntity entity)
        {
            await _cinemaRepository.CreateActorEntityAsync(entity);
        }

        public async Task CreateDirector(DirectorEntity entity)
        {
            await _cinemaRepository.CreateDirectorEntityAsync(entity);
        }

        public async Task CreateMovie(MovieEntity entity)
        {
            await _cinemaRepository.CreateMovieEntityAsync(entity);
        }

        public async Task<List<GenreEntity>> GetAllGenres()
        {
            return await _cinemaRepository.GetAllGenreEntitiesAsync();
        }

        public async Task<GenreEntity> GetGenreById(int id)
        {
            return await _cinemaRepository.GetGenreEntityByIdAsync(id);
        }

        public async Task<ActorEntity> GetActorById(int id)
        {
            return await _cinemaRepository.GetActorEntityByIdAsync(id);
        }

        public async Task<DirectorEntity> GetDirectorById(int id)
        {
            return await _cinemaRepository.GetDirectorEntityByIdAsync(id);
        }

        public async Task<MovieEntity> GetMovieById(int id)
        {
            return await _cinemaRepository.GetMovieEntityByIdAsync(id);
        }

        public async Task<ActorEntity> UpdateActor(ActorEntity actorEntity)
        {
            if (await _cinemaRepository.GetActorEntityByIdAsync(actorEntity.Id) == null)
            {
                return null;
            }
            return await _cinemaRepository.UpdateActorEntityAsync(actorEntity);
        }

        public async Task<GenreEntity> UpdateGenre(GenreEntity genreEntity)
        {
            if (await _cinemaRepository.GetGenreEntityByIdAsync(genreEntity.Id) == null)
            {
                return null;
            }
            return await _cinemaRepository.UpdateGenreEntityAsync(genreEntity);        }

        public async Task<DirectorEntity> UpdateDirector(DirectorEntity directorEntity)
        {
            if (await _cinemaRepository.GetDirectorEntityByIdAsync(directorEntity.Id) == null)
            {
                return null;
            }
            return await _cinemaRepository.UpdateDirectorEntityAsync(directorEntity);        }

        public async Task<MovieEntity> UpdateMovie(MovieEntity movieEntity)
        {
            if (await _cinemaRepository.GetMovieEntityByIdAsync(movieEntity.Id) == null)
            {
                return null;
            }
            return await _cinemaRepository.UpdateMovieEntityAsync(movieEntity);        }
    }
}