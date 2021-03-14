using Autofac;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.PageSet;
using CleanArchitecture.Core.Service;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Interfaces;
using CleanArchitecture.Infrastructure.Repositories;

namespace CleanArchitecture.Infrastructure.IoC
{
    public class DependencyContainer :Module
    {
       protected override void Load(ContainerBuilder builder)
        {
            //unit of work
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            //generic repository
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(AutoSolutionPageSet<>)).AsSelf();

            //class specfic
            builder.RegisterType<Pager>();
            builder.RegisterType<AutoManufacturer>();
            builder.RegisterType<AutoModel>();
            builder.RegisterType<Role>();
            builder.RegisterType<ViewDataSet>();


            //service & repositroy
            builder.RegisterType<AutoManufacturerService>().As<IAutoManufacturerService>().InstancePerLifetimeScope();
            builder.RegisterType<AutoManufacturerRepository>().As<IAutoManufacturerRepository>().InstancePerLifetimeScope();

            builder.RegisterType<AutoModelService>().As<IAutoModelService>().InstancePerLifetimeScope();
            builder.RegisterType<AutoModelRepository>().As<IAutoModelRepository>().InstancePerLifetimeScope();

            builder.RegisterType<RolesService>().As<IRolesService>().InstancePerLifetimeScope();
            builder.RegisterType<RolesRepository>().As<IRolesRepository>().InstancePerLifetimeScope();
        }
    }
}
