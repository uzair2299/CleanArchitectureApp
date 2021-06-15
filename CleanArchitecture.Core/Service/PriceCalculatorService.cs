using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Service
{
    public class PriceCalculatorService : IPriceCalculatorService
    {
        private readonly IPriceCalculatorRepository priceCalculatorRepository;

        public PriceCalculatorService(IPriceCalculatorRepository priceCalculatorRepository)
        {
            this.priceCalculatorRepository = priceCalculatorRepository;
        }

        public PriceCalculatorViewModel GetOnRoadPrice(PriceCalculatorViewModel priceCalculatorViewModel)
        {
            return priceCalculatorRepository.GetOnRoadPrice(priceCalculatorViewModel);
        }
    }
}
