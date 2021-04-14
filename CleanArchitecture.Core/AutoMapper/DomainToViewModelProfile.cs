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
            CreateMap<AutoModel, AutoModelViewModel>().ForMember(dest => dest.SelectedManufacturer, opt => opt.MapFrom(src => src.AutoManufacturerId));
            CreateMap<Role, RolesViewModel>();

        }
    }
}
