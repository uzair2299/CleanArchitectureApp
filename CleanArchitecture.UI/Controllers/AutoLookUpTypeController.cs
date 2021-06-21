using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.PageSet;
using CleanArchitecture.Core.Service;
using CleanArchitecture.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.UI.Controllers
{
    public class AutoLookUpTypeController : Controller
    {
        IAutoLookUpTypeService AutoLookUpTypeService;
        public AutoLookUpTypeController(IAutoLookUpTypeService autoLookUpTypeService)
        {
            AutoLookUpTypeService = autoLookUpTypeService;
        }
        public IActionResult Index(AutoLookUpTypeViewModel autoLookUpTypeViewModel)
        {
            AutoSolutionPageSet<AutoLookUpTypeViewModel> result = AutoLookUpTypeService.GetAutoLookUpType(autoLookUpTypeViewModel);
            return View(result);
        }
        [HttpGet]
        public IActionResult GetAutoLookUpType(AutoLookUpTypeViewModel AutoLookUpTypeViewModel)
        {
            AutoSolutionPageSet<AutoLookUpTypeViewModel> result = AutoLookUpTypeService.GetAutoLookUpType(AutoLookUpTypeViewModel);
            return PartialView("_GetAutoLookUpType", result);
        }

        [HttpGet]
        public IActionResult AutoLookUpTypeSave()
        {
            return PartialView("_AutoLookUpTypePanel");
        }

        [HttpPost]
        public JsonResult AutoLookUpTypeSave(AutoLookUpTypeViewModel AutoLookUpTypeViewModel)
        {

            if (AutoLookUpTypeViewModel.Id > 0)
            {
                var result = AutoLookUpTypeService.UpdateAutoLookUpType(AutoLookUpTypeViewModel);
                return Json(new { status = result == true ? "Update" : "fail", data = AutoLookUpTypeViewModel.Id });
            }
            else
            {
                var result = AutoLookUpTypeService.AutoLookUpTypeSave(AutoLookUpTypeViewModel);
                return Json(new { status = result != null ? "save" : "exist", data = result });
            }
        }

        [HttpGet]
        public IActionResult EditAutoLookUpType(int Id)
        {
            var result = AutoLookUpTypeService.GetAutoLookUpTypeById(Id);
            return PartialView("_AutoLookUpTypePanel", result);
        }

        [HttpDelete]
        public JsonResult DeleteAutoLookUpType(int Id)
        {
            var result = AutoLookUpTypeService.DeleteAutoLookUpType(Id);
            return Json(new { status = result == true ? true : false });
        }
    }
}
