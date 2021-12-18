using System.Threading.Tasks;

namespace KFU.CinemaOnline.Core.Estimation
{
    public interface IEstimationRepository : IEfRepository<EstimationEntity>
    {
        Task<EstimationEntity> GetByUserIdAndMovieId(int userId, int movieId);
    }
}