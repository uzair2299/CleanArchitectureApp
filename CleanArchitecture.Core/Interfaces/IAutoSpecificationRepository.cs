using CleanArchitecture.Core.PageSet;
using CleanArchitecture.Core.ViewModels;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IAutoSpecificationRepository
    {
        AutoSpecificationViewModel AutoSpecificationSave(AutoSpecificationViewModel AutoSpecificationViewModel);
        AutoSolutionPageSet<AutoSpecificationViewModel> GetAutoSpecification(AutoSpecificationViewModel AutoSpecificationViewModel);
        AutoSpecificationViewModel GetAutoSpecificationById(int Id);
    }
}
