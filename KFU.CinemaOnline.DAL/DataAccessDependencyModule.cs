using Autofac;
using KFU.CinemaOnline.DAL.Identity;

namespace KFU.CinemaOnline.DAL
{
    public class DataAccessDependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterTypes(
                    typeof(UserRepository))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
