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
    public class AutoVersionController : Controller
    {
        private IAutoVersionService autoVersionService;
        private IAutoSolutionLookupService autoSolutionLookupService;
        public AutoVersionController(IAutoVersionService autoVersionService, IAutoSolutionLookupService autoSolutionLookupService)
        {
            this.autoVersionService = autoVersionService;
            this.autoSolutionLookupService = autoSolutionLookupService;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult GetAutoVersion(AutoVersionViewModel autoVersionViewModel)
        {
            AutoSolutionPageSet<AutoVersionViewModel> result = new AutoSolutionPageSet<AutoVersionViewModel>();
            result = autoVersionService.GetAutoVersion(autoVersionViewModel);
            return PartialView("_GetAutoVersion", result);
        }

        [HttpGet]
        public IActionResult AutoVersionSave(bool isQuickAdd)
        {
            if (isQuickAdd)
            {
                AutoVersionViewModel autoVersionViewModel = new AutoVersionViewModel();
                //autoVersionViewModel = autoSolutionLookupService.GetAutoVersionLookUpData();
                //var dtp = autoSolutionLookupService.GetAutoVersionLookUpData();
                autoVersionViewModel = autoSolutionLookupService.GetAutoVersionLookUpData();
                return PartialView("_AutoVersionPanel", autoVersionViewModel);
            }
            else
            {
                AutoVersionViewModel autoVersionViewModel = new AutoVersionViewModel();
//                autoVersionViewModel.AutoManufacturerLookup = autoSolutionLookupService.GetAutoManufacturerLookup();
                autoVersionViewModel = autoSolutionLookupService.GetAutoVersionLookUpData();
                return View("AutoVersionSave", autoVersionViewModel);

            }
        }

        [HttpPost]
        public IActionResult AutoVersionSave(AutoVersionViewModel autoVersionViewModel)
        {
            if (autoVersionViewModel.Id > 0)
            {
                var result = autoVersionService.AutoVersionSave(autoVersionViewModel);
                return Json(new { status = result != null ? "save" : "exist", data = result });
            }
            else
            {
                var result = autoVersionService.AutoVersionSave(autoVersionViewModel);
                return Json(new { status = result != null ? "save" : "exist", data = result });
            }
        }
        [HttpGet]
        public IActionResult EditAutoVersion(int Id)
        {
            AutoVersionViewModel autoVersionViewModel = new AutoVersionViewModel();
            autoVersionViewModel = autoVersionService.GetAutoVersionById(Id);
            autoVersionViewModel.AutoManufacturerLookup = autoSolutionLookupService.GetAutoManufacturerLookup();
            return PartialView("_AutoVersionPanel", autoVersionViewModel);
        }
        public IActionResult GetAutoModelLookUp(int Id)
        {
            var result = autoSolutionLookupService.GetAutoModelLookup(Id);
            return Json(new { status = result != null ? true : false, data = result });
        }
    }
}
