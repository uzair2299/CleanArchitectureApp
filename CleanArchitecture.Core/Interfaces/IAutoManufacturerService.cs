using CleanArchitecture.Core.PageSet;
using CleanArchitecture.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IAutoManufacturerService
    {
        AutoManufacturerViewModel AutoManufacturerSave(AutoManufacturerViewModel autoManufacturerViewModel);
        AutoSolutionPageSet<AutoManufacturerViewModel> GetAutoManufacturer(AutoManufacturerViewModel autoManufacturerViewModel);
        AutoManufacturerViewModel GetAutoManufacturerById(int Id);
        bool UpdateAutoManufacturer(AutoManufacturerViewModel autoManufacturerViewModel);

        PageSet<AutoManufacturerViewModel> GetAutoManufacturerDT(DTParameters dTParameters);
    }
}
