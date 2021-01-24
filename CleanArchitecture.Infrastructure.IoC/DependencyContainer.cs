using Autofac;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.Service;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
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
            
            //class specfic
            builder.RegisterType<AutoManufacturer>();

            //service & repositroy
            builder.RegisterType<AutoManufacturerService>().As<IAutoManufacturerService>().InstancePerLifetimeScope();
            builder.RegisterType<AutoManufacturerRepository>().As<IAutoManufacturerRepository>().InstancePerLifetimeScope();
        }
    }
}
