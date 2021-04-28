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
    public class AutoVersionRepository : IAutoVersionRepository
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper autoMapper;
        private readonly IRepository<AutoVersion> repository;

        public AutoVersionRepository(IUnitOfWork unitOfWork, IMapper autoMapper, IRepository<AutoVersion> repository)
        {
            this.unitOfWork = unitOfWork;
            this.autoMapper = autoMapper;
            this.repository = repository;
        }
        public AutoVersionViewModel AutoVersionSave(AutoVersionViewModel autoVersionViewModel)
        {
            var c = unitOfWork.GetAutoSolutionContext().Database.GetDbConnection();
            c.Open();
            var command = c.CreateCommand();
            //command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText ="EXEC " + AutoSolutionStoreProcedureUtility.InsertAutoModel + " @ModelName,@AutoManufacturerId";
            command.Parameters.Add(new SqlParameter("ModelName", autoVersionViewModel.ModelName));
            command.Parameters.Add(new SqlParameter("AutoManufacturerId", autoVersionViewModel.SelectedManufacturer));
            int rowAffected =  command.ExecuteNonQuery();
            return rowAffected > 0 ? autoVersionViewModel : null;        }

        public AutoSolutionPageSet<AutoVersionViewModel> GetAutoVersion(AutoVersionViewModel autoVersionViewModel)
        {
            var c = unitOfWork.GetAutoSolutionContext().Database.GetDbConnection();
            c.Open();
            var command = c.CreateCommand();
            command.CommandText = "EXEC " + AutoSolutionStoreProcedureUtility.SelectAutoVersion + " @SearchTerm, @PageNo, @PageSize,@TotalCount OUT";
            if (autoVersionViewModel.SearchTerm == null)
            {
                command.Parameters.Add(new SqlParameter("SearchTerm",DBNull.Value));
            }
            else
            {
                command.Parameters.Add(new SqlParameter("SearchTerm", autoVersionViewModel.SearchTerm));
            }
            
            command.Parameters.Add(new SqlParameter("@PageNo", autoVersionViewModel.PageNo));
            command.Parameters.Add(new SqlParameter("@PageSize", autoVersionViewModel.PageSize));
            command.Parameters.Add(new SqlParameter("@TotalCount",0));
            command.Parameters["@TotalCount"].Direction = ParameterDirection.Output;
            List<AutoVersionViewModel> finalResult = new List<AutoVersionViewModel>();
            int TotalCount = 0;
            try {

                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            finalResult.Add(new AutoVersionViewModel
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                ModelName = reader["ModelName"].ToString(),
                                AutoManufacturerName = reader["AutoManufacturerName"].ToString(),
                                AutoVersionName = reader["AutoVersionName"].ToString(),
                            });
                        }

                    }
                }

                TotalCount = Convert.ToInt32(command.Parameters["@TotalCount"].Value);
                AutoSolutionPageSet<AutoVersionViewModel> autoSolutionPageSet = new AutoSolutionPageSet<AutoVersionViewModel>()
                {
                    Pager = new Pager(TotalCount, autoVersionViewModel.PageNo, autoVersionViewModel.PageSize),
                    Data = finalResult
                };
                return autoSolutionPageSet;
            }
            catch(Exception ex) {
                throw ex;
            }

        }

        public AutoVersionViewModel GetAutoVersionById(int Id)
        {
            AutoVersion autoVersion = repository.GetById(Id);
           return  autoMapper.Map<AutoVersionViewModel>(autoVersion);

            //string ne = auto.AutoManufacturer.AutoManufacturerName;
            //return null;
        }
    }
}
