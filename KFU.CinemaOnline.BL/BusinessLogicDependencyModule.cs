using Autofac;
using KFU.CinemaOnline.Core.Account;
using KFU.CinemaOnline.Core.Cinema;

namespace KFU.CinemaOnline.BL
{
    public class BusinessLogicDependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AccountService>().As<IAccountService>().InstancePerLifetimeScope();
            builder.RegisterType<CinemaService>().As<ICinemaService>().InstancePerLifetimeScope();
        }
    }
}
