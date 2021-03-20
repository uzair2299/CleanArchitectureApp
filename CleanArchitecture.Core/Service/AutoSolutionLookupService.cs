using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Service
{
    public class AutoSolutionLookupService : IAutoSolutionLookupService
    {
        private readonly IAutoSolutionLookupRepository autoSolutionLookupRepository;
        private AutoModelViewModel autoModelViewModel;
        public AutoSolutionLookupService(IAutoSolutionLookupRepository autoSolutionLookupRepository, AutoModelViewModel autoModelViewModel)
        {
            this.autoSolutionLookupRepository = autoSolutionLookupRepository;
            this.autoModelViewModel = autoModelViewModel;
        }
        public AutoModelViewModel GetAutoManufacturerLookup()
        {
            autoModelViewModel.AutoManufacturerLookup = autoSolutionLookupRepository.GetAutoManufacturerLookup();
            return autoModelViewModel;
        }
    }
}
