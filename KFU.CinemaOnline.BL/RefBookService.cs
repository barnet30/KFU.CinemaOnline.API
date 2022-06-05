using System.Collections.Generic;
using System.Threading.Tasks;
using KFU.CinemaOnline.Core.RefBook;

namespace KFU.CinemaOnline.BL
{
    public class RefBookService : IRefBookService
    {
        private readonly IRefBookRepository _refBookRepository;

        public RefBookService(IRefBookRepository refBookRepository)
        {
            _refBookRepository = refBookRepository;
        }

        public async Task<IEnumerable<CountryRefEntity>> GetCountryEntities()
        {
            return await _refBookRepository.GetCountryEntities();
        }
    }
}