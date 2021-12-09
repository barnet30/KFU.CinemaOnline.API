using System;

namespace KFU.CinemaOnline.API.Contracts.Cinema.Director
{
    public class DirectorCreate
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public string Country { get; set; }
        public DateTime BirthDate { get; set; }
        public string Description { get; set; }
    }
}