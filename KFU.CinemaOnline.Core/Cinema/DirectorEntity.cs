using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace KFU.CinemaOnline.Core.Cinema
{
    public class DirectorEntity  : BaseEntity
    {
        public string Name { get; set; } // Имя режиссёра
        public string LastName { get; set; } // Фамилия режиссёра
        public string ImageUrl { get; set; } // Ссылка на фотографию режиссёра
        public string Country { get; set; } // Страна рождения
        public DateTime BirthDate { get; set; } // Дата рождения
        public string Description { get; set; } // Описание
        
        public List<MovieEntity> Movies { get; set; } // Ссылка на фильмы
    }
}