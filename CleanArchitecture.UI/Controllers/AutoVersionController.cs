using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.PageSet;
using CleanArchitecture.Core.ViewModels;
using CleanArchitecture.UI.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private IFileUploadUtility fileUploadUtility;

        public AutoVersionController(IAutoVersionService autoVersionService,
            IAutoSolutionLookupService autoSolutionLookupService,
            IFileUploadUtility fileUploadUtility)
        {
            this.autoVersionService = autoVersionService;
            this.autoSolutionLookupService = autoSolutionLookupService;
            this.fileUploadUtility = fileUploadUtility;
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

                autoVersionViewModel.AutoSpecificationStr = strd(autoVersionViewModel.AutoSpecification);
                string[] str = fileUploadUtility.UplaodFile(autoVersionViewModel.GallaryImages);

                var result = autoVersionService.AutoVersionSave(autoVersionViewModel);


                AutoVersionViewModel autoVersionViewModel_ = new AutoVersionViewModel();
                //                autoVersionViewModel.AutoManufacturerLookup = autoSolutionLookupService.GetAutoManufacturerLookup();

                autoVersionViewModel_ = autoSolutionLookupService.GetAutoVersionLookUpData();
                return RedirectToAction("AutoVersionSave", false);
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

        private string strd(List<SelectListItem> selectListItems)
        {
            string str = "";
            str = string.Join(",", selectListItems.Where(x => x.Selected == true).Select(x => x.Value));
            return str;
        }
    }
}
