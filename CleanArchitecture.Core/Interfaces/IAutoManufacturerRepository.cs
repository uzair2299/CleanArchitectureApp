using CleanArchitecture.Core.PageSet;
using CleanArchitecture.Core.ViewModels;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IAutoManufacturerRepository
    {
        AutoManufacturerViewModel SaveAutoManufacturer(AutoManufacturer autoManufacturer);
        AutoSolutionPageSet<AutoManufacturerViewModel> GetAutoManufacturer(AutoManufacturerViewModel autoManufacturerViewModel);
        AutoManufacturerViewModel GetAutoManufacturerById(int Id);
        bool UpdateAutoManufacturer(AutoManufacturer autoManufacturer);
        PageSet<AutoManufacturerViewModel> GetAutoManufacturerDT(DTParameters dTParameters);
    }
}
