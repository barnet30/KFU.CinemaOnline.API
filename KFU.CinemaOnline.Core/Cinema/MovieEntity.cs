using System.Collections.Generic;
using KFU.CinemaOnline.Core.Estimation;

namespace KFU.CinemaOnline.Core.Cinema
{
    public class MovieEntity : BaseEntity
    {
        public string Name { get; set; } // Наименование фильма
        public int CountryId { get; set; } // Идентификатор страны фильма
        public string Country { get; set; } // Страна фильма
        public int Year { get; set; } // Год выхода фильма
        public string Description { get; set; } // Описание фильма
        public string MovieUrl { get; set; } // Ссылка на фильм
        public string ImageUrl { get; set; } // Ссылка на постер фильма
        public double Rating { get; set; } // Рейтинг (от 0 до 10) фильма
        public int EstimationAmount { get; set; } // Количество оценок фильма
        
        public DirectorEntity Director { get; set; } // Ссылка на режиссёра 
        public List<ActorEntity> Actors { get; set; } // Ссылка на актёров
        public List<GenreEntity> Genres { get; set; } // Ссылка на жанры
        public List<EstimationEntity> Estimations { get; set; } // Ссылка на оценки
    }
}