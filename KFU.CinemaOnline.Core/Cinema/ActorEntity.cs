using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace KFU.CinemaOnline.Core.Cinema
{
    public class ActorEntity : BaseEntity
    {
        public string Name { get; set; }    // Имя актёра
        public string LastName { get; set; } // Фамилия актёра
        public string ImageUrl { get; set; } // Ссылка на фотографию актёра
        public int CountryId { get; set; } // Идентификатор страны рождения
        public string Country { get; set; } // Страна рождения
        public DateTime BirthDate { get; set; } // Дата рождения
        public string Description { get; set; } // Описание

        public List<MovieEntity> Movies { get; set; } // Ссылка на фильмы
    }
}