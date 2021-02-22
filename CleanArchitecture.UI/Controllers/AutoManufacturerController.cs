using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.Core.PageSet;
using System.Net;
using System.Net.Http;

namespace CleanArchitecture.UI.Controllers
{
    public class AutoManufacturerController : Controller
    {
        private IAutoManufacturerService autoManufacturerService;
        ViewDataSet viewDataSet;

        public AutoManufacturerController(IAutoManufacturerService autoManufacturerService, ViewDataSet viewDataSet)
        {
            this.autoManufacturerService = autoManufacturerService;
            this.viewDataSet = viewDataSet;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetAutoManufacturer(AutoManufacturerViewModel autoManufacturerViewModel)
        {
            AutoSolutionPageSet<AutoManufacturerViewModel> result = autoManufacturerService.GetAutoManufacturer(autoManufacturerViewModel);
            return PartialView("_GetAutoManufacturer", result);
        }

        [HttpGet]
        public IActionResult AutoManufacturerSave()
        {
            return PartialView("_AutoManufacturerPanel");
        }

        [HttpPost]
        public JsonResult AutoManufacturerSave(AutoManufacturerViewModel autoManufacturerViewModel)
        {
            
            if (autoManufacturerViewModel.Id > 0) {
              var result = autoManufacturerService.UpdateAutoManufacturer(autoManufacturerViewModel);
                return Json(new { status = result == true ? "Update" : "fail" ,data = autoManufacturerViewModel.Id});
            }
            else
            {
                var result = autoManufacturerService.AutoManufacturerSave(autoManufacturerViewModel);
                return Json(new { status = result!=null? "save":"exist", data = result });
            }
        }

        [HttpGet]
        public IActionResult EditAutoManufacturer(int Id)
        {
            var result  = autoManufacturerService.GetAutoManufacturerById(Id);
            return PartialView("_AutoManufacturerPanel",result);
        }

        [HttpDelete]
        public JsonResult DeleteAutoManufacturer(int Id)
        {
            var result = autoManufacturerService.DeleteAutoManufacturer(Id);
            return Json(new { status = result == true ? true : false});
        }
    }
}
