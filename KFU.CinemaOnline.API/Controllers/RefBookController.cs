using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using KFU.CinemaOnline.API.Contracts.Cinema.RefBook;
using KFU.CinemaOnline.Core.RefBook;
using Microsoft.AspNetCore.Mvc;

namespace KFU.CinemaOnline.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RefBookController : ControllerBase
    {
        private readonly IRefBookService _refBookService;
        private readonly IMapper _mapper;

        public RefBookController(IRefBookService refBookService, IMapper mapper)
        {
            _refBookService = refBookService;
            _mapper = mapper;
        }

        /// <summary>
        /// Справочник - страны производители
        /// </summary>
        /// <returns></returns>
        [HttpGet("countries")]
        public async Task<IEnumerable<CountryRef>> GetCountries()
        {
            var result = await _refBookService.GetCountryEntities();
            return _mapper.Map<IEnumerable<CountryRef>>(result);
        }
    }
}