using AutoMapper;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.PageSet;
using CleanArchitecture.Core.ViewModels;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Core.Service
{
    public class AutoBodyTypeService:IAutoBodyTypeService
    {
        private readonly IAutoBodyTypeRepository autoBodyTypeRepository;
        private readonly IMapper autoMapper;
        private AutoBodyType autoBodyType;

        public AutoBodyTypeService(IAutoBodyTypeRepository autoBodyTypeRepository, IMapper autoMapper, AutoBodyType autoBodyType)
        {
            this.autoBodyTypeRepository = autoBodyTypeRepository;
            this.autoMapper = autoMapper;
            this.autoBodyType = autoBodyType;
        }

        public AutoBodyTypeViewModel AutoBodyTypeSave(AutoBodyTypeViewModel autoBodyTypeViewModel)
        {
            autoBodyType = autoMapper.Map<AutoBodyType>(autoBodyTypeViewModel);
            return autoBodyTypeRepository.SaveAutoBodyType(autoBodyType);
        }

        public bool DeleteAutoBodyType(int Id)
        {
            return autoBodyTypeRepository.DeleteAutoBodyType(Id);
        }

        public AutoSolutionPageSet<AutoBodyTypeViewModel> GetAutoBodyType(AutoBodyTypeViewModel autoBodyTypeViewModel)
        {
            return autoBodyTypeRepository.GetAutoBodyType(autoBodyTypeViewModel);
        }

        public AutoBodyTypeViewModel GetAutoBodyTypeById(int Id)
        {
            return autoBodyTypeRepository.GetAutoBodyTypeById(Id);
        }

        public bool UpdateAutoBodyType(AutoBodyTypeViewModel autoBodyTypeViewModel)
        {
            autoBodyType = autoMapper.Map<AutoBodyType>(autoBodyTypeViewModel);
            return autoBodyTypeRepository.UpdateAutoBodyType(autoBodyType);
        }
    }
}
