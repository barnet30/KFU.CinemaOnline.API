using AutoMapper;
using KFU.CinemaOnline.Core.Cinema;

namespace KFU.CinemaOnline.BL
{
    public class BlMapperProfile : Profile
    {
        public BlMapperProfile()
        {
            CreateMap<MovieUpdateModel, MovieEntity>()
                .ForMember(dst => dst.Actors, opt => opt.Ignore())
                .ForMember(dst => dst.Genres, opt => opt.Ignore())
                .ForMember(dst => dst.Director, opt => opt.Ignore())
                .ForMember(dst => dst.Estimations, opt => opt.Ignore())
                .ForMember(dst => dst.Rating, opt => opt.Ignore())
                .ForMember(dst => dst.EstimationAmount, opt => opt.Ignore())
                .ForMember(dst => dst.CreatedAt, opt => opt.Ignore());
        }
    }
}
