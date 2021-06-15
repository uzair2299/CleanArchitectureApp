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
        public string AutoVersionName { get; set; }
        public string ModelName { get; set; }
        public string AutoManufacturerName { get; set; }
        public Decimal ExFactoryPrice { get; set; }

        public int EngineCapacity { get; set; }
        public Decimal WithHoldingTaxForFiler { get; set; }
        public Decimal WithHoldingTaxForNonFiler { get; set; }

        public List<SelectListItem> AutoManufacturerLookup { get; set; }
    }
}
