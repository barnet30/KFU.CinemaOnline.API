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
        }
    }
}
