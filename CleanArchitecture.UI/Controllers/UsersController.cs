﻿using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.PageSet;
using CleanArchitecture.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.UI.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService UserService;

        public UsersController(IUserService userService)
        {
            UserService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetUser(UserViewModel UserViewModel)
        {
            AutoSolutionPageSet<UserViewModel> result = UserService.GetUser(UserViewModel);
            return PartialView("_GetUsers", result);
        }

        [HttpGet]
        public IActionResult UserSave()
        {
            return PartialView("_UserPanel");
        }

        [HttpPost]
        public JsonResult UserSave(UserViewModel UserViewModel)
        {

            if (UserViewModel.Id > 0)
            {
                var result = UserService.UpdateUser(UserViewModel);
                return Json(new { status = result == true ? "Update" : "fail", data = UserViewModel.Id });
            }
            else
            {
                var result = UserService.UserSave(UserViewModel);
                return Json(new { status = result != null ? "save" : "exist", data = result });
            }
        }

        [HttpGet]
        public IActionResult EditUser(int Id)
        {
            var result = UserService.GetUserById(Id);
            return PartialView("_UserPanel", result);
        }

        [HttpDelete]
        public JsonResult DeleteUser(int Id)
        {
            var result = UserService.DeleteUser(Id);
            return Json(new { status = result == true ? true : false });
        }

    }
}
