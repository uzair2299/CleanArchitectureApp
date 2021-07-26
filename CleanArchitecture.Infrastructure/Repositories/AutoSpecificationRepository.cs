using AutoMapper;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.PageSet;
using CleanArchitecture.Core.ViewModels;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Interfaces;
using CleanArchitecture.Infrastructure.Utility;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class AutoSpecificationRepository : IAutoSpecificationRepository
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper autoMapper;
        private readonly IRepository<AutoSpecification> repository;

        public AutoSpecificationRepository(IUnitOfWork unitOfWork, IMapper autoMapper, IRepository<AutoSpecification> repository)
        {
            this.unitOfWork = unitOfWork;
            this.autoMapper = autoMapper;
            this.repository = repository;
        }
        public AutoSpecificationViewModel AutoSpecificationSave(AutoSpecificationViewModel AutoSpecificationViewModel)
        {
            //var c = unitOfWork.GetAutoSolutionContext().Database.GetDbConnection();
            //c.Open();
            //var command = c.CreateCommand();
            ////command.CommandType = System.Data.CommandType.StoredProcedure;
            //command.CommandText ="EXEC " + AutoSolutionStoreProcedureUtility.InsertAutoSpecification + " @ModelName,@AutoManufacturerId";
            //command.Parameters.Add(new SqlParameter("ModelName", AutoSpecificationViewModel.ModelName));
            //command.Parameters.Add(new SqlParameter("AutoManufacturerId", AutoSpecificationViewModel.SelectedManufacturer));
            //int rowAffected =  command.ExecuteNonQuery();

            //return rowAffected > 0 ? AutoSpecificationViewModel : null;
            return null;
                }

        public AutoSolutionPageSet<AutoSpecificationViewModel> GetAutoSpecification(AutoSpecificationViewModel AutoSpecificationViewModel)
        {


            var c = unitOfWork.GetAutoSolutionContext().Database.GetDbConnection();
            c.Open();
            var command = c.CreateCommand();
            command.CommandText = "EXEC " + AutoSolutionStoreProcedureUtility.spSelectAutoSpecification + " @SearchTerm, @PageNo, @PageSize,@TotalCount OUT";
            if (AutoSpecificationViewModel.SearchTerm == null)
            {
                command.Parameters.Add(new SqlParameter("SearchTerm",DBNull.Value));
            }
            else
            {
                command.Parameters.Add(new SqlParameter("SearchTerm",AutoSpecificationViewModel.SearchTerm));
            }
            
            command.Parameters.Add(new SqlParameter("@PageNo", AutoSpecificationViewModel.PageNo));
            command.Parameters.Add(new SqlParameter("@PageSize", 100));
            command.Parameters.Add(new SqlParameter("@TotalCount",0));
            command.Parameters["@TotalCount"].Direction = ParameterDirection.Output;
            List<AutoSpecificationViewModel> finalResult = new List<AutoSpecificationViewModel>();
            int TotalCount = 0;
            using (var reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        finalResult.Add(new AutoSpecificationViewModel
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            SpecificationParameter = reader["SpecificationParameter"].ToString(),
                            SpecificationType = reader["SpecificationType"].ToString()
                        });
                    }

                }
            }

            TotalCount = Convert.ToInt32(command.Parameters["@TotalCount"].Value);
            AutoSolutionPageSet<AutoSpecificationViewModel> autoSolutionPageSet = new AutoSolutionPageSet<AutoSpecificationViewModel>()
            {
                Pager = new Pager(TotalCount, AutoSpecificationViewModel.PageNo,AutoSpecificationViewModel.PageSize),
                Data = finalResult
            };
            return autoSolutionPageSet;
        }

        public AutoSpecificationViewModel GetAutoSpecificationById(int Id)
        {
            AutoSpecification auto = repository.GetById(Id);
           return  autoMapper.Map<AutoSpecificationViewModel>(auto);

            //string ne = auto.AutoManufacturer.AutoManufacturerName;
            //return null;
        }
    }
}
