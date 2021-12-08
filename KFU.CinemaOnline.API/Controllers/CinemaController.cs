using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using KFU.CinemaOnline.API.Contracts.Cinema;
using KFU.CinemaOnline.Common;
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
        public async Task CreateGenre([FromBody] GenreCreate genre)
        {
            await _cinemaService.CreateGenre(_mapper.Map<GenreEntity>(genre));
        }

        [HttpPost("movie")]
        public async Task CreateMovieAsync([FromBody] CreateMovieInput newMovie)
        {
            var genres = new List<GenreEntity>();
            foreach (var genreId in newMovie.Genres)
            {
                var genre = _cinemaService.GetAllGenres().FirstOrDefault(x => x.Id == genreId);
                if (genre == null)
                {
                    ErrorResponse.GenerateError(HttpStatusCode.NotFound, $"Genre with id {genreId} not found");
                }

                if (genres.Contains(genre))
                {
                    ErrorResponse.GenerateError(HttpStatusCode.BadRequest, "Genres can not be repeated");
                }
                
                genres.Add(genre);
            }
            
            //TODO сделать валидацию на актёров

            var createdMovie = new MovieEntity
            {
                Name = newMovie.Name,
                Year = newMovie.Year,
                Country = newMovie.Country,
                Description = newMovie.Description,
                ImageUrl = newMovie.ImageUrl,
                MovieUrl = newMovie.MovieUrl,
                Director = null,
                Genres = genres,
                Actors = null
            };

            await _cinemaService.CreateMovie(createdMovie);
        }


        [HttpGet("movie/{id:int}")]
        [ProducesResponseType(typeof(ErrorModel), (int) HttpStatusCode.NotFound)]
        public async Task<ActionResult<Movie>> GetMovieById([FromRoute]int id)
        {
            var movie = await _cinemaService.GetMovieById(id);

            if (movie == null)
            {
                ErrorResponse.GenerateError(HttpStatusCode.NotFound,$"Movie with id {id} not found");
            }

            return _mapper.Map<Movie>(movie);
        }
    }
}