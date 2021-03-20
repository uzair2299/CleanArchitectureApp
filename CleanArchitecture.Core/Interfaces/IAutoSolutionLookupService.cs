using CleanArchitecture.Core.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IAutoSolutionLookupService
    {
        public AutoModelViewModel GetAutoManufacturerLookup();
    }
}
