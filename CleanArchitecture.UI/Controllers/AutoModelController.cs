using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.PageSet;
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
            return View();
        }


        [HttpGet]
        public IActionResult GetAutoModel(AutoModelViewModel autoModelViewModel)
        {
            AutoSolutionPageSet<AutoModelViewModel> result = new AutoSolutionPageSet<AutoModelViewModel>();
            result = autoModelService.GetAutoModel(autoModelViewModel);
            return PartialView("_GetAutoModel", result);
        }

        [HttpGet]
        public IActionResult AutoModelSave()
        {
            AutoModelViewModel autoModelViewModel = new AutoModelViewModel();
            autoModelViewModel.AutoManufacturerLookup = autoSolutionLookupService.GetAutoManufacturerLookup();
            return PartialView("_AutoModelPanel", autoModelViewModel);
        }

        [HttpPost]
        public IActionResult AutoModelSave(AutoModelViewModel autoModelViewModel)
        {
            if (autoModelViewModel.Id > 0) {
                var result = autoModelService.AutoModelSave(autoModelViewModel);
                return Json(new { status = result != null ? "save" : "exist", data = result });
            }
            else
            {
                var result = autoModelService.AutoModelSave(autoModelViewModel);
                return Json(new { status = result != null ? "save" : "exist", data = result });
            }
        }
        [HttpGet]
         public IActionResult EditAutoModel(int Id)
        {
            AutoModelViewModel autoModelViewModel = new AutoModelViewModel();
            autoModelViewModel= autoModelService.GetAutoModelById(Id);
            autoModelViewModel.AutoManufacturerLookup = autoSolutionLookupService.GetAutoManufacturerLookup();
            return PartialView("_AutoModelPanel", autoModelViewModel);
        }


    }
}
