using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using KFU.CinemaOnline.Core.Estimation;
using KFU.CinemaOnline.Core.Sql;

namespace KFU.CinemaOnline.DAL.Cinema
{
    public class EstimationRepository : EfRepository<EstimationEntity>, IEstimationRepository
    {
        private readonly CinemaDbContext _context;
        
        public EstimationRepository(CinemaDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<EstimationEntity> GetByUserIdAndMovieId(int userId, int movieId)
        {
            return await _context.Estimations.FirstOrDefaultAsync(x => x.UserId == userId && x.MovieId == movieId);
        }
    }
}