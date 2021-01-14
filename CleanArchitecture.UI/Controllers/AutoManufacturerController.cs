using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.UI.Controllers
{
    public class AutoManufacturerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
