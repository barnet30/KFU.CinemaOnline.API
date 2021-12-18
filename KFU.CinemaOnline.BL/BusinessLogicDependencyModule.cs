using Autofac;
using KFU.CinemaOnline.Core.Account;
using KFU.CinemaOnline.Core.Cinema;
using KFU.CinemaOnline.Core.Estimation;

namespace KFU.CinemaOnline.BL
{
    public class BusinessLogicDependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AccountService>().As<IAccountService>().InstancePerLifetimeScope();
            builder.RegisterType<CinemaService>().As<ICinemaService>().InstancePerLifetimeScope();
            builder.RegisterType<EstimationService>().As<IEstimationService>().InstancePerLifetimeScope();
        }
    }
}
