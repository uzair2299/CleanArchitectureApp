using CleanArchitecture.Core.PageSet;
using CleanArchitecture.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IAutoSpecificationService
    {
        AutoSpecificationViewModel AutoSpecificationSave(AutoSpecificationViewModel AutoSpecificationViewModel);
        AutoSolutionPageSet<AutoSpecificationViewModel> GetAutoSpecification(AutoSpecificationViewModel AutoSpecificationViewModel);
        AutoSpecificationViewModel GetAutoSpecificationById(int Id);
    }
}
