using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IAutoSolutionLookupRepository
    {
        List<SelectListItem> GetAutoManufacturerLookup();
        List<SelectListItem> GetAutoModelLookup();
        List<SelectListItem> GetPermissionLookup();
        List<SelectListItem> GetPermissionLookup(int RoleId);
        public List<SelectListItem> GetRolesLookup();

    }
}
