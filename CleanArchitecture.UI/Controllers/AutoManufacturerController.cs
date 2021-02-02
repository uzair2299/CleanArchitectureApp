using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.Core.PageSet;

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

        public IActionResult Index(AutoManufacturerViewModel autoManufacturerViewModel)
        {
            AutoSolutionPageSet<AutoManufacturerViewModel> result = autoManufacturerService.GetAutoManufacturer(autoManufacturerViewModel);
            viewDataSet.AutoSolutionPageSet = result;
            return View(viewDataSet);
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
