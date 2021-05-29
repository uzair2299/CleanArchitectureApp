﻿using AutoMapper;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Interfaces;
using CleanArchitecture.Infrastructure.Utility;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            IQueryable<AutoManufacturer> result = unitOfWork.GetAutoSolutionContext().AutoManufacturers.AsQueryable();
            selectListItems =  result.Select(x => new SelectListItem()
            {
                Text = x.AutoManufacturerName,
                Value = x.Id.ToString()
            }).OrderBy(x=>x.Text).ToList();

            var c = unitOfWork.GetAutoSolutionContext().Database.GetDbConnection();
            c.Open();
            var command = c.CreateCommand();
            command.CommandText = "EXEC " + AutoSolutionStoreProcedureUtility.LookupForAutoVersion;
            try
            {

                List<SelectListItem> selectListItems1 = new List<SelectListItem>();
                List<SelectListItem> selectListItems2 = new List<SelectListItem>();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            selectListItems1.Add(new SelectListItem
                            {
                                Text = reader["BodyType"].ToString(),
                                Value = Convert.ToInt32(reader["Id"]).ToString()
                            });
                        }

                        reader.NextResult();
                        while (reader.Read())
                        {
                            selectListItems2.Add(new SelectListItem
                            {
                                Text = reader["EngineTypeName"].ToString(),
                                Value = Convert.ToInt32(reader["Id"]).ToString()
                            });
                        }
                    }
                    }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            //selectListItems.Insert(0, new SelectListItem() { Text = "Select", Value = null });

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
;        }
    }
}
