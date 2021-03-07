using CleanArchitecture.Core.PageSet;
using CleanArchitecture.Core.ViewModels;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IRolesRepository
    {
        bool DeleteRole(int Id);
        RolesViewModel SaveRole(Role role);
        AutoSolutionPageSet<RolesViewModel> GetRoles(RolesViewModel rolesViewModel);
        RolesViewModel GetRoleById(int Id);
        bool UpdateRole(Role role);
    }
}
