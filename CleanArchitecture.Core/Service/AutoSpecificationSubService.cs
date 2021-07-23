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
    public class AutoSpecificationSubService : IAutoSpecificationSubService
    {
        private readonly IAutoSpecificationSubRepository AutoSpecificationSubRepository;
        private readonly IMapper autoMapper;
        private AutoSpecificationSub AutoSpecificationSub;
        public AutoSpecificationSubService(AutoSpecificationSub AutoSpecificationSub, IMapper autoMapper, IAutoSpecificationSubRepository AutoSpecificationSubRepository)
        {
            this.AutoSpecificationSub = AutoSpecificationSub;
            this.autoMapper = autoMapper;
            this.AutoSpecificationSubRepository = AutoSpecificationSubRepository;
        }

        public AutoSpecificationSubViewModel AutoSpecificationSubSave(AutoSpecificationSubViewModel AutoSpecificationSubViewModel)
        {
            return AutoSpecificationSubRepository.AutoSpecificationSubSave(AutoSpecificationSubViewModel);
        }

        public AutoSolutionPageSet<AutoSpecificationSubViewModel> GetAutoSpecificationSub(AutoSpecificationSubViewModel AutoSpecificationSubViewModel)
        {
            return AutoSpecificationSubRepository.GetAutoSpecificationSub(AutoSpecificationSubViewModel);
        }

        public AutoSpecificationSubViewModel GetAutoSpecificationSubById(int Id)
        {
            return AutoSpecificationSubRepository.GetAutoSpecificationSubById(Id);
        }
    }
}
