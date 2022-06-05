using System;
using AutoMapper;
using KFU.CinemaOnline.API.Contracts;
using KFU.CinemaOnline.API.Contracts.Account;
using KFU.CinemaOnline.API.Contracts.Cinema.Actor;
using KFU.CinemaOnline.API.Contracts.Cinema.Director;
using KFU.CinemaOnline.API.Contracts.Cinema.Genre;
using KFU.CinemaOnline.API.Contracts.Cinema.Movie;
using KFU.CinemaOnline.API.Contracts.Cinema.RefBook;
using KFU.CinemaOnline.Common;
using KFU.CinemaOnline.Core.Account;
using KFU.CinemaOnline.Core.Cinema;
using KFU.CinemaOnline.Core.RefBook;

namespace KFU.CinemaOnline.API
{
    public class ApiMapperProfile : Profile
    {
        public ApiMapperProfile()
        {
            CreateMap<Account, AccountEntity>().ReverseMap();
            CreateMap<RegisterRequest, AccountEntity>()
                .ForMember(dst => dst.Id, opt => opt.Ignore())
                .ForMember(dst => dst.Roles, opt => opt.Ignore());

            
            
            CreateMap<GenreCreate, GenreEntity>()
                .ForMember(dst => dst.Id, 
                    opt => opt.Ignore());
            CreateMap<GenreEntity, Genre>();
            CreateMap<Genre, GenreEntity>();

            CreateMap<ActorCreate, ActorEntity>();
            CreateMap<ActorEntity, Actor>();
            CreateMap<Actor, ActorEntity>()
                .ForMember(dst => dst.Movies, 
                    opt => opt.Ignore());

            CreateMap<DirectorCreate, DirectorEntity>();
            CreateMap<DirectorEntity, Director>();
            CreateMap<Director, DirectorEntity>();

            CreateMap<MovieEntity, Movie>()
                .ForMember(dst => dst.Rating, opt => 
                    opt.MapFrom(src => Math.Round(src.Rating, 1)));
            CreateMap<Movie, MovieEntity>();
            CreateMap<MovieCreate, MovieCreateModel>();
            CreateMap<MovieUpdate, MovieUpdateModel>();
            CreateMap<MovieEntity, MovieItem>()
                .ForMember(dst => dst.Rating, opt => 
                    opt.MapFrom(src => Math.Round(src.Rating, 1)));

            CreateMap<PagingParameters, PagingSettings>().ReverseMap();
            CreateMap<PagingSortParameters, PagingSortSettings>().ReverseMap();
            CreateMap<PagingSortOrder, SortOrder>().ReverseMap();
            CreateMap(typeof(PagingResult<>), typeof(Page<>));
            
            CreateMap<MovieFilterRequest, MovieFilterSettings>();

            CreateMap<CountryRefEntity, CountryRef>().ReverseMap();
        }
    }
}
