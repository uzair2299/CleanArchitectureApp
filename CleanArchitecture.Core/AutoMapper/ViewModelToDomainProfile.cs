using AutoMapper;
using CleanArchitecture.Core.ViewModels;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Core.AutoMapper
{
    class ViewModelToDomainProfile:Profile
    {
        public ViewModelToDomainProfile()
        {
            CreateMap<AutoManufacturerViewModel, AutoManufacturer>();
            CreateMap<AutoBodyTypeViewModel, AutoBodyType>();
            CreateMap<AutoModelViewModel, AutoModel>();
            CreateMap<AutoVersionViewModel, AutoVersion>();
            CreateMap<AutoEngineTypeViewModel, AutoEngineType>();
            CreateMap<RolesViewModel, Role>();
            CreateMap<UserViewModel, User>();
            CreateMap<AutoLookUpTypeViewModel, AutoLookUpType>();
            CreateMap<AutoSpecificationViewModel, AutoSpecification>();
        }
    }
}
