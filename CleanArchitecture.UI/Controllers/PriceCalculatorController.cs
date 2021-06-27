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
        IPriceCalculatorService priceCalculatorService;

        public PriceCalculatorController(IAutoSolutionLookupService autoSolutionLookupService, IPriceCalculatorService priceCalculatorService)
        {
            this.autoSolutionLookupService = autoSolutionLookupService;
            this.priceCalculatorService = priceCalculatorService;
        }

        public IActionResult Index()
        {
            PriceCalculatorViewModel priceCalculatorViewModel = new PriceCalculatorViewModel();
            priceCalculatorViewModel.AutoProvinceLookup = autoSolutionLookupService.GetProvinceLookup();

            return View(priceCalculatorViewModel);
        }

        public IActionResult GetOnRoadPrice(PriceCalculatorViewModel priceCalculatorViewModel)
        {
            var result = priceCalculatorService.GetOnRoadPrice(priceCalculatorViewModel);

            return PartialView("_GetOnRoadPrice",result);
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
