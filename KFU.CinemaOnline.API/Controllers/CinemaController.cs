using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using KFU.CinemaOnline.API.Contracts.Cinema;
using KFU.CinemaOnline.API.Contracts.Cinema.Actor;
using KFU.CinemaOnline.API.Contracts.Cinema.Director;
using KFU.CinemaOnline.API.Contracts.Cinema.Genre;
using KFU.CinemaOnline.API.Contracts.Cinema.Movie;
using KFU.CinemaOnline.Common;
using KFU.CinemaOnline.Core.Cinema;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KFU.CinemaOnline.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CinemaController : ControllerBase
    {
        private readonly ICinemaService _cinemaService;
        private readonly IMapper _mapper;

        private Guid UserId => Guid.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);
        
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
        [Authorize(Roles = "Admin")]
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

        /// <summary>
        /// Add new Director (режиссёр)
        /// </summary>
        /// <param name="newDirector"></param>
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
            var director = await _cinemaService.GetDirectorById(newMovie.DirectorId);
            if (director == null)
            {
                ErrorResponse.GenerateError(HttpStatusCode.NotFound,
                    $"Director with id {newMovie.DirectorId} not found");
            }
            
            var genres = new List<GenreEntity>();
            foreach (var genreId in newMovie.Genres)
            {
                var genre = await _cinemaService.GetGenreById(genreId);
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

            var actors = new List<ActorEntity>();
            foreach (var actorId in newMovie.Actors)
            {
                var actor = await _cinemaService.GetActorById(actorId);
                if (actor == null)
                {
                    ErrorResponse.GenerateError(HttpStatusCode.NotFound, $"Actor with id {actorId} not found");
                }

                if (actors.Contains(actor))
                {
                    ErrorResponse.GenerateError(HttpStatusCode.BadRequest, "Actors can not be repeated");
                }

                actors.Add(actor);
            }
            
            var createdMovie = new MovieEntity
            {
                Name = newMovie.Name,
                Year = newMovie.Year,
                Country = newMovie.Country,
                Description = newMovie.Description,
                ImageUrl = newMovie.ImageUrl,
                MovieUrl = newMovie.MovieUrl,
                Director = director,
                Genres = genres,
                Actors = actors
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
        public async Task<Movie> GetMovieByIdAsync([FromRoute]int id)
        {
            var movie = await _cinemaService.GetMovieById(id);

            if (movie == null)
            {
                ErrorResponse.GenerateError(HttpStatusCode.NotFound,$"Movie with id {id} not found");
                //return NotFound($"Movie with id {id} not found");
            }

            return _mapper.Map<Movie>(movie);
        }

        /// <summary>
        /// Get actor by <paramref name="id"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("actor/{id:int}")]
        public async Task<ActionResult<Actor>> GetActorByIdAsync([FromRoute] int id)
        {
            var actor = await _cinemaService.GetActorById(id);
            
            if (actor == null)
            {
                return NotFound($"Actor with id {id} not found");
            }

            return _mapper.Map<Actor>(actor);
        }

        /// <summary>
        /// Get director by <paramref name="id"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("director/{id:int}")]
        public async Task<ActionResult<Director>> GetDirectorByIdAsync([FromRoute] int id)
        {
            var director = await _cinemaService.GetDirectorById(id);

            if (director == null)
            {
                return NotFound($"Director with id {id} not found");
            }

            return _mapper.Map<Director>(director);
        }
        
        /// <summary>
        /// Get genre by <paramref name="id"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("genre/{id:int}")]
        public async Task<ActionResult<Genre>> GetGenreByIdAsync([FromRoute] int id)
        {
            var genre = await _cinemaService.GetGenreById(id);

            if (genre == null)
            {
                return NotFound($"Genre with id {id} not found");
            }

            return _mapper.Map<Genre>(genre);
        }
        
        /// <summary>
        /// Update actor 
        /// </summary>
        /// <param name="newActor"></param>
        /// <returns></returns>
        [HttpPut("actor")]
        public async Task<ActionResult<Actor>> UpdateActorAsync([FromBody] Actor newActor)
        {
            var updated = await _cinemaService.UpdateActor(_mapper.Map<ActorEntity>(newActor));
            if (updated == null)
            {
                return NotFound($"Actor with id {newActor.Id} not found");
            }

            return _mapper.Map<Actor>(updated);
        }
        
        /// <summary>
        /// Update director
        /// </summary>
        /// <param name="newDirector"></param>
        /// <returns></returns>
        [HttpPut("director")]
        public async Task<ActionResult<Director>> UpdateDirectorAsync([FromBody] Director newDirector)
        {
            var updated = await _cinemaService.UpdateDirector(_mapper.Map<DirectorEntity>(newDirector));
            if (updated == null)
            {
                return NotFound($"Director with id {newDirector.Id} not found");
            }

            return _mapper.Map<Director>(updated);
        }
        
        /// <summary>
        /// Update genre
        /// </summary>
        /// <param name="newGenre"></param>
        /// <returns></returns>
        [HttpPut("genre")]
        public async Task<ActionResult<Genre>> UpdateGenreAsync([FromBody] Genre newGenre)
        {
            var updated = await _cinemaService.UpdateGenre(_mapper.Map<GenreEntity>(newGenre));
            if (updated == null)
            {
                return NotFound($"Genre with id {newGenre.Id} not found");
            }

            return _mapper.Map<Genre>(updated);
        }
        
        /// <summary>
        /// Update movie
        /// </summary>
        /// <param name="newMovie"></param>
        /// <returns></returns>
        [HttpPut("movie")]
        public async Task<ActionResult<Movie>> UpdateMovieAsync([FromBody] MovieUpdate newMovie)
        {
            var movie = await _cinemaService.GetMovieById(newMovie.Id);
            if (movie == null)
            {
                return NotFound($"Movie with id {newMovie.Id} not found");
            }

             
            var updatedGenresList = new List<GenreEntity>();
            var updatedActorsList = new List<ActorEntity>();

            foreach (var genreId in newMovie.Genres)
            {
                var genre = await _cinemaService.GetGenreById(genreId);
                if (genre == null)
                {
                    return NotFound($"Genre with id {genreId} not found");
                }

                if (updatedGenresList.Contains(genre))
                {
                    return BadRequest($"Genre {genre.Name} already added");
                }

                updatedGenresList.Add(genre);
            }
            
            foreach (var actorId in newMovie.Actors)
            {
                var actor = await _cinemaService.GetActorById(actorId);
                if (actor == null)
                {
                    return NotFound($"Actor with id {actorId} not found");
                }

                if (updatedActorsList.Contains(actor))
                {
                    return BadRequest($"Actor {actor.Name} already added");
                }

                updatedActorsList.Add(actor);
            }

            var newDirector = await _cinemaService.GetDirectorById(newMovie.DirectorId);
            if (newDirector == null)
            {
                return NotFound($"Director with id {newMovie.DirectorId} not found");
            }

            movie = new MovieEntity
            {
                Id = newMovie.Id,
                Name = newMovie.Name,
                Country = newMovie.Country,
                Year = newMovie.Year,
                Description = newMovie.Description,
                ImageUrl = newMovie.ImageUrl,
                MovieUrl = newMovie.MovieUrl,
                Director = newDirector,
                Actors = updatedActorsList,
                Genres = updatedGenresList
            };
            
            var updated = await _cinemaService.UpdateMovie(movie);
            
            return _mapper.Map<Movie>(updated);
        }

        /// <summary>
        /// Get list of all genres
        /// </summary>
        /// <returns></returns>
        [HttpGet("genres")]
        public async Task<List<Genre>> GetAllGenresAsync()
        {
            return _mapper.Map<List<Genre>>(await _cinemaService.GetAllGenres());
        }

        /// <summary>
        /// Get list of all actors
        /// </summary>
        /// <returns></returns>
        [HttpGet("actors")]
        public async Task<List<Actor>> GetAllActorsAsync()
        {
            return _mapper.Map<List<Actor>>(await _cinemaService.GetAllActors());
        }

        /// <summary>
        /// Get list of all directors
        /// </summary>
        /// <returns></returns>
        [HttpGet("directors")]
        public async Task<List<Director>> GetAllDirectorsAsync()
        {
            return _mapper.Map<List<Director>>(await _cinemaService.GetAllDirectors());
        }
        
        /// <summary>
        /// Get list of all movies
        /// </summary>
        /// <returns></returns>
        [HttpGet("movies")]
        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            return _mapper.Map<List<Movie>>(await _cinemaService.GetAllMovies());
        }

        /// <summary>
        /// Delete genre by <paramref name="id"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("genre/{id:int}")]
        public async Task<IActionResult> DeleteGenreByIdAsync([FromRoute]int id)
        {
            try
            {
                if (await _cinemaService.GetGenreById(id) == null)
                {
                    return NotFound($"Genre with id {id} not found");
                }
                await _cinemaService.DeleteGenreById(id);
            }
            catch (Exception e)
            {
                ErrorResponse.GenerateError(HttpStatusCode.InternalServerError, e.Message);
            }

            return Ok();
        }
        
        /// <summary>
        /// Delete actor by <paramref name="id"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("actor/{id:int}")]
        public async Task<IActionResult> DeleteActorByIdAsync([FromRoute]int id)
        {
            try
            {
                if (await _cinemaService.GetActorById(id) == null)
                {
                    return NotFound($"Actor with id {id} not found");
                }
                await _cinemaService.DeleteActorById(id);
            }
            catch (Exception e)
            {
                ErrorResponse.GenerateError(HttpStatusCode.InternalServerError, e.Message);
            }

            return Ok();
        }
        
        /// <summary>
        /// Delete director by <paramref name="id"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("director/{id:int}")]
        public async Task<IActionResult> DeleteDirectorByIdAsync([FromRoute]int id)
        {
            try
            {
                if (await _cinemaService.GetDirectorById(id) == null)
                {
                    return NotFound($"Director with id {id} not found");
                }
                await _cinemaService.DeleteDirectorById(id);
            }
            catch (Exception e)
            {
                ErrorResponse.GenerateError(HttpStatusCode.InternalServerError, e.Message);
            }

            return Ok();
        }
        
        /// <summary>
        /// Delete movie by <paramref name="id"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("movie/{id:int}")]
        public async Task<IActionResult> DeleteMovieByIdAsync([FromRoute]int id)
        {
            try
            {
                if (await _cinemaService.GetMovieById(id) == null)
                {
                    return NotFound($"Movie with id {id} not found");
                }
                await _cinemaService.DeleteMovieById(id);
            }
            catch (Exception e)
            {
                ErrorResponse.GenerateError(HttpStatusCode.InternalServerError, e.Message);
            }

            return Ok();
        }
    }
}