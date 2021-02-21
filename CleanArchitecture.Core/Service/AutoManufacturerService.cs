using AutoMapper;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.PageSet;
using CleanArchitecture.Core.ViewModels;
using CleanArchitecture.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CleanArchitecture.Core.Service
{
    public class AutoManufacturerService : IAutoManufacturerService
    {
        private readonly IAutoManufacturerRepository autoManufacturerRepository;
        private readonly IMapper autoMapper;
        private AutoManufacturer autoManufacturer;

        public AutoManufacturerService(IAutoManufacturerRepository autoManufacturerRepository, IMapper autoMapper, AutoManufacturer autoManufacturer)
        {
            this.autoManufacturerRepository = autoManufacturerRepository;
            this.autoMapper = autoMapper;
            this.autoManufacturer = autoManufacturer;
        }

        public AutoManufacturerViewModel AutoManufacturerSave(AutoManufacturerViewModel autoManufacturerViewModel)
        {
            autoManufacturer = autoMapper.Map<AutoManufacturer>(autoManufacturerViewModel);
            return autoManufacturerRepository.SaveAutoManufacturer(autoManufacturer);
        }

        public bool DeleteAutoManufacturer(int Id)
        {
            return autoManufacturerRepository.DeleteAutoManufacturer(Id);
        }

        public AutoSolutionPageSet<AutoManufacturerViewModel> GetAutoManufacturer(AutoManufacturerViewModel autoManufacturerViewModel)
        {
             return  autoManufacturerRepository.GetAutoManufacturer(autoManufacturerViewModel);
        }

        public AutoManufacturerViewModel GetAutoManufacturerById(int Id)
        {
            return autoManufacturerRepository.GetAutoManufacturerById(Id);
        }

        public PageSet<AutoManufacturerViewModel> GetAutoManufacturerDT(DTParameters dTParameters)
        {
            return autoManufacturerRepository.GetAutoManufacturerDT(dTParameters);
        }

        public bool UpdateAutoManufacturer(AutoManufacturerViewModel autoManufacturerViewModel)
        {
            autoManufacturer = autoMapper.Map<AutoManufacturer>(autoManufacturerViewModel);
            return autoManufacturerRepository.UpdateAutoManufacturer(autoManufacturer);
        }
    }
}
