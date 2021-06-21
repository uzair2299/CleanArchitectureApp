using CleanArchitecture.Core.PageSet;
using CleanArchitecture.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IAutoLookUpTypeService
    {
        bool DeleteAutoLookUpType(int Id);
        AutoLookUpTypeViewModel AutoLookUpTypeSave(AutoLookUpTypeViewModel AutoLookUpTypeViewModel);
        AutoSolutionPageSet<AutoLookUpTypeViewModel> GetAutoLookUpType(AutoLookUpTypeViewModel AutoLookUpTypeViewModel);
        AutoLookUpTypeViewModel GetAutoLookUpTypeById(int Id);
        bool UpdateAutoLookUpType(AutoLookUpTypeViewModel AutoLookUpTypeViewModel);
    }
}
