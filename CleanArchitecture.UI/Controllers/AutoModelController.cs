using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.UI.Controllers
{
    public class AutoModelController : Controller
    {
        private IAutoModelService autoModelService;
        public AutoModelController(IAutoModelService autoModelService)
        {
            this.autoModelService = autoModelService;
        }
        public IActionResult Index()
        {
            autoModelService.AutoModelSave(new AutoModelViewModel() { ModelName = "axc", AutoManufacturerId = 2 });
            return View();
        }
    }
}
