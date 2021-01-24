using AutoMapper;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.ViewModels;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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

        public bool AutoManufacturerSave(AutoManufacturerViewModel autoManufacturerViewModel)
        {
            autoManufacturer = autoMapper.Map<AutoManufacturer>(autoManufacturerViewModel);
            return autoManufacturerRepository.AutoManufacturerSave(autoManufacturer);
        }
    }
}
