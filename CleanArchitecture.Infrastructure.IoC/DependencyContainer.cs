using Autofac;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.Service;
using CleanArchitecture.Core.ViewModels;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
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

            //builder.RegisterType<BookViewModelMapper>().AsSelf();
            //builder.RegisterType<Book>().AsSelf();


        }
    }
}
