using System.Threading.Tasks;
using AutoMapper;
using KFU.CinemaOnline.API.Contracts.Cinema;
using KFU.CinemaOnline.Core.Cinema;
using Microsoft.AspNetCore.Mvc;

namespace KFU.CinemaOnline.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CinemaController : ControllerBase
    {
        private readonly ICinemaService _cinemaService;
        private readonly IMapper _mapper;
        public CinemaController(ICinemaService cinemaService, IMapper mapper)
        {
            _cinemaService = cinemaService;
            _mapper = mapper;
        }

        [HttpPost("genre")]
        public async Task CreateGenre(Genre genre)
        {
            await _cinemaService.CreateGenre(_mapper.Map<GenreEntity>(genre));
        }
    }
}