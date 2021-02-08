using AutoMapper;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.PageSet;
using CleanArchitecture.Core.ViewModels;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Interfaces;
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
            var result =  unitOfWork.GetAutoSolutionContext().AutoManufacturers.AsQueryable().ToList();
            Pager pager = new Pager(result.Count(), autoManufacturerViewModel.PageNo,15);
            result =  result.OrderBy(x => x.AutoManufacturerName).Skip((pager.StartPage - 1) * pager.PageSize).Take(pager.PageSize).ToList();
            AutoSolutionPageSet<AutoManufacturerViewModel> autoSolutionPageSet = new AutoSolutionPageSet<AutoManufacturerViewModel>()
            {
                Pager = pager,
                Data = autoMapper.Map<List<AutoManufacturerViewModel>>(result)
            };
            return autoSolutionPageSet;
        }

        public bool SaveAutoManufacturer(AutoManufacturer autoManufacturer)
        {
            var obj= repository.Add(autoManufacturer);
            unitOfWork.SaveChanges();
            return true;
        }
    }
}
