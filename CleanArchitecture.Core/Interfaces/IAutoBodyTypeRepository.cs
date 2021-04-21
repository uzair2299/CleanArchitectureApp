using CleanArchitecture.Core.PageSet;
using CleanArchitecture.Core.ViewModels;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IAutoBodyTypeRepository
    {
        bool DeleteAutoBodyType(int Id);
        AutoBodyTypeViewModel SaveAutoBodyType(AutoBodyType autoBodyType);
        AutoSolutionPageSet<AutoBodyTypeViewModel> GetAutoBodyType(AutoBodyTypeViewModel autoBodyTypeViewModel);
        AutoBodyTypeViewModel GetAutoBodyTypeById(int Id);
        bool UpdateAutoBodyType(AutoBodyType autoBodyType);
    }
}
