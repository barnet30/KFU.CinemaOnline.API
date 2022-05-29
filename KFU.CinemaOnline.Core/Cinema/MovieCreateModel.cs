using System.Collections.Generic;

namespace KFU.CinemaOnline.Core.Cinema
{
    public class MovieCreateModel
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
        public string Country { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public string MovieUrl { get; set; }
        public string ImageUrl { get; set; }
        

        public int DirectorId { get; set; }
        public IEnumerable<int> Actors { get; set; }
        public IEnumerable<int> Genres { get; set; }
    }
}