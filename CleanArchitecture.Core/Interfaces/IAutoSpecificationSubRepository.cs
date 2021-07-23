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
        AutoSpecificationSubViewModel AutoSpecificationSubSave(AutoSpecificationSubViewModel AutoSpecificationSubViewModel);
        AutoSolutionPageSet<AutoSpecificationSubViewModel> GetAutoSpecificationSub(AutoSpecificationSubViewModel AutoSpecificationSubViewModel);
        AutoSpecificationSubViewModel GetAutoSpecificationSubById(int Id);
    }
}
