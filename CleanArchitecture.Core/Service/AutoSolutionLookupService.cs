using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Service
{
    public class AutoSolutionLookupService : IAutoSolutionLookupService
    {
        private readonly IAutoSolutionLookupRepository autoSolutionLookupRepository;
        private AutoModelViewModel autoModelViewModel;
        public AutoSolutionLookupService(IAutoSolutionLookupRepository autoSolutionLookupRepository, AutoModelViewModel autoModelViewModel)
        {
            this.autoSolutionLookupRepository = autoSolutionLookupRepository;
            this.autoModelViewModel = autoModelViewModel;
        }
        public List<SelectListItem> GetAutoManufacturerLookup()
        {
            return autoSolutionLookupRepository.GetAutoManufacturerLookup();
        }

        public PagePermissionViewModel GetPagesPermissionLookUp()
        {
            return autoSolutionLookupRepository.GetPagesPermissionLookUp();
        }

        public List<SelectListItem> GetPermissionLookup()
        {
            return autoSolutionLookupRepository.GetPermissionLookup();
        }

        public List<SelectListItem> GetPermissionLookup(int RoleId)
        {
            return autoSolutionLookupRepository.GetPermissionLookup(RoleId);
        }

        public List<SelectListItem> GetRolesLookup()
        {
            return autoSolutionLookupRepository.GetRolesLookup();
        }


        public List<SelectListItem> GetRolesLookup(int UserId)
        {
            return autoSolutionLookupRepository.GetRolesLookup(UserId);
        }
    }
}
