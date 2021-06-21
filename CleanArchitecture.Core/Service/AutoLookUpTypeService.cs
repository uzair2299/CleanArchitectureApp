using AutoMapper;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.PageSet;
using CleanArchitecture.Core.ViewModels;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Service
{
    public class AutoLookUpTypeService : IAutoLookUpTypeService
    {
        private readonly IAutoLookUpTypeRepository AutoLookUpTypeRepository;
        private readonly IMapper autoMapper;
        private AutoLookUpType AutoLookUpType;

        public AutoLookUpTypeService(IAutoLookUpTypeRepository AutoLookUpTypeRepository, IMapper autoMapper, AutoLookUpType autoLookUpType)
        {
            this.AutoLookUpTypeRepository = AutoLookUpTypeRepository;
            this.autoMapper = autoMapper;
            this.AutoLookUpType = autoLookUpType;
        }

        public AutoLookUpTypeViewModel AutoLookUpTypeSave(AutoLookUpTypeViewModel AutoLookUpTypeViewModel)
        {
            AutoLookUpType = autoMapper.Map<AutoLookUpType>(AutoLookUpTypeViewModel);
            return AutoLookUpTypeRepository.SaveAutoLookUpType(AutoLookUpType);
        }

        public bool DeleteAutoLookUpType(int Id)
        {
            return AutoLookUpTypeRepository.DeleteAutoLookUpType(Id);
        }

        public AutoSolutionPageSet<AutoLookUpTypeViewModel> GetAutoLookUpType(AutoLookUpTypeViewModel AutoLookUpTypeViewModel)
        {
            return AutoLookUpTypeRepository.GetAutoLookUpType(AutoLookUpTypeViewModel);
        }

        public AutoLookUpTypeViewModel GetAutoLookUpTypeById(int Id)
        {
            return AutoLookUpTypeRepository.GetAutoLookUpTypeById(Id);
        }


        public bool UpdateAutoLookUpType(AutoLookUpTypeViewModel AutoLookUpTypeViewModel)
        {
            AutoLookUpType = autoMapper.Map<AutoLookUpType>(AutoLookUpTypeViewModel);
            return AutoLookUpTypeRepository.UpdateAutoLookUpType(AutoLookUpType);
        }
    }
}
