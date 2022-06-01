using System;

namespace KFU.CinemaOnline.API.Contracts.Cinema.Genre
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}