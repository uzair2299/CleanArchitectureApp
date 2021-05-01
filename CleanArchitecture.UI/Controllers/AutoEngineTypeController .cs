using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.Core.PageSet;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using CleanArchitecture.UI.Utility;

namespace CleanArchitecture.UI.Controllers
{
    public class AutoEngineTypeController : Controller
    {
        private IAutoEngineTypeService autoEngineTypeService;
        private IFileUploadUtility fileUploadUtility;
        public AutoEngineTypeController(IAutoEngineTypeService autoEngineTypeService, ViewDataSet viewDataSet, IFileUploadUtility fileUploadUtility)
        {
            this.autoEngineTypeService = autoEngineTypeService;
            this.fileUploadUtility = fileUploadUtility;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetAutoEngineType(AutoEngineTypeViewModel autoEngineTypeViewModel)
        {
            AutoSolutionPageSet<AutoEngineTypeViewModel> result = autoEngineTypeService.GetAutoEngineType(autoEngineTypeViewModel);
            return PartialView("_GetAutoEngineType", result);
        }

        [HttpGet]
        public IActionResult AutoEngineTypeSave()
        {
            return PartialView("_AutoEngineTypePanel");
        }

        [HttpPost]
        public JsonResult AutoEngineTypeSave(AutoEngineTypeViewModel autoEngineTypeViewModel, IFormFile ImageFile)
        {
            

            if (autoEngineTypeViewModel.Id > 0) {
              var result = autoEngineTypeService.UpdateAutoEngineType(autoEngineTypeViewModel);
                return Json(new { status = result == true ? "Update" : "fail" ,data = autoEngineTypeViewModel.Id});
            }
            else
            {
                var result = autoEngineTypeService.AutoEngineTypeSave(autoEngineTypeViewModel);
                return Json(new { status = result!=null? "save":"exist", data = result });
            }
        }

        [HttpGet]
        public IActionResult EditAutoEngineType(int Id)
        {
            var result  = autoEngineTypeService.GetAutoEngineTypeById(Id);
            return PartialView("_AutoEngineTypePanel",result);
        }

        [HttpDelete]
        public JsonResult DeleteAutoEngineType(int Id)
        {
            var result = autoEngineTypeService.DeleteAutoEngineType(Id);
            return Json(new { status = result == true ? true : false});
        }
    }
}
