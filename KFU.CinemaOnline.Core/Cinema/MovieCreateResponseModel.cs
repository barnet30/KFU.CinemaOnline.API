using KFU.CinemaOnline.Common;

namespace KFU.CinemaOnline.Core.Cinema
{
    public class MovieCreateResponseModel
    {
        public MovieEntity Movie { get; set; }
        public string ErrorMessage { get; set; }
    }
}