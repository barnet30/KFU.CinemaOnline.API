using System.Collections.Generic;

namespace KFU.CinemaOnline.API.Contracts.Cinema.Movie
{
    /// <summary>
    /// Filter parameters for movie list
    /// </summary>
    public class MovieFilterRequest : PagingSortParameters
    {
        public int? YearTo { get; set; }
        public int? YearFrom { get; set; }
        public string Name { get; set; }
        public int? CountryId { get; set; }
        public List<int> Genres { get; set; }
    }
}