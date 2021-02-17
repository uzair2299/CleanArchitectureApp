﻿using AutoMapper;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.PageSet;
using CleanArchitecture.Core.ViewModels;
using CleanArchitecture.Domain.Entities;
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

        public AutoSolutionPageSet<AutoManufacturerViewModel> GetAutoManufacturer(AutoManufacturerViewModel autoManufacturerViewModel)
        {
             return  autoManufacturerRepository.GetAutoManufacturer(autoManufacturerViewModel);
        }

        public AutoManufacturerViewModel GetAutoManufacturerById(int Id)
        {
            return autoManufacturerRepository.GetAutoManufacturerById(Id);
        }

        public bool UpdateAutoManufacturer(AutoManufacturerViewModel autoManufacturerViewModel)
        {
            autoManufacturer = autoMapper.Map<AutoManufacturer>(autoManufacturerViewModel);
            return autoManufacturerRepository.UpdateAutoManufacturer(autoManufacturer);
        }
    }
}
