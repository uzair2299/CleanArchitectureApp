using CleanArchitecture.Core.ViewModels.BaseViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.ViewModels
{
    public class PriceCalculatorViewModel:AutoSolutionBaseViewModel
    {
        public List<SelectListItem> AutoManufacturerLookup { get; set; }
    }
}
