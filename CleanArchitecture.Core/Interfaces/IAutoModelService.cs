using CleanArchitecture.Core.PageSet;
using CleanArchitecture.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IAutoModelService
    {
        AutoModelViewModel AutoModelSave(AutoModelViewModel autoModelViewModel);
        AutoSolutionPageSet<AutoModelViewModel> GetAutoModel(AutoModelViewModel autoModelViewModel);
        AutoModelViewModel GetAutoModelById(int Id);
    }
}
