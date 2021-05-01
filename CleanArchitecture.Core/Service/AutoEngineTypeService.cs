using AutoMapper;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.PageSet;
using CleanArchitecture.Core.ViewModels;
using CleanArchitecture.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CleanArchitecture.Core.Service
{
    public class AutoEngineTypeService : IAutoEngineTypeService
    {
        private readonly IAutoEngineTypeRepository autoEngineTypeRepository;
        private readonly IMapper autoMapper;
        private AutoEngineType autoEngineType;

        public AutoEngineTypeService(IAutoEngineTypeRepository autoEngineTypeRepository, IMapper autoMapper, AutoEngineType autoEngineType)
        {
            this.autoEngineTypeRepository = autoEngineTypeRepository;
            this.autoMapper = autoMapper;
            this.autoEngineType = autoEngineType;
        }

        public AutoEngineTypeViewModel AutoEngineTypeSave(AutoEngineTypeViewModel autoEngineTypeViewModel)
        {
            autoEngineType = autoMapper.Map<AutoEngineType>(autoEngineTypeViewModel);
            return autoEngineTypeRepository.SaveAutoEngineType(autoEngineType);
        }

        public bool DeleteAutoEngineType(int Id)
        {
            return autoEngineTypeRepository.DeleteAutoEngineType(Id);
        }

        public AutoSolutionPageSet<AutoEngineTypeViewModel> GetAutoEngineType(AutoEngineTypeViewModel autoEngineTypeViewModel)
        {
             return  autoEngineTypeRepository.GetAutoEngineType(autoEngineTypeViewModel);
        }

        public AutoEngineTypeViewModel GetAutoEngineTypeById(int Id)
        {
            return autoEngineTypeRepository.GetAutoEngineTypeById(Id);
        }

        public PageSet<AutoEngineTypeViewModel> GetAutoEngineTypeDT(DTParameters dTParameters)
        {
            return autoEngineTypeRepository.GetAutoEngineTypeDT(dTParameters);
        }

        public bool UpdateAutoEngineType(AutoEngineTypeViewModel autoEngineTypeViewModel)
        {
            autoEngineType = autoMapper.Map<AutoEngineType>(autoEngineTypeViewModel);
            return autoEngineTypeRepository.UpdateAutoEngineType(autoEngineType);
        }
    }
}
