using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using KFU.CinemaOnline.Common;
using KFU.CinemaOnline.Core.Cinema;

namespace KFU.CinemaOnline.BL
{
    public class CinemaService : ICinemaService
    {
        private readonly ICinemaRepository _cinemaRepository;

        public CinemaService(ICinemaRepository cinemaRepository)
        {
            _cinemaRepository = cinemaRepository;
        }

        public async Task<GenreEntity> CreateGenre(GenreEntity entity)
        {
            return await _cinemaRepository.CreateGenreEntityAsync(entity);
        }

        public async Task<ActorEntity> CreateActor(ActorEntity entity)
        {
            return await _cinemaRepository.CreateActorEntityAsync(entity);
        }

        public async Task<DirectorEntity> CreateDirector(DirectorEntity entity)
        {
            return await _cinemaRepository.CreateDirectorEntityAsync(entity);
        }

        public async Task<MovieCreateResponseModel> CreateMovie(MovieCreateModel entity)
        {
            var director = await _cinemaRepository.GetDirectorEntityByIdAsync(entity.DirectorId);
            if (director == null)
            {
                return new MovieCreateResponseModel
                {
                    Movie = null,
                    ErrorMessage = $"Director with id {entity.DirectorId} not found"
                };
            }
            
            var genres = new List<GenreEntity>();
            foreach (var genreId in entity.Genres)
            {
                var genre = await _cinemaRepository.GetGenreEntityByIdAsync(genreId);
                if (genre == null)
                {
                    return new MovieCreateResponseModel
                    {
                        Movie = null,
                        ErrorMessage = $"Genre with id {genreId} not found"
                    };
                }

                if (genres.Contains(genre))
                {
                    return new MovieCreateResponseModel
                    {
                        Movie = null,
                        ErrorMessage = "Genres can not be repeated"
                    };
                }
                
                genres.Add(genre);
            }

            var actors = new List<ActorEntity>();
            foreach (var actorId in entity.Actors)
            {
                var actor = await _cinemaRepository.GetActorEntityByIdAsync(actorId);
                if (actor == null)
                {
                    return new MovieCreateResponseModel
                    {
                        Movie = null,
                        ErrorMessage = $"Actor with id {actorId} not found"
                    };
                }

                if (actors.Contains(actor))
                {
                    return new MovieCreateResponseModel
                    {
                        Movie = null,
                        ErrorMessage = "Actors can not be repeated"
                    };
                }

                actors.Add(actor);
            }
            
            var newMovie = new MovieEntity
            {
                Name = entity.Name,
                Year = entity.Year,
                Country = entity.Country,
                Description = entity.Description,
                ImageUrl = entity.ImageUrl,
                MovieUrl = entity.MovieUrl,
                Director = director,
                Genres = genres,
                Actors = actors
            };

            var created = await _cinemaRepository.CreateMovieEntityAsync(newMovie);
            return new MovieCreateResponseModel
            {
                Movie = created,
                ErrorMessage = null
            };
        }

        public async Task<List<GenreEntity>> GetAllGenres()
        {
            return await _cinemaRepository.GetAllGenreEntitiesAsync();
        }

        public async Task<List<ActorEntity>> GetAllActors()
        {
            return await _cinemaRepository.GetAllActorEntitiesAsync();
        }

        public async Task<List<DirectorEntity>> GetAllDirectors()
        {
            return await _cinemaRepository.GetAllDirectorEntitiesAsync();
        }

        public async Task<List<MovieEntity>> GetAllMovies()
        {
            return await _cinemaRepository.GetAllMovieEntitiesAsync();
        }

        public async Task<GenreEntity> GetGenreById(int id)
        {
            return await _cinemaRepository.GetGenreEntityByIdAsync(id);
        }

        public async Task<ActorEntity> GetActorById(int id)
        {
            return await _cinemaRepository.GetActorEntityByIdAsync(id);
        }

        public async Task<DirectorEntity> GetDirectorById(int id)
        {
            return await _cinemaRepository.GetDirectorEntityByIdAsync(id);
        }

        public async Task<MovieEntity> GetMovieById(int id)
        {
            return await _cinemaRepository.GetMovieEntityByIdAsync(id);
        }

        public async Task<ActorEntity> UpdateActor(ActorEntity actorEntity)
        {
            if (await _cinemaRepository.GetActorEntityByIdAsync(actorEntity.Id) == null)
            {
                return null;
            }
            return await _cinemaRepository.UpdateActorEntityAsync(actorEntity);
        }

        public async Task<GenreEntity> UpdateGenre(GenreEntity genreEntity)
        {
            if (await _cinemaRepository.GetGenreEntityByIdAsync(genreEntity.Id) == null)
            {
                return null;
            }
            return await _cinemaRepository.UpdateGenreEntityAsync(genreEntity);        }

        public async Task<DirectorEntity> UpdateDirector(DirectorEntity directorEntity)
        {
            if (await _cinemaRepository.GetDirectorEntityByIdAsync(directorEntity.Id) == null)
            {
                return null;
            }
            return await _cinemaRepository.UpdateDirectorEntityAsync(directorEntity);        }

        public async Task<MovieEntity> UpdateMovie(MovieEntity movieEntity)
        {
            if (await _cinemaRepository.GetMovieEntityByIdAsync(movieEntity.Id) == null)
            {
                return null;
            }
            return await _cinemaRepository.UpdateMovieEntityAsync(movieEntity);        }

        public async Task DeleteGenreById(int id)
        {
            await _cinemaRepository.DeleteGenreEntityByIdAsync(id);
        }

        public async Task DeleteDirectorById(int id)
        {
            await _cinemaRepository.DeleteDirectorEntityByIdAsync(id);
        }

        public async Task DeleteActorById(int id)
        {
            await _cinemaRepository.DeleteActorEntityByIdAsync(id);
        }

        public async Task DeleteMovieById(int id)
        {
            await _cinemaRepository.DeleteMovieEntityByIdAsync(id);
        }

        public async Task<PagingResult<MovieEntity>> QueryMovieItems(MovieFilterSettings pagingSettings)
        {
            throw new NotImplementedException();
            /*if (pagingSettings == null)
            {
                var items = await _cinemaRepository.GetAllMovieEntitiesAsync();
                return new PagingResult<MovieEntity>
                {
                    Total = items.Count,
                    Items = items.Take(PagingSettings.DefaultLimit).ToArray()
                };
            }
            */
        }
        
        
    }
}