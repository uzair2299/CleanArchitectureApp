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
            CreateMap<Role, RolesViewModel>();
        }
    }
}
