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
    public class AutoSpecificationSubController : Controller
    {
        private IAutoSpecificationSubService AutoSpecificationSubService;
        private IAutoSolutionLookupService autoSolutionLookupService;
        public AutoSpecificationSubController(IAutoSpecificationSubService AutoSpecficationService, IAutoSolutionLookupService autoSolutionLookupService)
        {
            this.AutoSpecificationSubService = AutoSpecficationService;
            this.autoSolutionLookupService = autoSolutionLookupService;
        }
        public IActionResult Index(AutoSpecificationSubViewModel AutoSpecificationSubViewModel)
        {
            AutoSolutionPageSet<AutoSpecificationSubViewModel> result = new AutoSolutionPageSet<AutoSpecificationSubViewModel>();
            result = AutoSpecificationSubService.GetAutoSpecificationSub(AutoSpecificationSubViewModel);

            return View(result);
        }


        [HttpGet]
        public IActionResult GetAutoSpecificationSub(AutoSpecificationSubViewModel AutoSpecificationSubViewModel)
        {
            AutoSolutionPageSet<AutoSpecificationSubViewModel> result = new AutoSolutionPageSet<AutoSpecificationSubViewModel>();
            result = AutoSpecificationSubService.GetAutoSpecificationSub(AutoSpecificationSubViewModel);
            return PartialView("_GetAutoSpecificationSub", result);
        }

        [HttpGet]
        public IActionResult AutoSpecificationSubSave()
        {
            AutoSpecificationSubViewModel AutoSpecificationSubViewModel = new AutoSpecificationSubViewModel();
            AutoSpecificationSubViewModel.AutoSpecificationSubTypeLookUp = autoSolutionLookupService.GetAutoSpecfication();
            return PartialView("_AutoSpecificationSubPanel", AutoSpecificationSubViewModel);
        }

        [HttpPost]
        public IActionResult AutoSpecificationSubSave(AutoSpecificationSubViewModel AutoSpecificationSubViewModel)
        {
            if (AutoSpecificationSubViewModel.Id > 0)
            {
                var result = AutoSpecificationSubService.AutoSpecificationSubSave(AutoSpecificationSubViewModel);
                return Json(new { status = result != null ? "save" : "exist", data = result });
            }
            else
            {
                var result = AutoSpecificationSubService.AutoSpecificationSubSave(AutoSpecificationSubViewModel);
                return Json(new { status = result != null ? "save" : "exist", data = result });
            }
        }
        [HttpGet]
        public IActionResult EditAutoSpecificationSub(int Id)
        {
            AutoSpecificationSubViewModel AutoSpecificationSubViewModel = new AutoSpecificationSubViewModel();
            AutoSpecificationSubViewModel = AutoSpecificationSubService.GetAutoSpecificationSubById(Id);
            AutoSpecificationSubViewModel.AutoSpecificationSubTypeLookUp = autoSolutionLookupService.GetAutoSpecfication();
            return PartialView("_AutoSpecificationSubPanel", AutoSpecificationSubViewModel);
        }
        [HttpGet]
        public IActionResult GetSpecficationParameterLookup(int Id)
        {
            var result = autoSolutionLookupService.GetSpecficationParameterLookup(Id);
            return Json(new { status = result != null ? true : false, data = result });
        }

    }
}
