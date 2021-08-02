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

        public AutoSpecificationViewModel AutoSpecificationSubSave(AutoSpecificationViewModel AutoSpecificationViewModel)
        {
            return AutoSpecificationSubRepository.AutoSpecificationSubSave(AutoSpecificationViewModel);
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
