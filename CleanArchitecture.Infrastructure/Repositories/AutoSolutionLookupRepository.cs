using AutoMapper;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            //selectListItems.Insert(0, new SelectListItem() { Text = "Select", Value = null });
            return selectListItems;
        }
    }
}
