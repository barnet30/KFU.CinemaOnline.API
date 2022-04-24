using System.Collections.Generic;
using System.Threading.Tasks;

namespace KFU.CinemaOnline.Core.RefBook
{
    public interface IRefBookRepository
    {
        Task<IEnumerable<CountryRefEntity>> GetCountryEntities();
    }
}