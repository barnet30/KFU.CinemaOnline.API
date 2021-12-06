using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using KFU.CinemaOnline.Core.Account;

namespace KFU.CinemaOnline.Core.Cinema
{
    public class MovieEntity 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public string MovieUrl { get; set; }
        public string ImageUrl { get; set; }
        
        public DirectorEntity Director { get; set; }
        public List<ActorEntity> Actors { get; set; } = new List<ActorEntity>();
        public List<GenreEntity> Genres { get; set; } = new List<GenreEntity>();
    }
}