using CleanArchitecture.Core.PageSet;
using CleanArchitecture.Core.ViewModels;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IAutoEngineTypeRepository
    {
        bool DeleteAutoEngineType(int Id);
        AutoEngineTypeViewModel SaveAutoEngineType(AutoEngineType autoEngineType);
        AutoSolutionPageSet<AutoEngineTypeViewModel> GetAutoEngineType(AutoEngineTypeViewModel autoEngineTypeViewModel);
        AutoEngineTypeViewModel GetAutoEngineTypeById(int Id);
        bool UpdateAutoEngineType(AutoEngineType autoEngineType);
        PageSet<AutoEngineTypeViewModel> GetAutoEngineTypeDT(DTParameters dTParameters);
    }
}
