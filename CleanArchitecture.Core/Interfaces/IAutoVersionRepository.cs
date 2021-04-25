using CleanArchitecture.Core.PageSet;
using CleanArchitecture.Core.ViewModels;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IAutoVersionRepository
    {
        AutoVersionViewModel AutoVersionSave(AutoVersionViewModel autoVersionViewModel);
        AutoSolutionPageSet<AutoVersionViewModel> GetAutoVersion(AutoVersionViewModel autoVersionViewModel);
        AutoVersionViewModel GetAutoVersionById(int Id);
    }
}
