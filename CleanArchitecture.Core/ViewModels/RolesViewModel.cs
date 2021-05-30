using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.ViewModels
{
    public class RolesViewModel
    {
        public RolesViewModel()
        {
            PageNo = 1;
            PageSize = 10;
        }
        public int Id { get; set; }

        public string RoleName { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }
        public List<SelectListItem> PermissionLookup { get; set; }

        public string SearchTerm { get; set; }
        public int PageNo { get; set; }

        public int PageSize { get; set; }

        public int[] SelectedItems { get; set; }
    }
}
