using System.Collections.Generic;
using KFU.CinemaOnline.Common;

namespace KFU.CinemaOnline.Core.Cinema
{
    public class MovieFilterSettings : PagingSortSettings
    {
        public int? YearTo { get; set; }
        public int? YearFrom { get; set; }
        public string Name { get; set; }
        public int? CountryId { get; set; }
        public List<int> Genres { get; set; } 
    }
}