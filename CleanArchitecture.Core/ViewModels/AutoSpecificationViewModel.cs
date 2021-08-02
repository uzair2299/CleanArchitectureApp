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
        public int SpecificationTypeId { get; set; }
        public string SpecificationParameter { get; set; }
        public int SelectedSpecificationType { get; set; }
        public string SelectedSpecificationTypeText { get; set; }
        public int SelectedSpecificationParameter { get; set; }
        public string SelectedSpecificationParameterText { get; set; }
        public List<SelectListItem> AutoSpecificationTypeLookUp { get; set; }
    }
}
