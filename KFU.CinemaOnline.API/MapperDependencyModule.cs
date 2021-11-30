using System.Collections.Generic;
using Autofac;
using AutoMapper;

namespace KFU.CinemaOnline.API
{
    public class MapperDependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DtoMapperProfile>();
            })).AsSelf().SingleInstance();
        }
    }
}
