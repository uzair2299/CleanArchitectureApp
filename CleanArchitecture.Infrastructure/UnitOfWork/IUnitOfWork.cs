using CleanArchitecture.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Infrastructure.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        AutoSolutionContext GetAutoSolutionContext();
        bool SaveChanges();
    }
}
