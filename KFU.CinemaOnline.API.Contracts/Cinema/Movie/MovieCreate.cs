using System.Collections.Generic;

namespace KFU.CinemaOnline.API.Contracts.Cinema.Movie
{
    public class MovieCreate
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public string MovieUrl { get; set; }
        public string ImageUrl { get; set; }

        public IEnumerable<int> Genres { get; set; }
    }
}