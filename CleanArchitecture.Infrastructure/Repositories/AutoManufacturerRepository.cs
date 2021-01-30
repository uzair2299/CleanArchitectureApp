using CleanArchitecture.Core.Interfaces;
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
        private IUnitOfWork unitOfWork;

        public AutoManufacturerRepository(IRepository<AutoManufacturer> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<AutoManufacturer> GetAutoManufacturer(AutoManufacturerViewModel autoManufacturerViewModel)
        {
            return unitOfWork.GetAutoSolutionContext().AutoManufacturers.ToList();
        }

        public bool SaveAutoManufacturer(AutoManufacturer autoManufacturer)
        {
            var obj= repository.Add(autoManufacturer);
            unitOfWork.SaveChanges();
            return true;
        }
    }
}
