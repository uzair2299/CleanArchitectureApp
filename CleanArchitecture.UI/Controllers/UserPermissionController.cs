using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.UI.Controllers
{
    public class UserPermissionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
