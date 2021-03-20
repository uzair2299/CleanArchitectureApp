using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.UI.Controllers
{
    public class AutoModelController : Controller
    {
        private IAutoModelService autoModelService;
        private IAutoSolutionLookupService autoSolutionLookupService;
        public AutoModelController(IAutoModelService autoModelService, IAutoSolutionLookupService autoSolutionLookupService)
        {
            this.autoModelService = autoModelService;
            this.autoSolutionLookupService = autoSolutionLookupService;
        }
        public IActionResult Index()
        {
            autoModelService.AutoModelSave(new AutoModelViewModel() { ModelName = "axc", AutoManufacturerId = 2 });
            return View();
        }


        [HttpGet]
        public IActionResult GetAutoModel(AutoModelViewModel autoModelViewModel)
        {
            //AutoSolutionPageSet<AutoModelViewModel> result = autoModelService.GetAutoManufacturer(autoManufacturerViewModel);
            return PartialView("_GetAutoModel");
        }

        [HttpGet]
        public IActionResult AutoModelSave()
        {
            AutoModelViewModel autoModelViewModel = new AutoModelViewModel();
            autoModelViewModel = autoSolutionLookupService.GetAutoManufacturerLookup();
            return PartialView("_AutoModelPanel",autoModelViewModel);
        }


    }
}
