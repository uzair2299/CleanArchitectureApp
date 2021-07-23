using CleanArchitecture.Core.PageSet;
using CleanArchitecture.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IAutoSpecificationSubService
    {
        AutoSpecificationSubViewModel AutoSpecificationSubSave(AutoSpecificationSubViewModel AutoSpecificationSubViewModel);
        AutoSolutionPageSet<AutoSpecificationSubViewModel> GetAutoSpecificationSub(AutoSpecificationSubViewModel AutoSpecificationSubViewModel);
        AutoSpecificationSubViewModel GetAutoSpecificationSubById(int Id);
    }
}
