using CleanArchitecture.Core.PageSet;
using CleanArchitecture.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IAutoBodyTypeService
    {
        bool DeleteAutoBodyType(int Id);
        AutoBodyTypeViewModel AutoBodyTypeSave(AutoBodyTypeViewModel autoBodyTypeViewModel);
        AutoSolutionPageSet<AutoBodyTypeViewModel> GetAutoBodyType(AutoBodyTypeViewModel autoBodyTypeViewModel);
        AutoBodyTypeViewModel GetAutoBodyTypeById(int Id);
        bool UpdateAutoBodyType(AutoBodyTypeViewModel autoBodyTypeViewModel);

    }
}
