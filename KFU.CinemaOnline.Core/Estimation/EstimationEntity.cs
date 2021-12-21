using KFU.CinemaOnline.Core.Cinema;

namespace KFU.CinemaOnline.Core.Estimation
{
    public class EstimationEntity : BaseEntity
    {
        public int UserId { get; set; } // Уникальный идентификатор пользователя
        public int MovieId { get; set; } // Уникальный идентификатор фильма
        public int Estimation { get; set; } // Оценка (целое число)
        
        public MovieEntity Movie { get; set; } // Ссылка на фильм
    }
}