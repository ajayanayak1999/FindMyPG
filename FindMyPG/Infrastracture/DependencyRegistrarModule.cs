using Autofac;
using FindMyPG.Core.Data;
using FindMyPG.Data;
using FindMyPG.Service.Cities;
using FindMyPG.Service.States;
using FindMyPG.Service.ZipCodes;
using Microsoft.EntityFrameworkCore;

namespace FindMyPG.Infrastracture
{
    public class DependencyRegistrarModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //TODO::Resolve DependencyInjection.. 
            base.Load(builder);

            builder.Register(context =>
            new PGDBContext(context.Resolve<DbContextOptions<PGDBContext>>()))
                .As<IDbContext>();

            builder.RegisterGeneric(typeof(EFRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

            builder.RegisterType<StateService>().As<IStateService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<CityService>().As<ICityService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ZipCodeService>().As<IZipCodeService>()
                .InstancePerLifetimeScope();

        }
    }
}
