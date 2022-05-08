using System.Threading.Tasks;
using KFU.CinemaOnline.Core.Cinema;
using KFU.CinemaOnline.Core.Estimation;

namespace KFU.CinemaOnline.BL
{
    public class EstimationService : IEstimationService
    {
        private readonly IEstimationRepository _estimationRepository;
        private readonly ICinemaRepository _cinemaRepository;

        public EstimationService(IEstimationRepository estimationRepository, ICinemaRepository cinemaRepository)
        {
            _estimationRepository = estimationRepository;
            _cinemaRepository = cinemaRepository;
        }

        public async Task<MovieResponseModel> UpdateRating(EstimationEntity newEstimation)
        {
            var movie = await _cinemaRepository.GetMovieEntityByIdAsync(newEstimation.MovieId);
            if (movie == null)
            {
                return new MovieResponseModel
                {
                    Movie = null,
                    ErrorMessage = $"Movie with id {newEstimation.MovieId} doesn't exist"
                };
            }
            
            var existEstimation =
                await _estimationRepository.GetByUserIdAndMovieId(newEstimation.UserId, newEstimation.MovieId);

            MovieEntity newMovie;
            // оценка не существует, значит она создаётся
            if (existEstimation == null)
            {
                var rating = movie.Rating;
                var estimationAmount = movie.EstimationAmount;
                var newEstimationAmount = estimationAmount + 1;
                var newRating = (rating * estimationAmount + newEstimation.Estimation) / newEstimationAmount;

                movie.Rating = newRating;
                movie.EstimationAmount = newEstimationAmount;
                newMovie = await _cinemaRepository.UpdateMovieEntityAsync(movie);

                await _estimationRepository.CreateAsync(newEstimation);
            }
            
            // оценка существует, значит она изменяется
            else
            {
                var rating = movie.Rating;
                var estimationAmount = movie.EstimationAmount;
                var newRating = (rating * estimationAmount - existEstimation.Estimation +
                                 newEstimation.Estimation) / estimationAmount;

                movie.Rating = newRating;

                newMovie = await _cinemaRepository.UpdateMovieEntityAsync(movie);
                newEstimation.Id = existEstimation.Id;
                
                await _estimationRepository.UpdateAsync(newEstimation);
            }

            return new MovieResponseModel
            {
                Movie = newMovie
            };
        }

        public async Task<int?> GetUserEstimation(int userId, int movieId)
        {
            var estimation = await _estimationRepository.GetByUserIdAndMovieId(userId, movieId);

            return estimation?.Estimation;
        }
    }
}