﻿using CleanArchitecture.Core.ViewModels.BaseViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.ViewModels
{
    public class AutoVersionViewModel:AutoSolutionBaseViewModel
    {
        public string AutoVersionName { get; set; }
        public string ModelName { get; set; }
        public string AutoManufacturerName { get; set; }
        
        public string SelectedAutoModel { get; set; }
        public List<SelectListItem> AutoModelLookup { get; set; }
        
        public string SelectedManufacturer { get; set; }
        public List<SelectListItem> AutoManufacturerLookup { get; set; }

    }
}