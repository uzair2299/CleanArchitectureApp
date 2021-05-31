using AutoMapper;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.PageSet;
using CleanArchitecture.Core.ViewModels;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Interfaces;
using CleanArchitecture.Infrastructure.Utility;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class RolesRepository : IRolesRepository
    {
        private readonly IRepository<Role> repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper autoMapper;

        #region store procedure parameters
        private const string RoleId = "@RoleId";
        private const string RoleName = "@RoleName";
        private const string RolePermissions = "@RolePermissions";
        private const string OutPutResult = "@OutPutResult";

        #endregion

        public RolesRepository(IUnitOfWork unitOfWork, IRepository<Role> repository, IMapper autoMapper = null)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.autoMapper = autoMapper;
        }
        public bool DeleteRole(int Id)
        {
            var result = repository.Remove(Id);
            if (result)
            {
                unitOfWork.SaveChanges();
                return result;
            }
            return result;
        }

        public RolesViewModel GetRoleById(int Id)
        {
            var result = repository.GetById(Id);
            return autoMapper.Map<RolesViewModel>(result);
        }

        public AutoSolutionPageSet<RolesViewModel> GetRoles(RolesViewModel rolesViewModel)
        {
            List<Role> finalResult = new List<Role>();
            IQueryable<Role> result = unitOfWork.GetAutoSolutionContext().Roles.AsQueryable();
            if (rolesViewModel.SearchTerm != null)
            {
                result = result.Where(x => x.RoleName.Contains(rolesViewModel.SearchTerm));
            }
            Pager pager = new Pager(result.Count(), rolesViewModel.PageNo, rolesViewModel.PageSize);
            finalResult = result.OrderBy(x => x.RoleName).Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize).ToList();
            AutoSolutionPageSet<RolesViewModel> autoSolutionPageSet = new AutoSolutionPageSet<RolesViewModel>()
            {
                Pager = pager,
                Data = autoMapper.Map<List<RolesViewModel>>(finalResult)
            };
            return autoSolutionPageSet;
        }

        public string SaveRole(RolesViewModel rolesViewModel)
        {
            using (var db = unitOfWork.GetAutoSolutionContext().Database.GetDbConnection())
            {
                db.Open();
                var permissions = "";
                if (rolesViewModel.SelectedItems != null)
                {
                     permissions = string.Join(',', rolesViewModel.SelectedItems);
                }
                else
                {
                    permissions = null;
                }
                var result = db.Query<string>(AutoSolutionStoreProcedureUtility.InsertRole,
                    new { RoleName = rolesViewModel.RoleName,
                        RolePermissions = permissions
                    }, commandType: CommandType.StoredProcedure);
                return result.ToString();
            }

            //var  role = autoMapper.Map<Role>(rolesViewModel);
            //var alreadyExist = RoleAlreadyExist(role);
            //if (!alreadyExist)
            //{
            //    var result = repository.Add(role);
            //    unitOfWork.SaveChanges();
            //    return autoMapper.Map<RolesViewModel>(result);
            //}
            //else
            //{
              // return null;
            //}

        }

        public bool UpdateRole(RolesViewModel rolesViewModel)
        {
            var permissions = "";
            using (var db = unitOfWork.GetAutoSolutionContext().Database.GetDbConnection())
            {
                db.Open();
                if (rolesViewModel.SelectedItems != null)
                {
                    permissions = string.Join(',', rolesViewModel.SelectedItems);
                }
                else
                {
                    permissions = null;
                }

                DynamicParameters parameter = new DynamicParameters();
                parameter.Add(RoleId, rolesViewModel.Id, DbType.Int32, ParameterDirection.Input);
                parameter.Add(RoleName, rolesViewModel.RoleName, DbType.String, ParameterDirection.Input);
                parameter.Add(RolePermissions, permissions, DbType.String, ParameterDirection.Input);
                parameter.Add(OutPutResult, permissions, DbType.Boolean, ParameterDirection.Output);

                //new { RoleId = rolesViewModel.Id, RoleName = rolesViewModel.RoleName, RolePermissions = permissions },
                db.Execute(AutoSolutionStoreProcedureUtility.UpdateRole,parameter,
                    commandType: CommandType.StoredProcedure);
                var result = parameter.Get<dynamic>(OutPutResult);
                return result;
            }

            //var checkAlreadyExist = repository.GetById(role.Id);
            //if (checkAlreadyExist != null)
            //{
            //    unitOfWork.GetAutoSolutionContext().Entry(checkAlreadyExist).State = EntityState.Detached;
            //    checkAlreadyExist = autoMapper.Map<Role>(role);
            //    repository.Update(checkAlreadyExist);
            //    autoMapper.Map<RolesViewModel>(checkAlreadyExist);
            //    var resultbool = unitOfWork.SaveChanges();
            //    return resultbool == true ? true : false;
            //}
            //else
            //    return false;
        }


        private bool RoleAlreadyExist(Role role)
        {
            var result = (from item in unitOfWork.GetAutoSolutionContext().Roles
                          where (item.RoleName == role.RoleName)
                          select item).FirstOrDefault();
            return result != null ? true : false;
        }
    }
}
