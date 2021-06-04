using CleanArchitecture.Core.ViewModels.BaseViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.ViewModels
{
    public class PriceCalculatorViewModel
    {
        public int SelectedAutoManufacturer { get; set; }
        public int SelectedAutoModel { get; set; }
        public int SelectedAutoVersion { get; set; }
        public string SelectedAutoManufacturerText { get; set; }
        public string SelectedAutoModelText { get; set; }
        public string SelectedAutoVersionText { get; set; }
        public List<SelectListItem> AutoManufacturerLookup { get; set; }
    }
}
