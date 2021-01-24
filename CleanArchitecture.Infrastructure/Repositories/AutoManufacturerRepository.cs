using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class AutoManufacturerRepository :IAutoManufacturerRepository
    {
        private readonly IRepository<AutoManufacturer> repository;
        private IUnitOfWork unitOfWork;

        public AutoManufacturerRepository(IRepository<AutoManufacturer> repository)
        {
            this.repository = repository;
        }

        public bool AutoManufacturerSave(AutoManufacturer autoManufacturer)
        {
            var obj= repository.Add(autoManufacturer);
            unitOfWork.SaveChanges();
            return true;
        }
    }
}
