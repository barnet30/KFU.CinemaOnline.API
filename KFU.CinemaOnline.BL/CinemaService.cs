using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using KFU.CinemaOnline.Common;
using KFU.CinemaOnline.Core.Cinema;

namespace KFU.CinemaOnline.BL
{
    public class CinemaService : ICinemaService
    {
        private readonly ICinemaRepository _cinemaRepository;
        private readonly IMapper _mapper;

        public CinemaService(ICinemaRepository cinemaRepository, IMapper mapper)
        {
            _cinemaRepository = cinemaRepository;
            _mapper = mapper;
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

        public async Task<MovieResponseModel> CreateMovie(MovieCreateModel entity)
        {
            var director = await _cinemaRepository.GetDirectorEntityByIdAsync(entity.DirectorId);
            if (director == null)
            {
                return new MovieResponseModel
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
                    return new MovieResponseModel
                    {
                        Movie = null,
                        ErrorMessage = $"Genre with id {genreId} not found"
                    };
                }

                if (genres.Contains(genre))
                {
                    return new MovieResponseModel
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
                    return new MovieResponseModel
                    {
                        Movie = null,
                        ErrorMessage = $"Actor with id {actorId} not found"
                    };
                }

                if (actors.Contains(actor))
                {
                    return new MovieResponseModel
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
                CountryId = entity.CountryId,
                Country = entity.Country,
                Description = entity.Description,
                ImageUrl = entity.ImageUrl,
                MovieUrl = entity.MovieUrl,
                Director = director,
                Genres = genres,
                Actors = actors
            };

            var created = await _cinemaRepository.CreateMovieEntityAsync(newMovie);
            return new MovieResponseModel
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

        public async Task<PagingResult<MovieEntity>> GetFilteredMovies(MovieFilterSettings filter, Category category)
        {
            return await _cinemaRepository.GetQueryMoviesAsync(filter, category);
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

        public async Task<MovieResponseModel> UpdateMovie(MovieUpdateModel updateModel)
        {
            var oldMovie = await _cinemaRepository.GetMovieEntityByIdAsync(updateModel.Id);
            if (oldMovie == null)
            {
                return new MovieResponseModel
                {
                    Movie = null,
                    ErrorMessage = $"Movie with id {updateModel.Id} not found"
                };
            }
             
            var updatedGenresList = new List<GenreEntity>();
            var updatedActorsList = new List<ActorEntity>();

            foreach (var genreId in updateModel.Genres)
            {
                var genre = await _cinemaRepository.GetGenreEntityByIdAsync(genreId);
                if (genre == null)
                {
                    return new MovieResponseModel
                    {
                        Movie = null,
                        ErrorMessage = $"Genre with id {genreId} not found"
                    };
                }

                if (updatedGenresList.Contains(genre))
                {
                    return new MovieResponseModel
                    {
                        Movie = null,
                        ErrorMessage = $"Genre {genre.Name} already added"
                    };
                }

                updatedGenresList.Add(genre);
            }
            
            foreach (var actorId in updateModel.Actors)
            {
                var actor = await _cinemaRepository.GetActorEntityByIdAsync(actorId);
                if (actor == null)
                {
                    return new MovieResponseModel
                    {
                        Movie = null,
                        ErrorMessage = $"Actor with id {actorId} not found"
                    };
                }

                if (updatedActorsList.Contains(actor))
                {
                    return new MovieResponseModel
                    {
                        Movie = null,
                        ErrorMessage = $"Actor {actor.Name} already added"
                    };
                }

                updatedActorsList.Add(actor);
            }

            var newDirector = await _cinemaRepository.GetDirectorEntityByIdAsync(updateModel.DirectorId);
            if (newDirector == null)
            {
                return new MovieResponseModel
                {
                    Movie = null,
                    ErrorMessage = $"Director with id {updateModel.DirectorId} not found"
                };
            }

            var newMovie = _mapper.Map<MovieEntity>(updateModel);
            newMovie.Estimations = oldMovie.Estimations;
            newMovie.Rating = oldMovie.Rating;
            newMovie.EstimationAmount = oldMovie.EstimationAmount;
            newMovie.CreatedAt = oldMovie.CreatedAt;

            newMovie.Director = newDirector;
            newMovie.Actors = updatedActorsList;
            newMovie.Genres = updatedGenresList;
            
            var updated = await _cinemaRepository.UpdateMovieEntityAsync(newMovie);

            return new MovieResponseModel
            {
                Movie = updated,
                ErrorMessage = null
            };
        }

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
    }
}