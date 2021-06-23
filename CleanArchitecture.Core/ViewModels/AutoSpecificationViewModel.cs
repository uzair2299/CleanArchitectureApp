using CleanArchitecture.Core.ViewModels.BaseViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.ViewModels
{
    public class AutoSpecificationViewModel :AutoSolutionBaseViewModel
    {
        public AutoSpecificationViewModel()
        {
            AutoSpecificationTypeLookUp = new List<SelectListItem>();
        }
        public string SpecificationType { get; set; }
        public string SpecificationParameter { get; set; }
        public List<SelectListItem> AutoSpecificationTypeLookUp { get; set; }
    }
}
