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
    public class AutoSpecificationSubRepository : IAutoSpecificationSubRepository
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper autoMapper;
        private readonly IRepository<AutoSpecificationSub> repository;

        public AutoSpecificationSubRepository(IUnitOfWork unitOfWork, IMapper autoMapper, IRepository<AutoSpecificationSub> repository)
        {
            this.unitOfWork = unitOfWork;
            this.autoMapper = autoMapper;
            this.repository = repository;
        }
        public AutoSpecificationViewModel AutoSpecificationSubSave(AutoSpecificationViewModel AutoSpecificationViewModel)
        {
            using (var db = unitOfWork.GetAutoSolutionContext().Database.GetDbConnection())
            {
                db.Open();
                var command = db.CreateCommand();
                //command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "EXEC " + AutoSolutionStoreProcedureUtility.spInsertAutoSpecification + " @SpecificationParameter,@SpecificationTypeId";
                command.Parameters.Add(new SqlParameter("SpecificationParameter", AutoSpecificationViewModel.SpecificationParameter));
                command.Parameters.Add(new SqlParameter("SpecificationTypeId", AutoSpecificationViewModel.SpecificationTypeId));
                int rowAffected = command.ExecuteNonQuery();

                return rowAffected > 0 ? AutoSpecificationViewModel : null;

            }

        }

        public AutoSolutionPageSet<AutoSpecificationSubViewModel> GetAutoSpecificationSub(AutoSpecificationSubViewModel AutoSpecificationSubViewModel)
        {


            var c = unitOfWork.GetAutoSolutionContext().Database.GetDbConnection();
            c.Open();
            var command = c.CreateCommand();
            command.CommandText = "EXEC " + AutoSolutionStoreProcedureUtility.spSelectAutoSpecification + " @SearchTerm, @PageNo, @PageSize,@TotalCount OUT";
            if (AutoSpecificationSubViewModel.SearchTerm == null)
            {
                command.Parameters.Add(new SqlParameter("SearchTerm",DBNull.Value));
            }
            else
            {
                command.Parameters.Add(new SqlParameter("SearchTerm",AutoSpecificationSubViewModel.SearchTerm));
            }
            
            command.Parameters.Add(new SqlParameter("@PageNo", AutoSpecificationSubViewModel.PageNo));
            command.Parameters.Add(new SqlParameter("@PageSize", AutoSpecificationSubViewModel.PageSize));
            command.Parameters.Add(new SqlParameter("@TotalCount",0));
            command.Parameters["@TotalCount"].Direction = ParameterDirection.Output;
            List<AutoSpecificationSubViewModel> finalResult = new List<AutoSpecificationSubViewModel>();
            int TotalCount = 0;
            using (var reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        finalResult.Add(new AutoSpecificationSubViewModel
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            SpecificationParameter = reader["SpecificationParameter"].ToString(),
                            SpecificationType = reader["SpecificationType"].ToString()
                        });
                    }

                }
            }

            TotalCount = Convert.ToInt32(command.Parameters["@TotalCount"].Value);
            AutoSolutionPageSet<AutoSpecificationSubViewModel> autoSolutionPageSet = new AutoSolutionPageSet<AutoSpecificationSubViewModel>()
            {
                Pager = new Pager(TotalCount, AutoSpecificationSubViewModel.PageNo,AutoSpecificationSubViewModel.PageSize),
                Data = finalResult
            };
            return autoSolutionPageSet;
        }

        public AutoSpecificationSubViewModel GetAutoSpecificationSubById(int Id)
        {
            AutoSpecificationSub auto = repository.GetById(Id);
           return  autoMapper.Map<AutoSpecificationSubViewModel>(auto);

            //string ne = auto.AutoManufacturer.AutoManufacturerName;
            //return null;
        }
    }
}
