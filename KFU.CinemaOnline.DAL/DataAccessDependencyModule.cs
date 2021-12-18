using Autofac;
using KFU.CinemaOnline.DAL.Account;
using KFU.CinemaOnline.DAL.Cinema;

namespace KFU.CinemaOnline.DAL
{
    public class DataAccessDependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterTypes(
                    typeof(AccountRepository),
                    typeof(CinemaRepository),
                    typeof(EstimationRepository))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
