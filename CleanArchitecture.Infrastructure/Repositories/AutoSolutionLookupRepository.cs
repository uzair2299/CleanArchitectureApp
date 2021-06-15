using AutoMapper;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.ViewModels;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Interfaces;
using CleanArchitecture.Infrastructure.Utility;
using Dapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class AutoSolutionLookupRepository : IAutoSolutionLookupRepository
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper autoMapper;
        public AutoSolutionLookupRepository(IMapper autoMapper, IUnitOfWork unitOfWork)
        {
            this.autoMapper = autoMapper;
            this.unitOfWork = unitOfWork;
        }
        public List<SelectListItem> GetAutoManufacturerLookup()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            var PopularGroup = new SelectListGroup { Name = "Popular Manufacturer" };
            var OtherGroup = new SelectListGroup { Name = "Other Manufacturer" };
            IQueryable<AutoManufacturer> result = unitOfWork.GetAutoSolutionContext().AutoManufacturers.AsQueryable();
            selectListItems =  result.Select(x => new SelectListItem()
            {
                Text = x.AutoManufacturerName,
                Value = x.Id.ToString(),
                Group = x.IsPopular?PopularGroup:OtherGroup
            }).OrderBy(x=>x.Text).ToList();
            selectListItems =  selectListItems.OrderByDescending(x => x.Group.Name).ToList();

            //using (var c = unitOfWork.GetAutoSolutionContext().Database.GetDbConnection())
            //{
            //    var result = c.Query()
            //};
            //var c = unitOfWork.GetAutoSolutionContext().Database.GetDbConnection();
            //c.Open();
            //var command = c.CreateCommand();
            //command.CommandText = "EXEC " + AutoSolutionStoreProcedureUtility.LookupForAutoVersion;
            //try
            //{

            //    List<SelectListItem> selectListItems1 = new List<SelectListItem>();
            //    List<SelectListItem> selectListItems2 = new List<SelectListItem>();
            //    using (var reader = command.ExecuteReader())
            //    {
            //        if (reader.HasRows)
            //        {

            //            while (reader.Read())
            //            {
            //                selectListItems1.Add(new SelectListItem
            //                {
            //                    Text = reader["BodyType"].ToString(),
            //                    Value = Convert.ToInt32(reader["Id"]).ToString()
            //                });
            //            }

            //            reader.NextResult();
            //            while (reader.Read())
            //            {
            //                selectListItems2.Add(new SelectListItem
            //                {
            //                    Text = reader["EngineTypeName"].ToString(),
            //                    Value = Convert.ToInt32(reader["Id"]).ToString()
            //                });
            //            }
            //        }
            //        }

            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            //selectListItems.Insert(0, new SelectListItem() { Text = "Select", Value = null });

            return selectListItems;
        }

        public List<SelectListItem> GetAutoModelLookup(int Id)
        {
            var PopularGroup = new SelectListGroup { Name = "Popular Models" };
            var OtherGroup = new SelectListGroup { Name = "Other Models" };
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems = unitOfWork.GetAutoSolutionContext().AutoModels.Where(x => x.AutoManufacturerId == Id).OrderBy(x=>x.ModelName).Select(x => new SelectListItem()
            {
                Text = x.ModelName,
                Value = x.Id.ToString(),
                Group = x.IsPopular?PopularGroup:OtherGroup
            }).ToList();
            selectListItems = selectListItems.OrderByDescending(x => x.Group.Name).ToList();
            if (selectListItems.Count > 1)
            {
                //SelectListItem selectListItem = new SelectListItem()
                //{
                //    Text = "Select Model",
                //    Value = ""
                //};
                //selectListItems.Insert(0, selectListItem);
                return selectListItems;
            }
            else
            {
                SelectListItem selectListItem = new SelectListItem()
                {
                    Text = "Select Model",
                    Value = ""
                };
                selectListItems.Add(selectListItem);
                return selectListItems;
            }


        }

        public List<SelectListItem> GetAutoVersionLookup(int Id)
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems = unitOfWork.GetAutoSolutionContext().AutoVersion.Where(x => x.AutoModelId == Id).OrderBy(x => x.AutoVersionName).Select(x => new SelectListItem()
            {
                Text = x.AutoVersionName,
                Value = x.Id.ToString(),

            }).ToList();
            return selectListItems;
        }
        public List<SelectListItem> GetAutoModelLookup()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            IQueryable<AutoModel> result = unitOfWork.GetAutoSolutionContext().AutoModels.AsQueryable();
            selectListItems = result.Select(x => new SelectListItem()
            {
                Text = x.ModelName,
                Value = x.Id.ToString()
            }).OrderBy(x => x.Text).ToList();
            return selectListItems;
        }

        public List<SelectListItem> GetPermissionLookup()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            var permissions = unitOfWork.GetAutoSolutionContext().RolePermissions.Where(x => x.RoleId == 3).ToList();
            IQueryable<Permission> result = unitOfWork.GetAutoSolutionContext().Permissions.Where(x => x.IsActive == true).OrderBy(x => x.ActionName).AsQueryable();
            selectListItems = result.Select(x => new SelectListItem()
            {
                Text = x.ActionName,
                Value = x.Id.ToString(),
            }).ToList();
            foreach(var item in permissions)
            {
                foreach(var innerItem in selectListItems)
                {
                    if (Convert.ToInt32(innerItem.Value) == item.PermissionId)
                    {
                        innerItem.Selected = true;
                    }
                }
            }
            return selectListItems;
        }

        public List<SelectListItem> GetPermissionLookup(int RoleId)
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            var permissions = unitOfWork.GetAutoSolutionContext().RolePermissions.Where(x => x.RoleId == RoleId).ToList();
            IQueryable<Permission> result = unitOfWork.GetAutoSolutionContext().Permissions.Where(x => x.IsActive == true).OrderBy(x => x.ActionName).AsQueryable();
            selectListItems = result.Select(x => new SelectListItem()
            {
                Text = x.ActionName,
                Value = x.Id.ToString(),
            }).ToList();
            foreach (var item in permissions)
            {
                foreach (var innerItem in selectListItems)
                {
                    if (Convert.ToInt32(innerItem.Value) == item.PermissionId)
                    {
                        innerItem.Selected = true;
                    }
                }
            }
            return selectListItems;
        }

        public List<SelectListItem> GetRolesLookup()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            IQueryable<Role> result = unitOfWork.GetAutoSolutionContext().Roles.AsQueryable();
            selectListItems = result.Select(x => new SelectListItem()
            {
                Text = x.RoleName,
                Value = x.Id.ToString()
            }).OrderBy(x => x.Text).ToList();
            return selectListItems;
        }

        public List<SelectListItem> GetRolesLookup(int UserId)
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            var userRoles = unitOfWork.GetAutoSolutionContext().UserRoles.Where(x => x.UserId == UserId).ToList();
            IQueryable<Role> result = unitOfWork.GetAutoSolutionContext().Roles.Where(x => x.IsActive == true).OrderBy(x => x.RoleName).AsQueryable();
            selectListItems = result.Select(x => new SelectListItem()
            {
                Text = x.RoleName,
                Value = x.Id.ToString(),
            }).ToList();
            foreach (var item in userRoles)
            {
                foreach (var innerItem in selectListItems)
                {
                    if (Convert.ToInt32(innerItem.Value) == item.RoleId)
                    {
                        innerItem.Selected = true;
                    }
                }
            }
            return selectListItems;
        }

        public PagePermissionViewModel GetPagesPermissionLookUp()
        {
            using(var db = unitOfWork.GetAutoSolutionContext().Database.GetDbConnection())
            {
                db.Open();
                var result = db.Query<string>(AutoSolutionStoreProcedureUtility.GetPagePermissions,
                   new { }, commandType: CommandType.StoredProcedure);
                StringBuilder stringBuilder = new StringBuilder();
                foreach (var rec in result)
                {
                    stringBuilder.Append(rec);
                }
                var response = JsonConvert.DeserializeObject<PagePermissionViewModel>(stringBuilder.ToString());
                db.Close();
                return response;
            }
        }
    }
}
