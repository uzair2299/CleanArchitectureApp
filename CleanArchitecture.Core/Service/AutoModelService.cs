using AutoMapper;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.ViewModels;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Service
{
    public class AutoModelService : IAutoModelService
    {
        private readonly IAutoModelRepository autoModelRepository;
        private readonly IMapper autoMapper;
        private AutoModel autoModel;
        public AutoModelService(AutoModel autoModel, IMapper autoMapper, IAutoModelRepository autoModelRepository)
        {
            this.autoModel = autoModel;
            this.autoMapper = autoMapper;
            this.autoModelRepository = autoModelRepository;
        }

        public AutoModelViewModel AutoModelSave(AutoModelViewModel autoModelViewModel)
        {

            autoModel = autoMapper.Map<AutoModel>(autoModelViewModel);
            return autoModelRepository.AutoModelSave(autoModel);
        }
    }
}
