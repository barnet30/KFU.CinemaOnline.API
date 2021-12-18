using System.Threading.Tasks;
using KFU.CinemaOnline.Core.Cinema;

namespace KFU.CinemaOnline.Core.Estimation
{
    public interface IEstimationService
    {
        Task<MovieEntity> UpdateRating(EstimationEntity estimation);
    }
}