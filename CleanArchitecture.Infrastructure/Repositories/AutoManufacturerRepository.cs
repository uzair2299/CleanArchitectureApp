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
    public class AutoManufacturerRepository :IAutoManufacturerRepository
    {
        private readonly IRepository<AutoManufacturer> repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper autoMapper;
        public AutoManufacturerRepository(IRepository<AutoManufacturer> repository, IUnitOfWork unitOfWork, IMapper autoMapper)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.autoMapper = autoMapper;
        }

        public AutoSolutionPageSet<AutoManufacturerViewModel> GetAutoManufacturer(AutoManufacturerViewModel autoManufacturerViewModel)
        {
            List<AutoManufacturer> finalResult = new List<AutoManufacturer>();
            IQueryable<AutoManufacturer> result =  unitOfWork.GetAutoSolutionContext().AutoManufacturers.AsQueryable();
            Pager pager = new Pager(result.Count(), autoManufacturerViewModel.PageNo,15);
            finalResult =  result.OrderBy(x => x.AutoManufacturerName).Skip((pager.StartPage - 1) * pager.PageSize).Take(pager.PageSize).ToList();
            AutoSolutionPageSet<AutoManufacturerViewModel> autoSolutionPageSet = new AutoSolutionPageSet<AutoManufacturerViewModel>()
            {
                Pager = pager,
                Data = autoMapper.Map<List<AutoManufacturerViewModel>>(finalResult)
            };
            return autoSolutionPageSet;
        }

        public AutoManufacturerViewModel GetAutoManufacturerById(int Id)
        {
            var result = repository.GetById(Id);
            return autoMapper.Map<AutoManufacturerViewModel>(result);
        }

        public AutoManufacturerViewModel SaveAutoManufacturer(AutoManufacturer autoManufacturer)
        {
            var alreadyExist = AutoManufacturerAlreadyExist(autoManufacturer);
            if (!alreadyExist) {
                var result = repository.Add(autoManufacturer);
                unitOfWork.SaveChanges();
                return autoMapper.Map<AutoManufacturerViewModel>(result);
            }
            else
            {
                return null;
            }
        }

        public bool UpdateAutoManufacturer(AutoManufacturer autoManufacturer)
        {
            var checkAlreadyExist = repository.GetById(autoManufacturer.Id);
            if (checkAlreadyExist != null)
            {
                unitOfWork.GetAutoSolutionContext().Entry(checkAlreadyExist).State = EntityState.Detached;
                checkAlreadyExist = autoMapper.Map<AutoManufacturer>(autoManufacturer);
                repository.Update(checkAlreadyExist);
                autoMapper.Map<AutoManufacturerViewModel>(checkAlreadyExist);
                var resultbool = unitOfWork.SaveChanges();
                return resultbool == true ? true : false;
            }
            else
                return false;
        }

        private bool AutoManufacturerAlreadyExist(AutoManufacturer autoManufacturer)
        {
            var result = (from item in unitOfWork.GetAutoSolutionContext().AutoManufacturers
                         where (item.AutoManufacturerName == autoManufacturer.AutoManufacturerName)
                         select item).FirstOrDefault();
            return result != null ? true : false;
        }
    }
}
