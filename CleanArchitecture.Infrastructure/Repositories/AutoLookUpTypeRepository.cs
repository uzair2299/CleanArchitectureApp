using AutoMapper;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.PageSet;
using CleanArchitecture.Core.ViewModels;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class AutoLookUpTypeRepository : IAutoLookUpTypeRepository
    {
        private readonly IRepository<AutoLookUpType> repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper autoMapper;
        public AutoLookUpTypeRepository(IRepository<AutoLookUpType> repository, IUnitOfWork unitOfWork, IMapper autoMapper)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.autoMapper = autoMapper;
        }

        public bool DeleteAutoLookUpType(int Id)
        {
            var result = repository.Remove(Id);
            if (result)
            {
                unitOfWork.SaveChanges();
                return result;
            }
            return result;

        }

        public AutoSolutionPageSet<AutoLookUpTypeViewModel> GetAutoLookUpType(AutoLookUpTypeViewModel AutoLookUpTypeViewModel)
        {
            List<AutoLookUpType> finalResult = new List<AutoLookUpType>();
            IQueryable<AutoLookUpType> result = unitOfWork.GetAutoSolutionContext().AutoLookUpType.AsQueryable();
            if (AutoLookUpTypeViewModel.SearchTerm != null)
            {
                result = result.Where(x => x.LookUpTypeName.Contains(AutoLookUpTypeViewModel.SearchTerm));
            }
            Pager pager = new Pager(result.Count(), AutoLookUpTypeViewModel.PageNo, AutoLookUpTypeViewModel.PageSize);
            finalResult = result.OrderBy(x => x.LookUpTypeName).Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize).ToList();
            AutoSolutionPageSet<AutoLookUpTypeViewModel> autoSolutionPageSet = new AutoSolutionPageSet<AutoLookUpTypeViewModel>()
            {
                Pager = pager,
                Data = autoMapper.Map<List<AutoLookUpTypeViewModel>>(finalResult)
            };
            return autoSolutionPageSet;
        }

        public AutoLookUpTypeViewModel GetAutoLookUpTypeById(int Id)
        {
            var result = repository.GetById(Id);
            return autoMapper.Map<AutoLookUpTypeViewModel>(result);
        }

        public PageSet<AutoLookUpTypeViewModel> GetAutoLookUpTypeDT(DTParameters dTParameters)
        {
            var sortColumnName = dTParameters.Columns[dTParameters.Order[0].Column].Data;
            var sortDirection = dTParameters.Order[0].Dir;

            IQueryable<AutoLookUpType> result = unitOfWork.GetAutoSolutionContext().AutoLookUpType.AsQueryable().OrderBy(x => x.LookUpTypeName);
            var TotalCount = result.Count();

            //if(sortColumnName == "AutoLookUpTypeName" && sortDirection == DTOrderDir.ASC)
            //{
            //    result = result.OrderBy(x => x.AutoLookUpTypeName);
            //}
            //else if(sortColumnName== "AutoLookUpTypeName" && sortDirection== DTOrderDir.DESC)
            //{
            //    result = result.OrderByDescending(x => x.AutoLookUpTypeName);
            //}

            var FinalResult = result.Skip(dTParameters.Start).Take(dTParameters.Length);

            var Data = autoMapper.Map<List<AutoLookUpTypeViewModel>>(FinalResult);
            PageSet<AutoLookUpTypeViewModel> pageSet = new PageSet<AutoLookUpTypeViewModel>
            {
                draw = dTParameters.Draw,
                recordsFiltered = TotalCount,
                recordsTotal = TotalCount,
                result = Data
            };
            return pageSet;
        }

        public AutoLookUpTypeViewModel SaveAutoLookUpType(AutoLookUpType AutoLookUpType)
        {
            var alreadyExist = AutoLookUpTypeAlreadyExist(AutoLookUpType);
            if (!alreadyExist)
            {
                var result = repository.Add(AutoLookUpType);
                unitOfWork.SaveChanges();
                return autoMapper.Map<AutoLookUpTypeViewModel>(result);
            }
            else
            {
                return null;
            }
        }

        public bool UpdateAutoLookUpType(AutoLookUpType AutoLookUpType)
        {
            var checkAlreadyExist = repository.GetById(AutoLookUpType.Id);
            if (checkAlreadyExist != null)
            {
                unitOfWork.GetAutoSolutionContext().Entry(checkAlreadyExist).State = EntityState.Detached;
                checkAlreadyExist = autoMapper.Map<AutoLookUpType>(AutoLookUpType);
                repository.Update(checkAlreadyExist);
                autoMapper.Map<AutoLookUpTypeViewModel>(checkAlreadyExist);
                var resultbool = unitOfWork.SaveChanges();
                return resultbool == true ? true : false;
            }
            else
                return false;
        }


        private bool AutoLookUpTypeAlreadyExist(AutoLookUpType AutoLookUpType)
        {

            //var c =  unitOfWork.GetAutoSolutionContext().Database.GetDbConnection();
            //var command =  c.CreateCommand();
            // c.Open();
            // command.CommandText = "[spName] @P3, @P2, @P1";
            //add parameter values
            //execute reader


            var result = (from item in unitOfWork.GetAutoSolutionContext().AutoLookUpType
                          where (item.LookUpTypeName == AutoLookUpType.LookUpTypeName)
                          select item).FirstOrDefault();
            return result != null ? true : false;
        }
    }
}
