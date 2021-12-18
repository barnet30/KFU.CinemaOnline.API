using System.Threading.Tasks;
using KFU.CinemaOnline.Core.Cinema;

namespace KFU.CinemaOnline.Core.Estimation
{
    public interface IEstimationService
    {
        Task<MovieResponseModel> UpdateRating(EstimationEntity estimation);
    }
}