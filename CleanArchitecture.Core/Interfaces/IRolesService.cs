using CleanArchitecture.Core.PageSet;
using CleanArchitecture.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IRolesService
    {
        bool DeleteRole(int Id);
        string SaveRole(RolesViewModel roleViewModel);
        AutoSolutionPageSet<RolesViewModel> GetRoles(RolesViewModel roleViewModel);
        RolesViewModel GetRoleById(int Id);
        bool UpdateRole(RolesViewModel roleViewModel);
    }
}
