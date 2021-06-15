using CleanArchitecture.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IPriceCalculatorService
    {
        public PriceCalculatorViewModel GetOnRoadPrice(PriceCalculatorViewModel priceCalculatorViewModel);
    }
}
