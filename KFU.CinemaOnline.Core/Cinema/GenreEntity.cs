using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace KFU.CinemaOnline.Core.Cinema
{
    public class GenreEntity : BaseEntity
    {
        public string Name { get; set; } // Наименование жанра
        public string Description { get; set; } // Описание жанра
 
        public List<MovieEntity> Movies { get; set; } = new List<MovieEntity>(); // Ссылка на фильмы
    }
}