using CleanArchitecture.Core.ViewModels.BaseViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.ViewModels
{
    public class UserViewModel: AutoSolutionBaseViewModel
    {
        public UserViewModel()
        {
            RolesLookup = new List<SelectListItem>();
            pagePermissionViewModel = new PagePermissionViewModel();

        }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string DateOfBirth { get; set; }
        public bool IsActive { get; set; }
        public string ProfileImagePath { get; set; }
        public string PersonalAddress { get; set; }
        public string PrimaryMobile { get; set; }
        public string SecondaryMobile { get; set; }
        public string PrimaryPhone { get; set; }
        public string SecondaryPhone { get; set; }
        public string FaxNumber { get; set; }
        public int[] SelectedItems { get; set; }
        public List<SelectListItem> RolesLookup { get; set; }
        public PagePermissionViewModel pagePermissionViewModel { get; set; }

    }
}
