﻿using CleanArchitecture.Core.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IAutoSolutionLookupService
    {
        public List<SelectListItem> GetAutoManufacturerLookup();
        public List<SelectListItem> GetPermissionLookup();
        public List<SelectListItem> GetPermissionLookup(int RoleId);
        public List<SelectListItem> GetRolesLookup();
        public List<SelectListItem> GetRolesLookup(int UserId);


    }
}
