using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.PageSet;
using CleanArchitecture.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.UI.Controllers
{
    public class AutoController : Controller
    {
        private IAutoManufacturerService autoManufacturerService;

        public AutoController(IAutoManufacturerService autoManufacturerService)
        {
            this.autoManufacturerService = autoManufacturerService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult GetAutoManufacturerU(DTParameters dTParameters)
        {
            PageSet<AutoManufacturerViewModel> data = autoManufacturerService.GetAutoManufacturerDT(dTParameters);
            
            return Json(data);
        }
    }
}
