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

        public async Task<MovieEntity> UpdateRating(EstimationEntity estimation)
        {
            var existEstimation =
                await _estimationRepository.GetByUserIdAndMovieId(estimation.UserId, estimation.MovieId);
            // TODO продолжить валидацию 
        }
    }
}