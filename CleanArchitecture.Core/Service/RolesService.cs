using AutoMapper;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.PageSet;
using CleanArchitecture.Core.ViewModels;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Service
{
    public class RolesService : IRolesService
    {
        private readonly IRolesRepository rolesRepository;
        private readonly IMapper autoMapper;
        private Role role;

        public RolesService(IRolesRepository rolesRepository, IMapper autoMapper, Role role)
        {
            this.rolesRepository = rolesRepository;
            this.autoMapper = autoMapper;
            this.role = role;
        }

        public bool DeleteRole(int Id)
        {
            return rolesRepository.DeleteRole(Id);
        }

        public RolesViewModel GetRoleById(int Id)
        {
            return rolesRepository.GetRoleById(Id);
        }

        public AutoSolutionPageSet<RolesViewModel> GetRoles(RolesViewModel rolesViewModel)
        {
            return rolesRepository.GetRoles(rolesViewModel);
        }

        public RolesViewModel SaveRole(RolesViewModel rolesViewModel)
        {
            role = autoMapper.Map<Role>(rolesViewModel);
            return rolesRepository.SaveRole(role);
        }

        public bool UpdateRole(RolesViewModel rolesViewModel)
        {
            role = autoMapper.Map<Role>(rolesViewModel);
            return rolesRepository.UpdateRole(role);
        }
    }
}
