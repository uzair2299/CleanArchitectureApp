using CleanArchitecture.Core.PageSet;
using CleanArchitecture.Core.ViewModels;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IAutoLookUpTypeRepository
    {
        bool DeleteAutoLookUpType(int Id);
        AutoLookUpTypeViewModel SaveAutoLookUpType(AutoLookUpType AutoLookUpType);
        AutoSolutionPageSet<AutoLookUpTypeViewModel> GetAutoLookUpType(AutoLookUpTypeViewModel AutoLookUpTypeViewModel);
        AutoLookUpTypeViewModel GetAutoLookUpTypeById(int Id);
        bool UpdateAutoLookUpType(AutoLookUpType AutoLookUpType);

    }
}
