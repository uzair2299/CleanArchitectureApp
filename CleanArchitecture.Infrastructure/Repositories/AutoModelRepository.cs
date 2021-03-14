using AutoMapper;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.ViewModels;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Interfaces;
using CleanArchitecture.Infrastructure.Utility;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class AutoModelRepository : IAutoModelRepository
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper autoMapper;

        public AutoModelRepository(IUnitOfWork unitOfWork, IMapper autoMapper)
        {
            this.unitOfWork = unitOfWork;
            this.autoMapper = autoMapper;
        }
        public AutoModelViewModel AutoModelSave(AutoModel autoModel)
        {
            var c = unitOfWork.GetAutoSolutionContext().Database.GetDbConnection();
            c.Open();
            var command = c.CreateCommand();
            //command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText ="EXEC " + AutoSolutionUtility.InsertAutoModel + " @ModelName,@AutoManufacturerId";
            command.Parameters.Add(new SqlParameter("ModelName", "XYZ"));
            command.Parameters.Add(new SqlParameter("AutoManufacturerId", "1"));
            command.ExecuteNonQuery();
            return null;
        }
    }
}
