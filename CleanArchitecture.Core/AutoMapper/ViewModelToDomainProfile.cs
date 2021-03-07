﻿using AutoMapper;
using CleanArchitecture.Core.ViewModels;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Core.AutoMapper
{
    class ViewModelToDomainProfile:Profile
    {
        public ViewModelToDomainProfile()
        {
            CreateMap<AutoManufacturerViewModel, AutoManufacturer>();
            CreateMap<RolesViewModel, Role>();
        }
    }
}
