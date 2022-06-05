using System;
using System.Collections.Generic;
using KFU.CinemaOnline.Common;

namespace KFU.CinemaOnline.API.Contracts.Cinema.Movie
{
    public class MovieItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int CountryId { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public Category Category { get; set; }
        
        public double Rating { get; set; }
        public int EstimationAmount { get; set; }

        public List<Genre.Genre> Genres { get; set; } = new();
    }
}