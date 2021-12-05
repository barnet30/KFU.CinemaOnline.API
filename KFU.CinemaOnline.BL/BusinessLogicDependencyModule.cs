using Autofac;
using KFU.CinemaOnline.Core.Account;

namespace KFU.CinemaOnline.BL
{
    public class BusinessLogicDependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AccountService>().As<IAccountService>().InstancePerLifetimeScope();
        }
    }
}
