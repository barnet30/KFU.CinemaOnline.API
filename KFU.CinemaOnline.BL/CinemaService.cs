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

        public Task CreateActor(ActorEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public Task CreateDirector(DirectorEntity entity)
        {
            throw new System.NotImplementedException();
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