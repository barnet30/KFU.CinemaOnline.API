using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace KFU.CinemaOnline.Core.Cinema
{
    public class ActorEntity : BaseCinemaEntity
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