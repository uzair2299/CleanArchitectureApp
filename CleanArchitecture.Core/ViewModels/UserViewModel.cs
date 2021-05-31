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
        }
        public string UserName { get; set; }
        public int[] SelectedItems { get; set; }
        public List<SelectListItem> RolesLookup { get; set; }

    }
}
