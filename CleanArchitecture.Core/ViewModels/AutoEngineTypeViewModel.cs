using CleanArchitecture.Core.ViewModels.BaseViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.ViewModels
{
    public class AutoEngineTypeViewModel : AutoSolutionBaseViewModel
    {
        public string EngineTypeName { get; set; }

        public string Description { get; set; }
    }
}
