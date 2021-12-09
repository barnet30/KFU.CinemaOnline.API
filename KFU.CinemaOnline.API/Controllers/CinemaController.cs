using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using KFU.CinemaOnline.API.Contracts.Cinema;
using KFU.CinemaOnline.API.Contracts.Cinema.Actor;
using KFU.CinemaOnline.API.Contracts.Cinema.Director;
using KFU.CinemaOnline.API.Contracts.Cinema.Genre;
using KFU.CinemaOnline.API.Contracts.Cinema.Movie;
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

        /// <summary>
        /// Add new genre
        /// </summary>
        /// <param name="genre"></param>
        [HttpPost("genre")]
        public async Task CreateGenreAsync([FromBody] GenreCreate genre)
        {
            await _cinemaService.CreateGenre(_mapper.Map<GenreEntity>(genre));
        }

        /// <summary>
        /// Add new actor
        /// </summary>
        /// <param name="newActor"></param>
        [HttpPost("actor")]
        public async Task CreateActorAsync([FromBody] ActorCreate newActor)
        {
            await _cinemaService.CreateActor(_mapper.Map<ActorEntity>(newActor));
        }

        [HttpPost("director")]
        public async Task CreateDirectorAsync([FromBody] DirectorCreate newDirector)
        {
            await _cinemaService.CreateDirector(_mapper.Map<DirectorEntity>(newDirector));
        }
        
        /// <summary>
        /// Add new movie
        /// </summary>
        /// <param name="newMovie"></param>
        [HttpPost("movie")]
        public async Task CreateMovieAsync([FromBody] MovieCreate newMovie)
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

        
        /// <summary>
        /// Get movie by <paramref name="id"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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