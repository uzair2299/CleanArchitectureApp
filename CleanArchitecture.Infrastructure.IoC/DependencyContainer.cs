using Autofac;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.Service;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Infrastructure.IoC
{
    public class DependencyContainer :Module
    {
       protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BookService>().As<IBookService>().InstancePerLifetimeScope();
            builder.RegisterType<BookRepository>().As<IBookRepository>().InstancePerLifetimeScope();

        }
    }
}
