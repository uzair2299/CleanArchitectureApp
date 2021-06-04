using CleanArchitecture.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.ViewModels
{
    public class PagePermissionViewModel
    {
        public PagePermissionViewModel()
        {
            PagePermissions = new List<AppControllerDTO>();
            Roles = new List<RolesDTO>();
        }
        public List<AppControllerDTO> PagePermissions { get; set; }
        public List<RolesDTO> Roles { get; set; } 
    } 
}
