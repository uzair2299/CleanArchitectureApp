using CleanArchitecture.Infrastructure.Context;
using CleanArchitecture.Infrastructure.Interfaces;
using System;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class UnitOfWork:IUnitOfWork
    {
        protected AutoSolutionContext AutoSolutionContext { get; }


        public UnitOfWork(AutoSolutionContext autoSolutionContext)
        {
            AutoSolutionContext = autoSolutionContext;
        }

        public bool SaveChanges()
        {
            bool returnValue = true;
            using (var dbContextTransaction = AutoSolutionContext.Database.BeginTransaction())
            {
                try
                {
                    AutoSolutionContext.SaveChanges();
                    dbContextTransaction.Commit();

                }
                catch (Exception)
                {
                    returnValue = false;
                    dbContextTransaction.Rollback();
                }
                return returnValue;
            }
        }

        public void Dispose()
        {
            AutoSolutionContext.Dispose();
        }

        public AutoSolutionContext GetAutoSolutionContext()
        {
            return AutoSolutionContext;
        }
    }
}
