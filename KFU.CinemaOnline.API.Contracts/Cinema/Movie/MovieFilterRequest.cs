namespace KFU.CinemaOnline.API.Contracts.Cinema.Movie
{
    /// <summary>
    /// Filter parameters for movie list
    /// </summary>
    public class MovieFilterRequest : PagingSortParameters
    {
        public int? YearMax { get; set; }
        public int? YearMin { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }
}