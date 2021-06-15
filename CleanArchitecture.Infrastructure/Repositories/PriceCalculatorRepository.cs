using AutoMapper;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.ViewModels;
using CleanArchitecture.Infrastructure.Interfaces;
using CleanArchitecture.Infrastructure.Utility;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class PriceCalculatorRepository : IPriceCalculatorRepository
    {
        //private readonly IRepository<AutoManufacturer> repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper autoMapper;
        public PriceCalculatorRepository(
            //IRepository<AutoManufacturer> repository,
            IUnitOfWork unitOfWork,
            IMapper autoMapper)
        {
            //this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.autoMapper = autoMapper;
        }
        public PriceCalculatorViewModel GetOnRoadPrice(PriceCalculatorViewModel priceCalculatorViewModel)
        {
            using (var db = unitOfWork.GetAutoSolutionContext().Database.GetDbConnection())
            {
                db.Open();
                PriceCalculatorViewModel result = db.QueryFirst<PriceCalculatorViewModel>(AutoSolutionStoreProcedureUtility.spGetOnRoadPrice,
                    new { AutoVersionId = priceCalculatorViewModel.SelectedAutoVersion }, commandType: CommandType.StoredProcedure);
                if(result.EngineCapacity<= 850)
                {
                    result.WithHoldingTaxForFiler = 7000;
                    result.WithHoldingTaxForNonFiler = 15000;
                }
                else if (result.EngineCapacity>=851 &&  result.EngineCapacity <= 1000)
                {
                    result.WithHoldingTaxForFiler = 15000;
                    result.WithHoldingTaxForNonFiler = 30000;
                }
                else if (result.EngineCapacity >= 1001 && result.EngineCapacity <= 1300)
                {
                    result.WithHoldingTaxForFiler = 25000;
                    result.WithHoldingTaxForNonFiler = 50000;
                }
                else if (result.EngineCapacity >= 1301 && result.EngineCapacity <= 1600)
                {
                    result.WithHoldingTaxForFiler = 50000;
                    result.WithHoldingTaxForNonFiler = 100000;
                }
                else if (result.EngineCapacity >= 1601 && result.EngineCapacity <= 1800)
                {
                    result.WithHoldingTaxForFiler = 75000;
                    result.WithHoldingTaxForNonFiler = 150000;
                }
                else if (result.EngineCapacity >= 1801 && result.EngineCapacity <= 2000)
                {
                    result.WithHoldingTaxForFiler = 100000;
                    result.WithHoldingTaxForNonFiler = 200000;
                }
                else if (result.EngineCapacity >= 2001 && result.EngineCapacity <= 2500)
                {
                    result.WithHoldingTaxForFiler = 150000;
                    result.WithHoldingTaxForNonFiler = 300000;
                }
                else if (result.EngineCapacity >= 2501 && result.EngineCapacity <= 3000)
                {
                    result.WithHoldingTaxForFiler = 200000;
                    result.WithHoldingTaxForNonFiler = 400000;
                }
                else if (result.EngineCapacity >= 3001)
                {
                    result.WithHoldingTaxForFiler = 250000;
                    result.WithHoldingTaxForNonFiler = 500000;
                }
                return result;
            }
        }
    }
}
