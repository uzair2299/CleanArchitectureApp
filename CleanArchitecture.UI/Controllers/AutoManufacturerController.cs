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
    public class AutoManufacturerController : Controller
    {
        private IAutoManufacturerService autoManufacturerService;
        private IFileUploadUtility fileUploadUtility;
        public AutoManufacturerController(IAutoManufacturerService autoManufacturerService, ViewDataSet viewDataSet, IFileUploadUtility fileUploadUtility)
        {
            this.autoManufacturerService = autoManufacturerService;
            this.fileUploadUtility = fileUploadUtility;
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
            AutoManufacturerViewModel autoManufacturerViewModel = new AutoManufacturerViewModel();
            return PartialView("_AutoManufacturerPanel", autoManufacturerViewModel);
        }

        [HttpPost]
        public JsonResult AutoManufacturerSave(AutoManufacturerViewModel autoManufacturerViewModel, IFormFile ImageFile)
        {
            if (ImageFile == null || ImageFile.Length == 0)
            {
                //autoManufacturerViewModel.ImagePath = null;
            }
            else
            {
                // delete image
                string ImagePath = fileUploadUtility.UplaodFile(ImageFile);
                autoManufacturerViewModel.ImagePath = ImagePath;
            }

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
