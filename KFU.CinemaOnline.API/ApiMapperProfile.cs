using AutoMapper;
using KFU.CinemaOnline.API.Contracts.Account;
using KFU.CinemaOnline.Core.Account;

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
            
        }
    }
}
