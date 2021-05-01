using AutoMapper;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.PageSet;
using CleanArchitecture.Core.ViewModels;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class AutoEngineTypeRepository :IAutoEngineTypeRepository
    {
        private readonly IRepository<AutoEngineType> repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper autoMapper;
        public AutoEngineTypeRepository(IRepository<AutoEngineType> repository, IUnitOfWork unitOfWork, IMapper autoMapper)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.autoMapper = autoMapper;
        }

        public bool DeleteAutoEngineType(int Id)
        {
            var result = repository.Remove(Id);
            if (result)
            {
                unitOfWork.SaveChanges();
                return result;
            }
            return result;

        }

        public AutoSolutionPageSet<AutoEngineTypeViewModel> GetAutoEngineType(AutoEngineTypeViewModel autoEngineTypeViewModel)
        {
            List<AutoEngineType> finalResult = new List<AutoEngineType>();
            IQueryable<AutoEngineType> result = (IQueryable<AutoEngineType>)unitOfWork.GetAutoSolutionContext().AutoEngineType.AsQueryable();
            if (autoEngineTypeViewModel.SearchTerm != null)
            {
                result = result.Where(x => x.EngineTypeName.Contains(autoEngineTypeViewModel.SearchTerm));
            }
            Pager pager = new Pager(result.Count(), autoEngineTypeViewModel.PageNo,autoEngineTypeViewModel.PageSize);
            finalResult =  result.OrderBy(x => x.EngineTypeName).Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize).ToList();
            AutoSolutionPageSet<AutoEngineTypeViewModel> autoSolutionPageSet = new AutoSolutionPageSet<AutoEngineTypeViewModel>()
            {
                Pager = pager,
                Data = autoMapper.Map<List<AutoEngineTypeViewModel>>(finalResult)
            };
            return autoSolutionPageSet;
        }

        public AutoEngineTypeViewModel GetAutoEngineTypeById(int Id)
        {
            var result = repository.GetById(Id);
            return autoMapper.Map<AutoEngineTypeViewModel>(result);
        }

        public PageSet<AutoEngineTypeViewModel> GetAutoEngineTypeDT(DTParameters dTParameters)
        {
            var sortColumnName = dTParameters.Columns[dTParameters.Order[0].Column].Data;
            var sortDirection = dTParameters.Order[0].Dir;

            IQueryable<AutoEngineType> result = unitOfWork.GetAutoSolutionContext().AutoEngineType.AsQueryable().OrderBy(x=>x.EngineTypeName);
            var TotalCount = result.Count();

            //if(sortColumnName == "autoEngineTypeName" && sortDirection == DTOrderDir.ASC)
            //{
            //    result = result.OrderBy(x => x.AutoEngineTypeName);
            //}
            //else if(sortColumnName== "autoEngineTypeName" && sortDirection== DTOrderDir.DESC)
            //{
            //    result = result.OrderByDescending(x => x.AutoEngineTypeName);
            //}

            var FinalResult = result.Skip(dTParameters.Start).Take(dTParameters.Length);

            var Data = autoMapper.Map<List<AutoEngineTypeViewModel>>(FinalResult);
            PageSet<AutoEngineTypeViewModel> pageSet = new PageSet<AutoEngineTypeViewModel>
            {
                draw = dTParameters.Draw,
                recordsFiltered = TotalCount,
                recordsTotal = TotalCount,
                result = Data
            };
            return pageSet;
        }

        public AutoEngineTypeViewModel SaveAutoEngineType(AutoEngineType autoEngineType)
        {
            var alreadyExist = AutoEngineTypeAlreadyExist(autoEngineType);
            if (!alreadyExist) {
                var result = repository.Add(autoEngineType);
                unitOfWork.SaveChanges();
                return autoMapper.Map<AutoEngineTypeViewModel>(result);
            }
            else
            {
                return null;
            }
        }

        public bool UpdateAutoEngineType(AutoEngineType autoEngineType)
        {
            var checkAlreadyExist = repository.GetById(autoEngineType.Id);
            if (checkAlreadyExist != null)
            {
                unitOfWork.GetAutoSolutionContext().Entry(checkAlreadyExist).State = EntityState.Detached;
                checkAlreadyExist = autoMapper.Map<AutoEngineType>(autoEngineType);
                repository.Update(checkAlreadyExist);
                autoMapper.Map<AutoEngineTypeViewModel>(checkAlreadyExist);
                var resultbool = unitOfWork.SaveChanges();
                return resultbool == true ? true : false;
            }
            else
                return false;
        }


        private bool AutoEngineTypeAlreadyExist(AutoEngineType autoEngineType)
        {

           //var c =  unitOfWork.GetAutoSolutionContext().Database.GetDbConnection();
           //var command =  c.CreateCommand();
           // c.Open();
           // command.CommandText = "[spName] @P3, @P2, @P1";
            //add parameter values
            //execute reader
            

            var result = (from item in unitOfWork.GetAutoSolutionContext().AutoEngineType
                         where (item.EngineTypeName == autoEngineType.EngineTypeName)
                         select item).FirstOrDefault();
            return result != null ? true : false;
        }
    }
}
