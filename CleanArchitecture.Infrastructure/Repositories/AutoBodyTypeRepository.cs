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
    public class AutoBodyTypeRepository: IAutoBodyTypeRepository
    {
        private readonly IRepository<AutoBodyType> repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper autoMapper;
        public AutoBodyTypeRepository(IRepository<AutoBodyType> repository, IUnitOfWork unitOfWork, IMapper autoMapper)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.autoMapper = autoMapper;
        }

        public bool DeleteAutoBodyType(int Id)
        {
            var result = repository.Remove(Id);
            if (result)
            {
                unitOfWork.SaveChanges();
                return result;
            }
            return result;

        }

        public AutoSolutionPageSet<AutoBodyTypeViewModel> GetAutoBodyType(AutoBodyTypeViewModel autoBodyTypeViewModel)
        {
            List<AutoBodyType> finalResult = new List<AutoBodyType>();
            IQueryable<AutoBodyType> result = unitOfWork.GetAutoSolutionContext().AutoBodyType.AsQueryable();
            if (autoBodyTypeViewModel.SearchTerm != null)
            {
                result = result.Where(x => x.BodyType.Contains(autoBodyTypeViewModel.SearchTerm));
            }
            Pager pager = new Pager(result.Count(), autoBodyTypeViewModel.PageNo, autoBodyTypeViewModel.PageSize);
            finalResult = result.OrderBy(x => x.BodyType).Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize).ToList();
            AutoSolutionPageSet<AutoBodyTypeViewModel> autoSolutionPageSet = new AutoSolutionPageSet<AutoBodyTypeViewModel>()
            {
                Pager = pager,
                Data = autoMapper.Map<List<AutoBodyTypeViewModel>>(finalResult)
            };
            return autoSolutionPageSet;
        }

        public AutoBodyTypeViewModel GetAutoBodyTypeById(int Id)
        {
            var result = repository.GetById(Id);
            return autoMapper.Map<AutoBodyTypeViewModel>(result);
        }

        public PageSet<AutoBodyTypeViewModel> GetAutoBodyTypeDT(DTParameters dTParameters)
        {
            var sortColumnName = dTParameters.Columns[dTParameters.Order[0].Column].Data;
            var sortDirection = dTParameters.Order[0].Dir;

            IQueryable<AutoBodyType> result = unitOfWork.GetAutoSolutionContext().AutoBodyType.AsQueryable().OrderBy(x => x.BodyType);
            var TotalCount = result.Count();

            //if(sortColumnName == "autoBodyTypeName" && sortDirection == DTOrderDir.ASC)
            //{
            //    result = result.OrderBy(x => x.AutoBodyTypeName);
            //}
            //else if(sortColumnName== "autoBodyTypeName" && sortDirection== DTOrderDir.DESC)
            //{
            //    result = result.OrderByDescending(x => x.AutoBodyTypeName);
            //}

            var FinalResult = result.Skip(dTParameters.Start).Take(dTParameters.Length);

            var Data = autoMapper.Map<List<AutoBodyTypeViewModel>>(FinalResult);
            PageSet<AutoBodyTypeViewModel> pageSet = new PageSet<AutoBodyTypeViewModel>
            {
                draw = dTParameters.Draw,
                recordsFiltered = TotalCount,
                recordsTotal = TotalCount,
                result = Data
            };
            return pageSet;
        }

        public AutoBodyTypeViewModel SaveAutoBodyType(AutoBodyType autoBodyType)
        {
            var alreadyExist = AutoBodyTypeAlreadyExist(autoBodyType);
            if (!alreadyExist)
            {
                var result = repository.Add(autoBodyType);
                unitOfWork.SaveChanges();
                return autoMapper.Map<AutoBodyTypeViewModel>(result);
            }
            else
            {
                return null;
            }
        }

        public bool UpdateAutoBodyType(AutoBodyType autoBodyType)
        {
            var checkAlreadyExist = repository.GetById(autoBodyType.Id);
            if (checkAlreadyExist != null)
            {
                unitOfWork.GetAutoSolutionContext().Entry(checkAlreadyExist).State = EntityState.Detached;
                checkAlreadyExist = autoMapper.Map<AutoBodyType>(autoBodyType);
                repository.Update(checkAlreadyExist);
                autoMapper.Map<AutoBodyTypeViewModel>(checkAlreadyExist);
                var resultbool = unitOfWork.SaveChanges();
                return resultbool == true ? true : false;
            }
            else
                return false;
        }


        private bool AutoBodyTypeAlreadyExist(AutoBodyType autoBodyType)
        {

            //var c =  unitOfWork.GetAutoSolutionContext().Database.GetDbConnection();
            //var command =  c.CreateCommand();
            // c.Open();
            // command.CommandText = "[spName] @P3, @P2, @P1";
            //add parameter values
            //execute reader


            var result = (from item in unitOfWork.GetAutoSolutionContext().AutoBodyType
                          where (item.BodyType == autoBodyType.BodyType)
                          select item).FirstOrDefault();
            return result != null ? true : false;
        }
    }
}
