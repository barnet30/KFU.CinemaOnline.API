using System.Collections.Generic;
using KFU.CinemaOnline.Common;

namespace KFU.CinemaOnline.Core.Cinema
{
    public class MovieUpdateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public string Country { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public string MovieUrl { get; set; }
        public string ImageUrl { get; set; }
        public Category Category { get; set; }

        public int DirectorId { get; set; }
        public IEnumerable<int> Actors { get; set; }
        public IEnumerable<int> Genres { get; set; }
    }
}