using System.Threading.Tasks;

namespace KFU.CinemaOnline.Core.Cinema
{
    public interface ICinemaService
    {
        Task CreateGenre(GenreEntity entity);
    }
}