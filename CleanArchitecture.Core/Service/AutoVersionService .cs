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
    public class AutoVersionService : IAutoVersionService
    {
        private readonly IAutoVersionRepository autoVersionRepository;
        private readonly IMapper autoMapper;
        private AutoModel autoModel;
        public AutoVersionService(AutoModel autoModel, IMapper autoMapper, IAutoVersionRepository autoVersionRepository)
        {
            this.autoModel = autoModel;
            this.autoMapper = autoMapper;
            this.autoVersionRepository = autoVersionRepository;
        }

        public AutoVersionViewModel AutoVersionSave(AutoVersionViewModel autoVersionViewModel)
        {

            //autoModel = autoMapper.Map<AutoModel>(autoModelViewModel);
            return autoVersionRepository.AutoVersionSave(autoVersionViewModel);
        }

        public AutoSolutionPageSet<AutoVersionViewModel> GetAutoVersion(AutoVersionViewModel autoVersionViewModel)
        {
            return autoVersionRepository.GetAutoVersion(autoVersionViewModel);
        }

        public AutoVersionViewModel GetAutoVersionById(int Id)
        {
            return autoVersionRepository.GetAutoVersionById(Id);
        }
    }
}
