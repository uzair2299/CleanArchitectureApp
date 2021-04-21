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
    public class AutoBodyTypeController : Controller
    {
        private IAutoBodyTypeService autoBodyTypeService;
        public AutoBodyTypeController(IAutoBodyTypeService autoBodyTypeService)
        {
            this.autoBodyTypeService = autoBodyTypeService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAutoBodyType(AutoBodyTypeViewModel autoBodyTypeViewModel)
        {
            AutoSolutionPageSet<AutoBodyTypeViewModel> result = autoBodyTypeService.GetAutoBodyType(autoBodyTypeViewModel);
            return PartialView("_GetAutoBodyType", result);
        }

        [HttpGet]
        public IActionResult AutoBodyTypeSave()
        {
            return PartialView("_AutoBodyTypePanel");
        }

        [HttpPost]
        public JsonResult AutoBodyTypeSave(AutoBodyTypeViewModel autoBodyTypeViewModel)
        {

            if (autoBodyTypeViewModel.Id > 0)
            {
                var result = autoBodyTypeService.UpdateAutoBodyType(autoBodyTypeViewModel);
                return Json(new { status = result == true ? "Update" : "fail", data = autoBodyTypeViewModel.Id });
            }
            else
            {
                var result = autoBodyTypeService.AutoBodyTypeSave(autoBodyTypeViewModel);
                return Json(new { status = result != null ? "save" : "exist", data = result });
            }
        }

        [HttpGet]
        public IActionResult EditAutoBodyType(int Id)
        {
            var result = autoBodyTypeService.GetAutoBodyTypeById(Id);
            return PartialView("_AutoBodyTypePanel", result);
        }

        [HttpDelete]
        public JsonResult DeleteAutoBodyType(int Id)
        {
            var result = autoBodyTypeService.DeleteAutoBodyType(Id);
            return Json(new { status = result == true ? true : false });
        }
    }
}
