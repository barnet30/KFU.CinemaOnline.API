using KFU.CinemaOnline.Core.Cinema;

namespace KFU.CinemaOnline.Core.Estimation
{
    public class EstimationEntity : BaseEntity
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public int Estimation { get; set; }
        
        public MovieEntity Movie { get; set; }
    }
}