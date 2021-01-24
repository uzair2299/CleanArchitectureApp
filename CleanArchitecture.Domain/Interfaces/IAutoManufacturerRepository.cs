using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Domain.Interfaces
{
    public interface IAutoManufacturerRepository
    {
        bool AutoManufacturerSave(AutoManufacturer autoManufacturer);
    }
}
