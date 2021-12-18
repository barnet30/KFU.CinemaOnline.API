using KFU.CinemaOnline.Common;

namespace KFU.CinemaOnline.Core.Cinema
{
    public class MovieFilterSettings : PagingSortSettings
    {
        public int? YearMax { get; set; }
        public int? YearMin { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }
}