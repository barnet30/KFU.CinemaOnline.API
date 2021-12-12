using Autofac;
using AutoMapper;
using KFU.CinemaOnline.BL;

namespace KFU.CinemaOnline.API
{
    public class MapperDependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ApiMapperProfile>();
                cfg.AddProfile<BlMapperProfile>();
            })).AsSelf().SingleInstance();
        }
    }
}
