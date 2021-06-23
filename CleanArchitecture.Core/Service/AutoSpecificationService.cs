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
    public class AutoSpecificationService : IAutoSpecificationService
    {
        private readonly IAutoSpecificationRepository AutoSpecificationRepository;
        private readonly IMapper autoMapper;
        private AutoSpecification AutoSpecification;
        public AutoSpecificationService(AutoSpecification AutoSpecification, IMapper autoMapper, IAutoSpecificationRepository AutoSpecificationRepository)
        {
            this.AutoSpecification = AutoSpecification;
            this.autoMapper = autoMapper;
            this.AutoSpecificationRepository = AutoSpecificationRepository;
        }

        public AutoSpecificationViewModel AutoSpecificationSave(AutoSpecificationViewModel AutoSpecificationViewModel)
        {
            return AutoSpecificationRepository.AutoSpecificationSave(AutoSpecificationViewModel);
        }

        public AutoSolutionPageSet<AutoSpecificationViewModel> GetAutoSpecification(AutoSpecificationViewModel AutoSpecificationViewModel)
        {
            return AutoSpecificationRepository.GetAutoSpecification(AutoSpecificationViewModel);
        }

        public AutoSpecificationViewModel GetAutoSpecificationById(int Id)
        {
            return AutoSpecificationRepository.GetAutoSpecificationById(Id);
        }
    }
}
