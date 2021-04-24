using Autofac;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.Interfaces.SessionManager;
using CleanArchitecture.Core.PageSet;
using CleanArchitecture.Core.Service;
using CleanArchitecture.Core.Service.SessionManager;
using CleanArchitecture.Core.ViewModels;
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

            //sessiom
            builder.RegisterType<SessionManager>().As<ISessionManager>().InstancePerLifetimeScope();

            //generic repository
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(AutoSolutionPageSet<>)).AsSelf();

            //class specfic
            builder.RegisterType<Pager>();
            builder.RegisterType<AutoManufacturer>();
            builder.RegisterType<AutoBodyType>();
            builder.RegisterType<AutoModel>();
            builder.RegisterType<Role>();
            builder.RegisterType<User>();
            builder.RegisterType<ViewDataSet>();

            builder.RegisterType<AutoModelViewModel>();
            builder.RegisterType<AutoBodyTypeViewModel>();


            //service & repositroy
            builder.RegisterType<AutoManufacturerService>().As<IAutoManufacturerService>().InstancePerLifetimeScope();
            builder.RegisterType<AutoManufacturerRepository>().As<IAutoManufacturerRepository>().InstancePerLifetimeScope();

            builder.RegisterType<AutoBodyTypeService>().As<IAutoBodyTypeService>().InstancePerLifetimeScope();
            builder.RegisterType<AutoBodyTypeRepository>().As<IAutoBodyTypeRepository>().InstancePerLifetimeScope();
            

            builder.RegisterType<AutoModelService>().As<IAutoModelService>().InstancePerLifetimeScope();
            builder.RegisterType<AutoModelRepository>().As<IAutoModelRepository>().InstancePerLifetimeScope();

            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();

            builder.RegisterType<AutoSolutionLookupService>().As<IAutoSolutionLookupService>().InstancePerLifetimeScope();
            builder.RegisterType<AutoSolutionLookupRepository>().As<IAutoSolutionLookupRepository>().InstancePerLifetimeScope();

            #region lookUp 
            builder.RegisterType<AutoSolutionLookupService>().As<IAutoSolutionLookupService>().InstancePerLifetimeScope();
            builder.RegisterType<AutoSolutionLookupRepository>().As<IAutoSolutionLookupRepository>().InstancePerLifetimeScope();
            #endregion
        }
    }
}
