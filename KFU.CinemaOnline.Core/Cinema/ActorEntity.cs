using System;
using System.Collections.Generic;

namespace KFU.CinemaOnline.Core.Cinema
{
    public class ActorEntity : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public string Country { get; set; }
        public DateTime BirthDate { get; set; }
        public string Description { get; set; }

        public List<MovieEntity> Movies { get; set; } = new List<MovieEntity>();
    }
}