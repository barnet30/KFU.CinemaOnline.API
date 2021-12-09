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

        public IEnumerable<GenreEntity> GetAllGenres()
        {
            return _cinemaRepository.GetAllGenreEntitiesAsync();
        }

        public async Task<MovieEntity> GetMovieById(int id)
        {
            var movie =  await _cinemaRepository.GetMovieEntityByIdAsync(id);
            return movie ?? null;
        }
    }
}