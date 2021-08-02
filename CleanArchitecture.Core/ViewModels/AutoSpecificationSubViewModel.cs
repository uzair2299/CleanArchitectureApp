using CleanArchitecture.Core.ViewModels.BaseViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.ViewModels
{
    public class AutoSpecificationSubViewModel :AutoSolutionBaseViewModel
    {
        public AutoSpecificationSubViewModel()
        {
            AutoSpecificationSubTypeLookUp = new List<SelectListItem>();
        }
        public string SpecificationSubParameter { get; set; }
        public string SpecificationType { get; set; }
        public string SpecificationParameter { get; set; }
        public int SelectedSpecificationParameter { get; set; }
        public List<SelectListItem> AutoSpecificationSubTypeLookUp { get; set; }
    }
}
