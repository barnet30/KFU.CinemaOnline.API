using System;

namespace KFU.CinemaOnline.API.Contracts.Cinema.Actor
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public int CountryId { get; set; }
        public string Country { get; set; }
        public DateTime BirthDate { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}