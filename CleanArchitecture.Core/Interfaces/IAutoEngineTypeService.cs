using CleanArchitecture.Core.PageSet;
using CleanArchitecture.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IAutoEngineTypeService
    {
        bool DeleteAutoEngineType(int Id);
        AutoEngineTypeViewModel AutoEngineTypeSave(AutoEngineTypeViewModel autoEngineTypeViewModel);
        AutoSolutionPageSet<AutoEngineTypeViewModel> GetAutoEngineType(AutoEngineTypeViewModel autoEngineTypeViewModel);
        AutoEngineTypeViewModel GetAutoEngineTypeById(int Id);
        bool UpdateAutoEngineType(AutoEngineTypeViewModel autoEngineTypeViewModel);

        PageSet<AutoEngineTypeViewModel> GetAutoEngineTypeDT(DTParameters dTParameters);
    }
}
