using System.Collections.Generic;
using KFU.CinemaOnline.Common;

namespace KFU.CinemaOnline.API.Contracts.Cinema.Movie
{
    public class Movie
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
        public double Rating { get; set; }
        public int EstimationAmount { get; set; }
        
        public Director.Director Director { get; set; }
        public List<Actor.Actor> Actors { get; set; } = new();
        public List<Genre.Genre> Genres { get; set; } = new();
    }
}