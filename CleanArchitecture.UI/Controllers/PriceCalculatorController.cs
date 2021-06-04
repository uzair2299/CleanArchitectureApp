using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.UI.Controllers
{
    public class PriceCalculatorController : Controller
    {
        IAutoSolutionLookupService autoSolutionLookupService;

        public PriceCalculatorController(IAutoSolutionLookupService autoSolutionLookupService)
        {
            this.autoSolutionLookupService = autoSolutionLookupService;
        }

        public IActionResult Index()
        {
            PriceCalculatorViewModel priceCalculatorViewModel = new PriceCalculatorViewModel();
            priceCalculatorViewModel.AutoManufacturerLookup = autoSolutionLookupService.GetAutoManufacturerLookup();
            return View(priceCalculatorViewModel);
        }

        public IActionResult GetOnRoadPrice(PriceCalculatorViewModel priceCalculatorViewModel)
        {
            return PartialView();
        }

        public IActionResult GetAutoModelLookUp(int Id)
        {
            var result = autoSolutionLookupService.GetAutoModelLookup(Id);
            return Json(new { status = result != null ? true : false, data = result });
        }

        public IActionResult GetAutoVersionLookUp(int Id)
        {
            var result = autoSolutionLookupService.GetAutoVersionLookup(Id);
            return Json(new { status = result != null ? true : false, data = result });
        }
    }
}
