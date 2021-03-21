using CleanArchitecture.Core.PageSet;
using CleanArchitecture.Core.ViewModels;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IAutoModelRepository
    {
        AutoModelViewModel AutoModelSave(AutoModel autoModel);
        AutoSolutionPageSet<AutoModelViewModel> GetAutoModel(AutoModelViewModel autoModelViewModel);
    }
}
