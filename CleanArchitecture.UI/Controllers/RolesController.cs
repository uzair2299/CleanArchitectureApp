using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.PageSet;
using CleanArchitecture.Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.UI.Controllers
{
//    [Authorize]
    public class RolesController : Controller
    {
        private IRolesService rolesService;
        private IAutoSolutionLookupService autoSolutionLookupService;

        public RolesController(IRolesService rolesService,
            IAutoSolutionLookupService autoSolutionLookupService )
        {
            this.rolesService = rolesService;
            this.autoSolutionLookupService = autoSolutionLookupService;
        }

        public IActionResult Index() 
       
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetRoles(RolesViewModel rolesViewModel)
        {
            AutoSolutionPageSet<RolesViewModel> result = rolesService.GetRoles(rolesViewModel);
            return PartialView("_GetRoles", result);
        }

        [HttpGet]
        public IActionResult SaveRole()
        {

            RolesViewModel rolesViewModel = new RolesViewModel();
            rolesViewModel.PermissionLookup = autoSolutionLookupService.GetPermissionLookup();
            return PartialView("_RolesPanel", rolesViewModel);
        }

        [HttpPost]
        public JsonResult SaveRole(RolesViewModel rolesViewModel)
        {

            if (rolesViewModel.Id > 0)
            {
                var result = rolesService.UpdateRole(rolesViewModel);
                return Json(new { status = result == true ? "Update" : "fail", data = rolesViewModel.Id });
            }
            else
            {
                var result = rolesService.SaveRole(rolesViewModel);
                return Json(new { status = result != null ? "save" : "exist", data = result });
            }
        }

        [HttpGet]
        public IActionResult EditRole(int Id)
        {
            var result = rolesService.GetRoleById(Id);
           result.PermissionLookup = autoSolutionLookupService.GetPermissionLookup(result.Id);
            return PartialView("_RolesPanel", result);
        }

        [HttpDelete]
        public JsonResult DeleteRole(int Id)
        {
            var result = rolesService.DeleteRole(Id);
            return Json(new { status = result == true ? true : false });
        }

    }
}
