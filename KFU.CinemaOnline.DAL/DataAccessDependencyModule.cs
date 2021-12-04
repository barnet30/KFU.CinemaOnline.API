using Autofac;
using KFU.CinemaOnline.DAL.Account;

namespace KFU.CinemaOnline.DAL
{
    public class DataAccessDependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterTypes(
                    typeof(AccountRepository))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
