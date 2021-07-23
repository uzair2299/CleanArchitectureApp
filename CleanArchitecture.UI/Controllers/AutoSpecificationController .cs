using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.PageSet;
using CleanArchitecture.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.UI.Controllers
{
    public class AutoSpecificationController : Controller
    {
        private IAutoSpecificationService AutoSpecificationService;
        private IAutoSolutionLookupService autoSolutionLookupService;
        public AutoSpecificationController(IAutoSpecificationService AutoSpecficationService, IAutoSolutionLookupService autoSolutionLookupService)
        {
            this.AutoSpecificationService = AutoSpecficationService;
            this.autoSolutionLookupService = autoSolutionLookupService;
        }
        public IActionResult Index(AutoSpecificationViewModel AutoSpecificationViewModel)
        {
            AutoSolutionPageSet<AutoSpecificationViewModel> result = new AutoSolutionPageSet<AutoSpecificationViewModel>();
            result = AutoSpecificationService.GetAutoSpecification(AutoSpecificationViewModel);

            return View(result);
        }


        [HttpGet]
        public IActionResult GetAutoSpecification(AutoSpecificationViewModel AutoSpecificationViewModel)
        {
            AutoSolutionPageSet<AutoSpecificationViewModel> result = new AutoSolutionPageSet<AutoSpecificationViewModel>();
            result = AutoSpecificationService.GetAutoSpecification(AutoSpecificationViewModel);
            return PartialView("_GetAutoSpecification", result);
        }

        [HttpGet]
        public IActionResult AutoSpecificationSave()
        {
            AutoSpecificationViewModel AutoSpecificationViewModel = new AutoSpecificationViewModel();
            AutoSpecificationViewModel.AutoSpecificationTypeLookUp = autoSolutionLookupService.GetAutoSpecfication();
            return PartialView("_AutoSpecificationPanel", AutoSpecificationViewModel);
        }

        [HttpPost]
        public IActionResult AutoSpecificationSave(AutoSpecificationViewModel AutoSpecificationViewModel)
        {
            if (AutoSpecificationViewModel.Id > 0) {
                var result = AutoSpecificationService.AutoSpecificationSave(AutoSpecificationViewModel);
                return Json(new { status = result != null ? "save" : "exist", data = result });
            }
            else
            {
                var result = AutoSpecificationService.AutoSpecificationSave(AutoSpecificationViewModel);
                return Json(new { status = result != null ? "save" : "exist", data = result });
            }
        }
        [HttpGet]
        public IActionResult EditAutoSpecification(int Id)
        {
            AutoSpecificationViewModel AutoSpecificationViewModel = new AutoSpecificationViewModel();
            AutoSpecificationViewModel= AutoSpecificationService.GetAutoSpecificationById(Id); 
            AutoSpecificationViewModel.AutoSpecificationTypeLookUp = autoSolutionLookupService.GetAutoSpecfication();
            return PartialView("_AutoSpecificationPanel", AutoSpecificationViewModel);
        }


    }
}
