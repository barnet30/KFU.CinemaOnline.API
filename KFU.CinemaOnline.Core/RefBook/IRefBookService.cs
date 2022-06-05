using System.Collections.Generic;
using System.Threading.Tasks;

namespace KFU.CinemaOnline.Core.RefBook
{
    public interface IRefBookService
    {
        Task<IEnumerable<CountryRefEntity>> GetCountryEntities();
    }
}