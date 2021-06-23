using CleanArchitecture.Core.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IAutoSolutionLookupRepository
    {
        List<SelectListItem> GetAutoManufacturerLookup();
        List<SelectListItem> GetAutoModelLookup(int Id);
        List<SelectListItem> GetAutoVersionLookup(int Id);
        List<SelectListItem> GetAutoModelLookup();
        List<SelectListItem> GetPermissionLookup();
        List<SelectListItem> GetPermissionLookup(int RoleId);
        public List<SelectListItem> GetRolesLookup();
        public List<SelectListItem> GetRolesLookup(int UserId);
        public PagePermissionViewModel GetPagesPermissionLookUp();
        public AutoVersionViewModel GetAutoVersionLookUpData();
        public List<SelectListItem> GetAutoSpecficationType();


    }
}
