using CleanArchitecture.Core.PageSet;
using CleanArchitecture.Core.ViewModels;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IAutoSpecificationSubRepository
    {
        AutoSpecificationViewModel AutoSpecificationSubSave(AutoSpecificationViewModel AutoSpecificationViewModel);
        AutoSolutionPageSet<AutoSpecificationSubViewModel> GetAutoSpecificationSub(AutoSpecificationSubViewModel AutoSpecificationSubViewModel);
        AutoSpecificationSubViewModel GetAutoSpecificationSubById(int Id);
    }
}
