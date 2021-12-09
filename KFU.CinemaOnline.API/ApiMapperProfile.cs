﻿using AutoMapper;
using KFU.CinemaOnline.API.Contracts.Account;
using KFU.CinemaOnline.API.Contracts.Cinema.Actor;
using KFU.CinemaOnline.API.Contracts.Cinema.Director;
using KFU.CinemaOnline.API.Contracts.Cinema.Genre;
using KFU.CinemaOnline.API.Contracts.Cinema.Movie;
using KFU.CinemaOnline.Core.Account;
using KFU.CinemaOnline.Core.Cinema;

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

            CreateMap<ActorCreate, ActorEntity>();

            CreateMap<DirectorCreate, DirectorEntity>();
            
            CreateMap<MovieEntity, Movie>();
        }
    }
}
