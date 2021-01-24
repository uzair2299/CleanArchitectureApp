using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.UI.Controllers
{
    public class AutoManufacturerController : Controller
    {
        private IAutoManufacturerService autoManufacturerService;

        public AutoManufacturerController(IAutoManufacturerService autoManufacturerService)
        {
            this.autoManufacturerService = autoManufacturerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AutoManufacturerSave()
        {
            return PartialView("_AutoManufacturerPanel");
        }

        [HttpPost]
        public IActionResult AutoManufacturerSave(AutoManufacturerViewModel autoManufacturerViewModel)
        {
            autoManufacturerService.AutoManufacturerSave(autoManufacturerViewModel);
            return PartialView("_AutoManufacturerPanel");
        }
    }
}
