using AutoMapper;
using CleanArchitecture.Core.ViewModels;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Core.AutoMapper
{
    class DomainToViewModelProfile:Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap<AutoManufacturer, AutoManufacturerViewModel>();
            CreateMap<AutoBodyType, AutoBodyTypeViewModel>();
            CreateMap<AutoModel, AutoModelViewModel>().ForMember(dest => dest.SelectedManufacturer, opt => opt.MapFrom(src => src.AutoManufacturerId));
            CreateMap<AutoVersion, AutoVersionViewModel>().ForMember(dest => dest.SelectedAutoModel, opt => opt.MapFrom(src => src.AutoModelId));
            CreateMap<Role, RolesViewModel>();

        }
    }
}
